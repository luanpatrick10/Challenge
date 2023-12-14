public class GitHubRepositoryDTO
{
    public GitHubRepositoryDTO()
    {
        Owner = new OwnerDTO();
    }

    public string Name { get; set; }
    public string Description { get; set; }
    public string ImageUrl => Owner.Avatar_url;
    public OwnerDTO Owner { private get; set; }
}
