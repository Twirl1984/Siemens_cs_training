class BirdCount
{
    private int[] birdsPerDay;

    public BirdCount(int[] birdsPerDay)
    {
        this.birdsPerDay = birdsPerDay;
    }

    public static int[] LastWeek()
    {
        return new int[] { 0, 2, 5, 3, 7, 8, 4 };
    }

    public int Today()
    {
        //throw new NotImplementedException("Please implement the BirdCount.Today() method");
        return this.birdsPerDay[this.birdsPerDay.Length - 1];
    }

    public void IncrementTodaysCount()
    {
        this.birdsPerDay[this.birdsPerDay.Length - 1]++;
    }

    public bool HasDayWithoutBirds()
    {
        return Array.IndexOf(this.birdsPerDay, 0) != -1;
    }

    public int CountForFirstDays(int numberOfDays)
    {
 
        
        int count = 0;
        for (int i = 0; i < numberOfDays; i++)
        {
            count += this.birdsPerDay[i];
        }
        return count;

    }

    public int BusyDays()
    {
        int busyDays = 0;
        foreach (var count in this.birdsPerDay)
        {
            if (count >= 5)
            {
                busyDays++;
            }
        }
        return busyDays;
    }
}
