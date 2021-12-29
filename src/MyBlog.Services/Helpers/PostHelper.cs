using Microsoft.AspNetCore.Http;

public class PostHelper : IPostHelper
{
    private readonly string? _authenticatedUserName;

    public PostHelper(IUserServices userServices, IHttpContextAccessor contextAccessor) =>
        _authenticatedUserName = contextAccessor.HttpContext.User.Identity.IsAuthenticated ? userServices.GetAuthenticatedUserAsync().Result.ViewModel.Username : null;

    public bool IsPostOwner(PostViewModel viewModel) => viewModel.AuthorUsername == _authenticatedUserName;
}