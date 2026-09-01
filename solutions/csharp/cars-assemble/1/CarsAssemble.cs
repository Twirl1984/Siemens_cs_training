static class AssemblyLine
{
    private const int BaseCarsPerHour = 221;

    public static double SuccessRate(int speed)
    {
        return speed switch
        {
            0 => 0.0,
            >= 1 and <= 4 => 1.0,
            >= 5 and <= 8 => 0.9,
            9 => 0.8,
            10 => 0.77,
            _ => 0.0
        };
    }
    
    public static double ProductionRatePerHour(int speed)
    {
        return speed * BaseCarsPerHour * SuccessRate(speed);
    }

    public static int WorkingItemsPerMinute(int speed)
    {
        // Truncate to whole items per minute (discard fractional items)
        return (int)(ProductionRatePerHour(speed) / 60);
    }
}
