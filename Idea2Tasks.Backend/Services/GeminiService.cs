using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Options;

namespace Idea2Tasks.Services;

public class GeminiService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiKey;
    public GeminiService(HttpClient httpClient, IOptions<AppSettingsOptions> options)
    {
        _httpClient = httpClient;
        _apiKey = options.Value.ApiKey;
    }

    public async Task<string> GenerateProjectTasksAsync(
        string projectName,
        string projectDescription)
    {
        string prompt = $$"""
You are a project planning assistant.

Project Name:
{{projectName}}

Project Description:
{{projectDescription}}

Generate 5-10 subtasks for this project.

Return ONLY valid JSON.
Do not include markdown.
Do not include explanations.

Format:

[
  {
    "description": "Task description",
    "isCompleted": false,
    "duration": 120
  }
]
""";

        return await GetChatResponseAsync(prompt);
    }

    public async Task<string> GetChatResponseAsync(string prompt)
    {
        var requestBody = new
        {
            contents = new[]
            {
                new
                {
                    parts = new[]
                    {
                        new { text = prompt }
                    }
                }
            }
        };

        var request = new HttpRequestMessage(
            HttpMethod.Post,
            "https://generativelanguage.googleapis.com/v1beta/models/gemini-3.5-flash:generateContent");

        request.Headers.Add("X-Goog-Api-Key", _apiKey);

        request.Content = new StringContent(
            JsonSerializer.Serialize(requestBody),
            Encoding.UTF8,
            "application/json");

        var response = await _httpClient.SendAsync(request);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            throw new Exception($"Gemini API Error: {response.StatusCode} - {error}");
        }

        using var responseStream = await response.Content.ReadAsStreamAsync();
        using var doc = await JsonDocument.ParseAsync(responseStream);

        return doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString() ?? "";
    }
}