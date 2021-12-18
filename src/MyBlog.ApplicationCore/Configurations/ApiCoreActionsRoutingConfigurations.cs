public class ApiCoreActionsRoutingConfigurations
{
    public string BasePath { get; set; }
    public string PostsPath { get; set; }
    private Uri PostsBasePath => new(string.Concat(BasePath, PostsPath)); 

    public Uri CreatePostPath => new(string.Concat(PostsBasePath, "Insert/"));
    private Uri GetPostByIdPath => new(string.Concat(PostsBasePath, "GetById/"));
    public Uri AllPostsPath => new(string.Concat(PostsBasePath, "GetAll/"));
    private Uri UpdatePostPath => new(string.Concat(PostsBasePath, "Update/"));
    private Uri DeletePostPath => new(string.Concat(PostsBasePath, "Remove/"));

    public Uri RetrieveGetPostByIdPath(int? postId) => new(string.Concat(GetPostByIdPath, $"{postId}/"));
    public Uri RetrieveEditPostPath(int? postId) => new(string.Concat(UpdatePostPath, $"{postId}/"));
    public Uri RetrieveDeletePostPath(int? postId) => new(string.Concat(DeletePostPath, $"{postId}/"));
}