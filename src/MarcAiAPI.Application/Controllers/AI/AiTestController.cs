using MarcAiAPI.Domain.Models.AI;
using MarcAiAPI.Service.I.A;
using Microsoft.AspNetCore.Mvc;

namespace MarcAiAPI.Application.Controllers.AI;

[ApiController]
[Route("api/[controller]")]
public class AiTestController : ControllerBase
{
    private readonly ClassificationApiService _classificationApiService;
    private readonly ILogger<AiTestController> _logger;

    public AiTestController(ClassificationApiService classificationApiService, ILogger<AiTestController> logger)
    {
        _classificationApiService = classificationApiService;
        _logger = logger;
    }

    [HttpPost("classify-stores")]
    public async Task<IActionResult> ClassifyStores([FromBody] AIClassificationRequest request)
    {
        if (request?.Preferences == null)
        {
            _logger.LogWarning("Requisição para classificar lojas recebida com corpo inválido.");
            return BadRequest(new
                { message = "Corpo da requisição é inválido ou faltando campos 'Preferences' ou 'Stores'." });
        }

        _logger.LogInformation(
            "Iniciando classificação de {StoreCount} lojas com base em {PreferenceCount} preferências.",
            request.Stores.Count, request.Preferences.Count);

        var serviceResponse =
            await _classificationApiService.ClassifyStoresAsync(request.Preferences, request.Stores);

        switch (serviceResponse)
        {
            case null:
                _logger.LogError("Serviço de classificação retornou uma resposta nula.");
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = "Serviço de IA retornou uma resposta inesperada (nula)." });
            case { Status: "success", Result: not null }:
                _logger.LogInformation("Lojas classificadas com sucesso. Retornando {SortedStoreCount} lojas.",
                    serviceResponse.Result.SortedStores.Count);
                return Ok(serviceResponse.Result); // AIClassificationResult
            default:
                _logger.LogError("Falha na classificação pelo serviço de IA. Status: {Status}, Mensagem: {Message}",
                    serviceResponse.Status, serviceResponse.Message);
                return StatusCode(StatusCodes.Status500InternalServerError,
                    new
                    {
                        status = serviceResponse.Status,
                        message = serviceResponse.Message ?? "Erro desconhecido do serviço de IA."
                    });
        }
    }
}