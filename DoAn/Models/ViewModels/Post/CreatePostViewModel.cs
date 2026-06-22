using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

public class CreatePostViewModel
{
    [Required]
    [StringLength(5000)]
    public string Content { get; set; } = string.Empty;

    public List<IFormFile>? Images { get; set; }

    public string Privacy { get; set; } = "public";
}