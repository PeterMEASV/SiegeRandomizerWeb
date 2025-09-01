using SiegeRandomizer.FakeDB;
using SiegeRandomizer.Models;

namespace SiegeRandomizer.Services;

public class CharacterService(FakeCharacterDB db)
{
    private List<Character> activeAttackers = new(db.Attackers);
    private List<Character> activeDefenders = new(db.Defenders);


    public List<Character> GetAllAttackers()
    {
        return db.Attackers;
    }

    public List<Character> GetAllDefenders()
    {
        return db.Defenders;
    }

    public CharacterResponse GetRandomAttacker()
    {
        if (activeAttackers.Count > 0)
        {
            var randomIndex = new Random().Next(0, activeAttackers.Count);
            var randomCharacter = activeAttackers[randomIndex];
            activeAttackers.RemoveAt(randomIndex);
            
            
            CharacterResponse response = new CharacterResponse
            {
                Character = randomCharacter,
                Message = $"Attacker selected. Remaining Attacker(s): {activeAttackers.Count}/{db.Attackers.Count}"
            };
            return response;
        }
        else
        {
            ResetActiveAttackers();
            var randomIndex = new Random().Next(0, activeAttackers.Count);
            var randomCharacter = activeAttackers[randomIndex];
            activeAttackers.RemoveAt(randomIndex);
            CharacterResponse response = new CharacterResponse
            {
                Character = randomCharacter, Message = $"List Reset. Attacker selected. Remaining Attacker(s): {activeAttackers.Count}/{db.Attackers.Count}" 
            };
            return response;
            
        }
    }
    
    public CharacterResponse GetRandomDefender()
    {
        if (activeDefenders.Count > 0)
        {
            var randomIndex = new Random().Next(0, activeDefenders.Count);
            var randomCharacter = activeDefenders[randomIndex];
            activeDefenders.RemoveAt(randomIndex);
            CharacterResponse response = new CharacterResponse { Character = randomCharacter, Message = $"Defender selected. Remaining Defender(s): {activeDefenders.Count}/{db.Defenders.Count}" };
            return response;
        }
        else
        {
            ResetActiveDefenders();
            var randomIndex = new Random().Next(0, activeDefenders.Count);
            var randomCharacter = activeDefenders[randomIndex];
            activeDefenders.RemoveAt(randomIndex);
            CharacterResponse response = new CharacterResponse { Character = randomCharacter, Message = $"List Reset. Defender selected. Remaining Defender(s): {activeDefenders.Count}/{db.Defenders.Count}" };
            return response;
            
        }
    }
    


    private void ResetActiveAttackers()
    {
        activeAttackers = new(db.Attackers);
    }
    
    private void ResetActiveDefenders()
    {
        activeDefenders = new(db.Defenders);
    }
}