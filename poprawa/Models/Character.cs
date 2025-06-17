using System.ComponentModel.DataAnnotations;

namespace poprawa.Models;

public class Character
{
    [Key]
    public int CharacterId { get; set; }

    [MaxLength(50)] public string FirstName { get; set; } = null!;
    [MaxLength(120)] public string LastName { get; set; } = null!;
    public int CurrentWeight { get; set; }
    public int MaxWeight { get; set; }
    
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new List<CharacterTitle>();
    public ICollection<Backpack> Backpacks { get; set; } = new List<Backpack>();
}