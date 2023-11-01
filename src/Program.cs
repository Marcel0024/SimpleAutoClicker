using SimpleAutoClicker.Utils;
using System.Reflection;

Console.Title = Assembly.GetExecutingAssembly().GetName().Name;
Console.WriteLine("Enter total runtime duration in minutes (blank for infinite):");

var totalDurationInMinutesInput = Utils.ReadIntInput();
var expirationDate = totalDurationInMinutesInput.HasValue 
    ? DateTime.Now.AddMinutes(totalDurationInMinutesInput.Value)
    : DateTime.MaxValue;
var interval = TimeSpan.FromSeconds(10);
var totalClicks = 0;

Console.WriteLine($"Total clicks: {totalClicks}");

using var timer = new PeriodicTimer(interval);

while (await timer.WaitForNextTickAsync() && DateTime.Now < expirationDate)
{
    Mouse.Click();

    totalClicks++;

    var timeLeft = totalDurationInMinutesInput.HasValue
        ? $"Time left: {(expirationDate - DateTime.Now).Beautify()}"
        : "";

    Console.SetCursorPosition(0, Console.CursorTop - 1);
    Console.WriteLine($"Total clicks: {totalClicks}. {timeLeft}");
}
