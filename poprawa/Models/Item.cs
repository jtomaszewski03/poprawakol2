using System.ComponentModel.DataAnnotations;

namespace poprawa.Models;

public class Item
{
    [Key]
    public int ItemId { get; set; }

    [MaxLength(100)] public string Name { get; set; } = null!;
    public int Weight { get; set; }

    public ICollection<Backpack> Backpacks { get; set; } = new List<Backpack>();
}