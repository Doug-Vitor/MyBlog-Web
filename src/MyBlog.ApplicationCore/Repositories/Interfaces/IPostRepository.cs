public interface IPostRepository
{
    Task<HttpResponseViewModel<PostViewModel>> InsertAsync(CreatePostInputModel inputModel, string token);
    Task<HttpResponseViewModel<PostViewModel>> GetByIdAsync(int? id);
    Task<HttpResponseViewModel<IEnumerable<PostViewModel>>> GetAllAsync();
    Task<ErrorViewModel> UpdateAsync(int? postId, CreatePostInputModel updatedInputModel, string token);
    Task<ErrorViewModel> RemoveAsync(int? postId, string token);
}
