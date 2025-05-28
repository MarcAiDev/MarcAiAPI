using System.Net.Http.Json;
using System.Text.Json;
using MarcAiAPI.Domain.Entities.Store;
using MarcAiAPI.Domain.I.A_models;

namespace MarcAiAPI.Service.I.A;

public class ClassificationApiService
{
    private readonly HttpClient _httpClient;

    public ClassificationApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task SendClassificationRequestAsync(int userId)
    {
        // 1. Obter os dados (com o novo modelo)
        var userPreferences = GetUserPreferencesFromDb(userId);
        var allStoreCategories = GetAllStoresFromDb();

        // 2. Agrupar os dados por StoreId e mapear para o modelo da requisição
        var storesList = allStoreCategories
            .GroupBy(storeEntity => storeEntity.StoreId) // Agrupa todas as entradas pelo ID da loja
            .Select(group => new StoreInfo
            {
                // Gera um nome para a loja, já que não temos essa informação
                Name = $"Store {group.Key}", 
                // Para cada grupo, seleciona a string da categoria e cria uma lista
                Categories = group.Select(g => g.Category).ToList()! 
            })
            .ToList();

        var requestPayload = new ClassificationRequest
        {
            Preferences = userPreferences,
            Stores = storesList
        };
        
        // 3. Enviar a requisição POST (esta parte não muda)
        try
        {
            var response = await _httpClient.PostAsJsonAsync("classify2", requestPayload);

            response.EnsureSuccessStatusCode();

            var responseBody = await response.Content.ReadAsStringAsync();
            Console.WriteLine("API consumida com sucesso!");
            Console.WriteLine($"Payload enviado: {JsonSerializer.Serialize(requestPayload, new JsonSerializerOptions { WriteIndented = true })}");
            Console.WriteLine($"Resposta recebida: {responseBody}");
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine($"Erro na requisição: {e.Message}");
        }
    }

    // --- Métodos de Simulação Atualizados ---
    private static List<string> GetUserPreferencesFromDb(int userId)
    {
        // Esta lógica permanece a mesma
        Console.WriteLine($"Buscando preferências para o usuário: {userId}");
        return ["electronics", "books", "fashion"];
    }

    private static List<StoreEntity> GetAllStoresFromDb()
    {
        Console.WriteLine("Buscando todas as associações de lojas e categorias...");
        // O resultado agora é uma lista plana. Adicionei mais de uma categoria 
        // para a mesma loja para demonstrar o poder do agrupamento.
        return
        [
            new StoreEntity { StoreId = 1, Category = "electronics" },
            new StoreEntity { StoreId = 1, Category = "home" },
            new StoreEntity { StoreId = 2, Category = "books" },
            new StoreEntity { StoreId = 2, Category = "fashion" },
            new StoreEntity { StoreId = 3, Category = "sports" }
        ];
    }
}