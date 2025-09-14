// Este archivo contiene la lógica para consumir tu API.
using BlazorApp1.Data;
using System.Net.Http.Json;

public class DocumentoService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiToken;

    public DocumentoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        _apiToken = "ae8bad44-7348-11ee-b962-0242ac120002";
    }

    public async Task<Documento[]> GetDocumentosAsync()
    {
        try
        {
            // Se agrega el token de autenticación al encabezado.
            _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _apiToken);

            // Se hace la solicitud GET a la URL de tu API.
            return await _httpClient.GetFromJsonAsync<Documento[]>("https://mainserver.ziursoftware.com/Ziur.API/basedatos_01/ZiurServiceRest.svc/api/DocumentosFillsCombos");
        }
        catch (HttpRequestException ex)
        {
            // En caso de error, lo mostramos en la consola para depuración.
            Console.WriteLine($"Error al llamar a la API: {ex.Message}");
            return null;
        }
    }
}
