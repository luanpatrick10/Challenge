using Newtonsoft.Json;

namespace Challenge.UI.Services
{
    public class ChallengeService : IChallangeService
    {
        private readonly IConfiguration _configuration;
        public ChallengeService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public List<GitHubRepository> ObterUltimosCincoRepositorios()
        {
            string apiKey = _configuration.GetSection("Token").Get<string>();



            return GetLast5Repositories().Result;
        }

        public async Task<List<GitHubRepository>> GetLast5Repositories()
        {
            string apiBaseUrlGitHub = "https://api.github.com";
            string usuarioGitHub = "takenet";
            string apiUrl = $"{apiBaseUrlGitHub}/users/{usuarioGitHub}/repos?sort=created&direction=desc&per_page=5";

            using (HttpClient httpCliente = new HttpClient())
            {
                httpCliente.DefaultRequestHeaders.Add("User-Agent", "ChallengeApplication");

                HttpResponseMessage response = await httpCliente.GetAsync(apiUrl);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonConvert.DeserializeObject<List<GitHubRepository>>(content);
                }
                else
                {
                    Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                    return null;
                }
            }
        }

    }

    public interface IChallangeService
    {
        List<GitHubRepository> ObterUltimosCincoRepositorios();
    }

    public class GitHubRepository
    {
        public GitHubRepository()
        {
            Owner = new Owner();
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl => Owner.Avatar_url;
        public Owner Owner { private get; set; }
    }

    public class Owner
    {
        public string Avatar_url { get; set; }
    }
}
