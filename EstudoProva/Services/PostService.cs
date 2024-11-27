using EstudoProva.Models;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text.Json;

namespace EstudoProva.Services
{
    public class PostService
    {
        private HttpClient? httpClient;
        private Post? post;
        private ObservableCollection<Post>? _posts;
        private JsonSerializerOptions? jsonSerializerOptions;

        public PostService()
        {
            jsonSerializerOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            httpClient = new HttpClient();
        }

        public async Task<ObservableCollection<Post>> getPosts()
        {
            Uri uri = new Uri("https://jsonplaceholder.typicode.com/posts");

            try
            {
                HttpResponseMessage response = await httpClient.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    _posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, jsonSerializerOptions);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }

            return _posts;
        }
    }
}
