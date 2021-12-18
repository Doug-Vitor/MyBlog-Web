using Microsoft.Extensions.Options;

public class PostRepository : BaseRepository, IPostRepository
{
    private readonly ApiCoreActionsRoutingConfigurations _routingConfigurations;

    public PostRepository(IHttpClientFactory client, IOptions<ApiCoreActionsRoutingConfigurations> routingConfigurations) : base(client)
        => _routingConfigurations = routingConfigurations.Value;

    public async Task<HttpResponseViewModel<PostViewModel>> InsertAsync(CreatePostInputModel inputModel, string token)
    {
        HttpRequestMessage request = new(HttpMethod.Post, _routingConfigurations.CreatePostPath);
        request.Headers.Authorization = new("Bearer", token);
        request.Content = SetRequestContent(inputModel);

        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
        return response.IsSuccessStatusCode ? new(true, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<PostViewModel>())
            : new(false, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpResponseViewModel<PostViewModel>> GetByIdAsync(int? id)
    {
        HttpRequestMessage request = new(HttpMethod.Get, _routingConfigurations.RetrieveGetPostByIdPath(id));
        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
        return response.IsSuccessStatusCode ? new(true, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<PostViewModel>())
            : new(false, await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>());
    }

    public async Task<HttpResponseViewModel<IEnumerable<PostViewModel>>> GetAllAsync() => 
        new(true, await (await (await Client.CreateClient().SendAsync(new(HttpMethod.Get, _routingConfigurations.AllPostsPath))).Content.ReadAsStringAsync())
        .FromJsonAsync<IEnumerable<PostViewModel>>());

    public async Task<ErrorViewModel> UpdateAsync(int? postId, CreateUserInputModel updatedInputModel, string token)
    {
        HttpRequestMessage request = new(HttpMethod.Patch, _routingConfigurations.RetrieveEditPostPath(postId));
        request.Headers.Authorization = new("Bearer", token);
        request.Content = SetRequestContent(updatedInputModel);

        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
        return response.IsSuccessStatusCode ? null
            : await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>();
    }

    public async Task<ErrorViewModel> RemoveAsync(int? postId, string token)
    {
        HttpRequestMessage request = new(HttpMethod.Delete, _routingConfigurations.RetrieveDeletePostPath(postId));
        request.Headers.Authorization = new("Bearer", token);

        HttpResponseMessage response = await Client.CreateClient().SendAsync(request);
        return response.IsSuccessStatusCode ? null
            : await (await response.Content.ReadAsStringAsync()).FromJsonAsync<ErrorViewModel>();
    }
}