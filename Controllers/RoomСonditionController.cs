using Microsoft.AspNetCore.Mvc;
using ecosystem_smart_home_rest_api;
namespace EcosystemSmartHome.Controllers;


[ApiController]
[Route("[controller]")]
public class RoomСonditionController : ControllerBase
{
    private readonly SmartHomeContext _context;
    public RoomСonditionController(SmartHomeContext context)
    {
         _context = context;
    }
    
    [HttpGet("GetRoomState")]
    public RoomInfo GetRoomState()
    {
        return _context.RoomInfo.OrderBy(info => info.DateLastCheckState).Last();
    }
    
    [HttpGet("GetRoomStatistic")]
    public List<RoomInfo> GetRoomStatistic()
    {
        return _context.RoomInfo.OrderBy(info => info.DateLastCheckState).ToList();
    }

    
    
    [HttpPost]
    public IActionResult PostRoomState(RoomInfoDto roomInfo)
    {
        var info = new RoomInfo
            {
                Humidity = roomInfo.Humidity,
                Temperature = roomInfo.Temperature,
                Luminosity = roomInfo.Luminosity,
                Pressure = roomInfo.Pressure,
                DateLastCheckState = DateTime.Now.ToUniversalTime()
            };
            _context.Add(info);
            _context.SaveChanges();
            return StatusCode(200);
    }
    
    
}