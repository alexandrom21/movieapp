using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using movieappauth.Integration.jsonplaceholder.dto;


namespace movieappauth.Integration.jsonplaceholder
{
    public class JsonplaceholderApiIntegration
    {
        private readonly ILogger<JsonplaceholderApiIntegration> _logger;
        private const string API_URL="https://jsonplaceholder.typicode.com/todos/";

        private readonly HttpClient httpClient;

        public JsonplaceholderApiIntegration(ILogger<JsonplaceholderApiIntegration> logger){
            _logger=logger;
        }

        public async Task<List<Todo>> GetAll(){
            string requestUrl = $"{API_URL}";
            List<Todo> listTodos = new List<Todo>();
            using (HttpClient client = new HttpClient())
            {
                try{
                    HttpResponseMessage response = await client.GetAsync(requestUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        listTodos =  await response.Content.ReadFromJsonAsync<List<Todo>>() ??
                                        new List<Todo>();
                    }
                }catch (HttpRequestException ex)
                {
                    _logger.LogDebug($"Error al llamar a la API: {ex.Message}");
                }
            }
            return listTodos;
        }
    }
}