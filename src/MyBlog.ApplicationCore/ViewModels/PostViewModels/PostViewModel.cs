public class PostViewModel
{
    public int Id { get; set; }
    public string Content { get; set; }
    public DateTime CreatedAt { private get; set; }
    public int AuthorId { get; set; }
    public string AuthorUsername { get; set; }

    public string GetCreatedDate()
    {
        TimeSpan elapsedTime = DateTime.UtcNow - CreatedAt;
        if (elapsedTime.Days < 1)
            return "Hoje";
        else if (elapsedTime.Days < 7)
            return $"Há {elapsedTime.Days} dias.";
        else return $"Há {new TimeSpanHelper(elapsedTime.Days).Weeks} semanas.";
    }
}