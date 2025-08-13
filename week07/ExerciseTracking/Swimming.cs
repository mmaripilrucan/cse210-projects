public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int minutes, int laps)
        : base(date, minutes)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        
        return _laps * 50 / 1000 * 0.62;
    }

    public override string GetSummary()
    {
        return $"{Date.ToString("dd MMM yyyy")} {GetType().Name} ({Minutes} min) - " +
               $"Distance: {GetDistance():F1} miles, Speed: {GetSpeed():F1} mph, " +
               $"Pace: {GetPace():F1} min per mile, Laps: {_laps}";
    }
}