using System.ComponentModel.DataAnnotations;

public class CreateCommentViewModel
{
    [Required]
    public string PostId { get; set; } = string.Empty;

    public string? ParentCommentId { get; set; }

    [Required]
    [StringLength(1000)]
    public string Content { get; set; } = string.Empty;
}