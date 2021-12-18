public interface IPostServices
{
    Task<HttpResponseViewModel<PostViewModel>> InsertAsync(CreatePostInputModel inputModel);
    Task<HttpResponseViewModel<PostViewModel>> GetByIdAsync(int? id);
    Task<HttpResponseViewModel<IEnumerable<PostViewModel>>> GetAllAsync();
    Task<ErrorViewModel> UpdateAsync(int? id, CreatePostInputModel updatedInputModel);
    Task<ErrorViewModel> RemoveAsync(int? postId);
}