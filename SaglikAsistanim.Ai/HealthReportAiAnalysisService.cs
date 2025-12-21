
using SaglikAsistanim.Application;
using SaglikAsistanim.Application.Contracts.Ai;

namespace SaglikAsistanim.Ai;

using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;
using System.Text.Json;

public sealed class HealthReportAiAnalysisService : IHealthReportAiAnalysisService
{
  

    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration; // Direkt konfigürasyon

    public HealthReportAiAnalysisService(HttpClient httpClient, IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<ServiceResult<string>> CreateReportAsync(string reportText)
    {
        // 1. Key'i direkt okuyoruz ("Gemini" bölümünün altındaki "ApiKey")
        var apiKey = _configuration["Gemini:ApiKey"];

        // 2. Güvenlik kontrolü (Test sırasında hata alırsan nedenini anlamak için)
        if (string.IsNullOrEmpty(apiKey))
        {
            return ServiceResult<string>.Fail("HATA: API Key appsettings.json dosyasından okunamadı! İsimleri kontrol et.");
        }

        // 3. URL oluşturma (Model ismini 1.5-flash olarak sabitledim)
        var endpoint =
        $"https://generativelanguage.googleapis.com/v1beta/models/gemini-flash-latest:generateContent?key={apiKey}";
        var prompt = $"""
        Sen bir sağlık asistanısın.
        Aşağıdaki sağlık raporunu analiz et ve sade bir özet çıkar:

        {reportText}
        """;

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

        var json = JsonSerializer.Serialize(requestBody);
        var content = new StringContent(json, Encoding.UTF8, "application/json");

        var response = await _httpClient.PostAsync(endpoint, content);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            return ServiceResult<string>.Fail(
                $"Gemini API Hatası: {(int)response.StatusCode} - {error}"
            );
        }


        var responseJson = await response.Content.ReadAsStringAsync();

        using var doc = JsonDocument.Parse(responseJson);

        var resultText = doc.RootElement
            .GetProperty("candidates")[0]
            .GetProperty("content")
            .GetProperty("parts")[0]
            .GetProperty("text")
            .GetString();

        return ServiceResult<string>.Success(resultText!);
    }
}
