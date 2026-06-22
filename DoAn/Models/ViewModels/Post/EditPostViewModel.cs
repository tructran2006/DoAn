using Microsoft.AspNetCore.Http;

public class EditPostViewModel
{
    public string PostId { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public List<IFormFile>? NewImages { get; set; }

    public List<string> ExistingImages { get; set; } = new();

    public string Privacy { get; set; } = "public";
}