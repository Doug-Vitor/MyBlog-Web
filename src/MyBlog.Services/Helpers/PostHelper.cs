public class PostHelper : IPostHelper
{
    private readonly IUserServices _userServices;

    private int _authenticatedUserId
    {
        get
        {
            return _userServices.GetAuthenticatedUserAsync().Id;
        }
    }

    public PostHelper(IUserServices userServices) => _userServices = userServices;

    public bool IsPostOwner(PostViewModel viewModel) => viewModel.AuthorId == _authenticatedUserId;
}