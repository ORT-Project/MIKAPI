using System.ComponentModel.DataAnnotations;

namespace MekiApi.Models;

public class User
{
    public int Id { get; set; }

    [Required]
    [StringLength(50, ErrorMessage = "Le nom d'utilsateur ne doit pas dépasser 50 caractères.")]
    public string Username { get; set; } = string.Empty;
    
    [Required]
    [EmailAddress(ErrorMessage = "L'adresse email n'est pas valide.")]
    public string Email { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Fait la relation avec Score
    public ICollection<Score> Scores { get; set; } = new List<Score>();


}