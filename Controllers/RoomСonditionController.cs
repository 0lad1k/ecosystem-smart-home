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
    
    [HttpGet("GetRoomStatisticByCurrentMonth")]
    public List<RoomInfo> GetRoomStatisticByCurrentMonth()
    {
        DateTime currentDate = DateTime.Now;
        return _context.RoomInfo.OrderBy(info => info.DateLastCheckState)
            .Where(date => date.DateLastCheckState.Month == currentDate.Month 
                           && currentDate.Year == date.DateLastCheckState.Year)
            .ToList();
    }
    
    [HttpGet("GetRoomStatisticByWeek")]
    public List<RoomInfo> GetRoomStatisticByWeek()
    {
        DateTime currentDate = DateTime.Now;
        return _context.RoomInfo.OrderBy(info => info.DateLastCheckState)
            .Where(date => date.DateLastCheckState.Month == currentDate.Month 
                           && currentDate.Year == date.DateLastCheckState.Year && date.DateLastCheckState.Day >  currentDate.Day - 7)
            .ToList();
    }
    
    [HttpGet("GetRoomStatisticToday")]
    public List<RoomInfo> GetRoomStatisticToday()
    {
        DateTime currentDate = DateTime.Now;
        return _context.RoomInfo.OrderBy(info => info.DateLastCheckState)
            .Where(date => date.DateLastCheckState.Month == currentDate.Month 
                           && currentDate.Year == date.DateLastCheckState.Year 
                           && currentDate.Day == date.DateLastCheckState.Day)
            .ToList();
    }
    
    [HttpGet("GetRoomStatisticByLastMonth")]
    public List<RoomInfo> GetRoomStatisticByLastMonth()
    {
        DateTime currentDate = DateTime.Now;
        return _context.RoomInfo.OrderBy(info => info.DateLastCheckState)
            .Where(date => date.DateLastCheckState.Month == currentDate.AddMonths(-1).Month 
                           && currentDate.Year == date.DateLastCheckState.Year)
            .ToList();
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