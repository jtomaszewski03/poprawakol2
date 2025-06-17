using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace poprawa.Models;

[PrimaryKey(nameof(CharacterId), nameof(TitleId))]
public class CharacterTitle
{
    [ForeignKey(nameof(TitleId))]
    public int TitleId { get; set; }
    [ForeignKey(nameof(CharacterId))]
    public int CharacterId { get; set; }
    public DateTime AcquiredAt { get; set; }

    public Character Character { get; set; } = null!;
    public Title Title { get; set; } = null!;
}