using ecosystem_smart_home_rest_api;
using NCrontab;

namespace EcosystemSmartHome.Service;

public class ClearDbService: BackgroundService
{
    private CrontabSchedule _schedule;
    private DateTime _nextRun;
    private readonly IServiceScopeFactory _scopeFactory;

    private  string Schedule => "0 0 1 */2 *"; //Runs every 10 seconds

    public ClearDbService( IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
        _schedule = CrontabSchedule.Parse(Schedule,new CrontabSchedule.ParseOptions { IncludingSeconds = true });
        _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        do
        {
            var now = DateTime.Now;
            var nextrun = _schedule.GetNextOccurrence(now);
            if (now > _nextRun)
            {
                Process();
                _nextRun = _schedule.GetNextOccurrence(DateTime.Now);
            }
            await Task.Delay(5000, stoppingToken); //5 seconds delay
        }
        while (!stoppingToken.IsCancellationRequested);
    }

    private void Process()
    {
        using (var scope = _scopeFactory.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<SmartHomeContext>();
            var toDelete = context.RoomInfo
                .Where(r => r.DateLastCheckState.ToLocalTime() <= DateTime.Now.AddMonths(-2))
                .ToList();

            context.RoomInfo.RemoveRange(toDelete);
            
            context.SaveChanges();
        }
    }
}