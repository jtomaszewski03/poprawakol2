using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace poprawa.Models;

[PrimaryKey(nameof(CharacterId), nameof(ItemId))]
public class Backpack
{
    [ForeignKey(nameof(CharacterId))]
    public int CharacterId { get; set; }
    [ForeignKey(nameof(ItemId))]
    public int ItemId { get; set; }
    public int Amount { get; set; }

    public Character Character { get; set; } = null!;
    public Item Item { get; set; } = null!;
}