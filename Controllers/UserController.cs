using Microsoft.AspNetCore.Mvc;
using Telegram.Bot;
using Telegram.Bot.Exceptions;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace EcosystemSmartHome.Controllers;
[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpGet(Name = "PushNotifications")]
    public async Task<ActionResult> SendPushNotification()
    {
        var botClient = new TelegramBotClient("5041589752:AAFdZmZ307q1qSOXLPQlRlBsCXNQemDJlQ4");
        using var cts = new CancellationTokenSource();
        Message sentMessage = await botClient.SendTextMessageAsync(
            chatId: 733758387,
            text: "Рівень СO2 перевищує норму",
            cancellationToken: cts.Token);
        
        cts.Cancel();
        return StatusCode(200);
    }
}