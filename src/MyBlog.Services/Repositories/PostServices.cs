public class PostServices : IPostServices
{
    private readonly IPostRepository _postRepository;
    private readonly HttpContextHelper _httpContext;

    public PostServices(IPostRepository postRepository, HttpContextHelper httpContext) 
        => (_postRepository, _httpContext) = (postRepository, httpContext);

    public async Task<HttpResponseViewModel<PostViewModel>> InsertAsync(CreatePostInputModel inputModel) 
        => await _postRepository.InsertAsync(inputModel, await _httpContext.GetAuthenticatedUserTokenAsync());

    public async Task<HttpResponseViewModel<PostViewModel>> GetByIdAsync(int? id)
        => await _postRepository.GetByIdAsync(id.GetValueOrDefault());

    public async Task<HttpResponseViewModel<IEnumerable<PostViewModel>>> GetAllAsync()
        => await _postRepository.GetAllAsync();

    public async Task<ErrorViewModel> UpdateAsync(int? postId, CreatePostInputModel updatedInputModel) 
        => await _postRepository.UpdateAsync(postId, updatedInputModel, await _httpContext.GetAuthenticatedUserTokenAsync());

    public async Task<ErrorViewModel> RemoveAsync(int? postId)
        => await _postRepository.RemoveAsync(postId, await _httpContext.GetAuthenticatedUserTokenAsync());
}
