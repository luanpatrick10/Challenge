using Newtonsoft.Json;

namespace Challenge.UI.Services
{
    public class ChallengeService : IChallangeService
    {
        public async Task<string> ObterRepositorioPorPosicao(int posicao)
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
                    List<GitHubRepositoryDTO?> gitHubRepository = JsonConvert.DeserializeObject<List<GitHubRepositoryDTO>>(content);
                    return JsonConvert.SerializeObject(gitHubRepository[posicao]);
                }
                return null;
            }
        }

    }
}