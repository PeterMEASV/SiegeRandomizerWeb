namespace SiegeRandomizer.Models;

public class Character
{
    public string Name { get; set; }
    public List<string> PrimaryWeapons { get; set; } = new();
    public List<string> SecondaryWeapons { get; set; } = new();
    public List<string> Gadgets { get; set; } = new();
    public string ImageURL { get; set; }
    
}