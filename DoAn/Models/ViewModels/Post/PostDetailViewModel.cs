

public class PostDetailsViewModel
{
    public PostCardViewModel Post { get; set; } = new();

    public List<CommentViewModel> Comments { get; set; } = new();
}