using System.ComponentModel.DataAnnotations;

namespace poprawa.Models;

public class Title
{
    [Key]
    public int TitleId { get; set; }

    [MaxLength(100)] public string Name { get; set; } = null!;
    public ICollection<CharacterTitle> CharacterTitles { get; set; } = new List<CharacterTitle>();
}