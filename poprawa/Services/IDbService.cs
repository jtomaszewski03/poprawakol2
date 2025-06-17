using poprawa.DTOs;

namespace poprawa.Services;

public interface IDbService
{
    public Task<CharacterDto> GetCharacterWithDetailsAsync(int characterId);
    public Task AddItemsToBackpackAsync(int characterId, List<int> itemsIds);

}