using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace DoAn.Models.ViewModels.Profile;

public class EditProfileViewModel
{
    [Required]
    [StringLength(50)]
    public string FirstName { get; set; } = string.Empty;

    [Required]
    [StringLength(50)]
    public string LastName { get; set; } = string.Empty;

    [StringLength(500)]
    public string Bio { get; set; } = string.Empty;

    public IFormFile? Avatar { get; set; }

    public IFormFile? Cover { get; set; }
}