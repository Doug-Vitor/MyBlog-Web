public class CreatePostInputModel
{
    public string Content { get; set; }

    public CreatePostInputModel()
    {
    }

    public CreatePostInputModel(string content) => Content = content;
}