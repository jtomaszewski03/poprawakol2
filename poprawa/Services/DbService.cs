using Microsoft.EntityFrameworkCore;
using poprawa.Data;
using poprawa.DTOs;
using poprawa.Exceptions;
using poprawa.Models;

namespace poprawa.Services;

public class DbService : IDbService
{
    private readonly DatabaseContext _context;

    public DbService(DatabaseContext context)
    {
        _context = context;
    }

    public async Task<CharacterDto> GetCharacterWithDetailsAsync(int characterId)
    {
        var character = await _context.Characters.Where(c => c.CharacterId == characterId)
            .Select(e => new CharacterDto
        {
            FirstName = e.FirstName,
            LastName = e.LastName,
            CurrentWeight = e.CurrentWeight,
            MaxWeight = e.MaxWeight,
            BackpackItems = e.Backpacks.Select(b => new BackpackItemDto
            {
                ItemName = b.Item.Name,
                ItemWeight = b.Item.Weight,
                Amount = b.Amount,
            }).ToList(),
            Titles = e.CharacterTitles.Select(c => new TitleDto
            {
                Title = c.Title.Name,
                AcquiredAt = c.AcquiredAt,
            }).ToList()
        }).FirstOrDefaultAsync();
        
        if (character == null) throw new NotFoundException("Character not found");
        return character;
    }

    public async Task AddItemsToBackpackAsync(int characterId, List<int> itemsIds)
    {
        await using var transaction = await _context.Database.BeginTransactionAsync();
        try
        {
            var character = await _context.Characters.FirstOrDefaultAsync(c => c.CharacterId == characterId);
            if (character == null) throw new NotFoundException("Character not found");
            int weightSum = character.CurrentWeight;
            foreach (var itemId in itemsIds)
            {
                var item = await _context.Items.FirstOrDefaultAsync(i => i.ItemId == itemId);
                if (item == null) throw new NotFoundException("Item not found");
                weightSum += item.Weight;
                if (weightSum > character.MaxWeight) throw new InvalidOperationException("Maximum character weight reached");
                var backpack = await _context.Backpacks.FirstOrDefaultAsync(b => b.ItemId == item.ItemId && b.CharacterId == character.CharacterId);
                if (backpack == null)
                {
                    var backpackWithItem = new Backpack()
                    {
                        Item = item,
                        Character = character,
                        Amount = 1
                    };
                    await _context.Backpacks.AddAsync(backpackWithItem);
                }
                else backpack.Amount++;
            }
            character.CurrentWeight = weightSum;
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }
        catch (Exception)
        {
            await transaction.RollbackAsync();
            throw;
        }
    }
}