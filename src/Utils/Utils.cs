namespace SimpleAutoClicker.Utils;

public static class Utils
{
    public static int? ReadIntInput()
    {
        var value = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(value))
        {
            return null;
        }

        if (!int.TryParse(value, out int result))
        {
            Console.WriteLine("Invalid input. Please enter a valid integer.");
            return ReadIntInput();
        }

        return result;
    }

    public static string Beautify(this TimeSpan timeLeft)
    {
        var hours = timeLeft.Hours;
        var minutes = timeLeft.Minutes;
        var seconds = timeLeft.Seconds;

        return $"{hours}h {minutes}m {seconds}s";
    }
}