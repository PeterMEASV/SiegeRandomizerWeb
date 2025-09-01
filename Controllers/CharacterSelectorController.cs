using Microsoft.AspNetCore.Mvc;
using SiegeRandomizer.Models;
using SiegeRandomizer.Services;

namespace SiegeRandomizer.Controllers;


[ApiController]
[Route("[action]")]
public class CharacterSelectorController(CharacterService service) : ControllerBase
{
    
    [HttpGet]
    public List<Character> GetAttackers()
    {
        return service.GetAllAttackers();
    }
    
    [HttpGet]
    public List<Character> GetDefenders()
    {
        return service.GetAllDefenders();
    }
    
    [HttpGet]
    public ActionResult<Character> GetRandomAttacker()
    {
        CharacterResponse response = service.GetRandomAttacker();
        return Ok(response);
    }
    
    [HttpGet]
    public ActionResult<Character> GetRandomDefender()
    {
        CharacterResponse response = service.GetRandomDefender();
        return Ok(response);
    }

    [HttpGet]
    public ActionResult RefreshAttackers()
    {
        service.ResetActiveAttackers();
        return Ok();
    }
    [HttpGet]
    public ActionResult RefreshDefenders()
    {
        service.ResetActiveDefenders();
        return Ok();
    }
    
        
        


}

    
