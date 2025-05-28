using System.Net.Http.Json;
using System.Text.Json;
using MarcAiAPI.Domain.Models.AI;
using Microsoft.Extensions.Logging;

namespace MarcAiAPI.Service.I.A; 

public class ClassificationApiService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<ClassificationApiService> _logger;

    public ClassificationApiService(HttpClient httpClient, ILogger<ClassificationApiService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<AIClassificationResponse?> ClassifyStoresAsync(List<string> preferences,
        List<StoreDataForAI> stores)
    {
        var requestModel = new AIClassificationRequest
        {
            Preferences = preferences,
            Stores = stores 
        };

        try
        {
            var response = await _httpClient.PostAsJsonAsync("classify", requestModel);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.IsSuccessStatusCode)
            {
                var classificationResponse = await response.Content.ReadFromJsonAsync<AIClassificationResponse>();
            
                if (classificationResponse?.Status == "success")
                {
                    return classificationResponse;
                }
            
                _logger.LogWarning("IA retornou erro: {Message}", classificationResponse?.Message);
                return new AIClassificationResponse 
                { 
                    Status = "error", 
                    Message = classificationResponse?.Message ?? "Erro desconhecido da IA" 
                };
            }

            _logger.LogError(
                "Erro ao chamar o serviço de classificação. Status: {StatusCode}, Resposta: {ErrorContent}",
                response.StatusCode, responseContent);
            return new AIClassificationResponse
                { Status = "error", Message = $"Erro da API de IA: {response.StatusCode}" };
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro no ClassificationApiService.");
            return new AIClassificationResponse
                { Status = "error", Message = "Erro ao contatar serviço de IA." };
        }
    }
}