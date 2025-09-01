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

            SelectedCharacter selectedCharacter = new SelectedCharacter { 
                Primary = randomCharacter.PrimaryWeapons[new Random().Next(0, randomCharacter.PrimaryWeapons.Count)], 
                Secondary = randomCharacter.SecondaryWeapons[new Random().Next(0, randomCharacter.SecondaryWeapons.Count)], 
                Gadget = randomCharacter.Gadgets[new Random().Next(0, randomCharacter.Gadgets.Count)],
                Name = randomCharacter.Name,
                ImageURL = randomCharacter.ImageURL
            };
            
            
            
            CharacterResponse response = new CharacterResponse
            {
                Character = selectedCharacter,
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
            
            SelectedCharacter selectedCharacter = new SelectedCharacter { 
                Primary = randomCharacter.PrimaryWeapons[new Random().Next(0, randomCharacter.PrimaryWeapons.Count)], 
                Secondary = randomCharacter.SecondaryWeapons[new Random().Next(0, randomCharacter.SecondaryWeapons.Count)], 
                Gadget = randomCharacter.Gadgets[new Random().Next(0, randomCharacter.Gadgets.Count)],
                Name = randomCharacter.Name,
                ImageURL = randomCharacter.ImageURL
            };
            
            CharacterResponse response = new CharacterResponse
            {
                Character = selectedCharacter, Message = $"List Reset. Attacker selected. Remaining Attacker(s): {activeAttackers.Count}/{db.Attackers.Count}" 
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
            
            SelectedCharacter selectedCharacter = new SelectedCharacter { 
                Primary = randomCharacter.PrimaryWeapons[new Random().Next(0, randomCharacter.PrimaryWeapons.Count)], 
                Secondary = randomCharacter.SecondaryWeapons[new Random().Next(0, randomCharacter.SecondaryWeapons.Count)], 
                Gadget = randomCharacter.Gadgets[new Random().Next(0, randomCharacter.Gadgets.Count)],
                Name = randomCharacter.Name,
                ImageURL = randomCharacter.ImageURL
            };
            
            CharacterResponse response = new CharacterResponse { Character = selectedCharacter, Message = $"Defender selected. Remaining Defender(s): {activeDefenders.Count}/{db.Defenders.Count}" };
            return response;
        }
        else
        {
            ResetActiveDefenders();
            var randomIndex = new Random().Next(0, activeDefenders.Count);
            var randomCharacter = activeDefenders[randomIndex];
            activeDefenders.RemoveAt(randomIndex);
            
            SelectedCharacter selectedCharacter = new SelectedCharacter { 
                Primary = randomCharacter.PrimaryWeapons[new Random().Next(0, randomCharacter.PrimaryWeapons.Count)], 
                Secondary = randomCharacter.SecondaryWeapons[new Random().Next(0, randomCharacter.SecondaryWeapons.Count)], 
                Gadget = randomCharacter.Gadgets[new Random().Next(0, randomCharacter.Gadgets.Count)],
                Name = randomCharacter.Name,
                ImageURL = randomCharacter.ImageURL
            };
            
            CharacterResponse response = new CharacterResponse { Character = selectedCharacter, Message = $"List Reset. Defender selected. Remaining Defender(s): {activeDefenders.Count}/{db.Defenders.Count}" };
            return response;
            
        }
    }
    


    public void ResetActiveAttackers()
    {
        activeAttackers = new(db.Attackers);
    }
    
    public void ResetActiveDefenders()
    {
        activeDefenders = new(db.Defenders);
    }
}