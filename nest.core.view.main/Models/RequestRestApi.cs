namespace nest.core.view.main.Models
{
    public class RequestRestApi
    {
        private readonly HttpClient httpClient;
        public RequestRestApi(HttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<TResponse?> executeRequest<TResponse, TRequest>(string path, TRequest body, Dictionary<string, string> headers)
        {
            if (headers != null && headers.Count > 0)
                foreach (KeyValuePair<string, string> item in headers)
                    this.httpClient.DefaultRequestHeaders.Add(item.Key, item.Value);
            HttpResponseMessage response = await this.httpClient.PostAsJsonAsync(path, body);
            if (response.IsSuccessStatusCode)
                return await response.Content.ReadFromJsonAsync<TResponse>();
            string errorBody = await response.Content.ReadAsStringAsync();
            throw new Exception($"HTTP ERROR: {response.StatusCode} - {errorBody}");
        }
    }
}
