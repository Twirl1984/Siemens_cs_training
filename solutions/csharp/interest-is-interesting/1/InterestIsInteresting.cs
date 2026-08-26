static class SavingsAccount
{
    public static float InterestRate(decimal balance)
    {
        float rate = balance switch
        {
             < 0m => 3.213f,
            < 1000m => 0.5f,
            >= 1000m and < 5000m => 1.621f,
            >= 5000m => 2.475f
        };
        return rate;
    }

    public static decimal Interest(decimal balance)
    {
        return (decimal)InterestRate(balance)/100m*balance;
    }

    public static decimal AnnualBalanceUpdate(decimal balance)
    {
        return balance+Interest(balance);
    }

    public static int YearsBeforeDesiredBalance(decimal balance, decimal targetBalance)
    {
        int years=0;
        while(balance<targetBalance)
        {
            balance=AnnualBalanceUpdate(balance);
            years+=1;
        }
        return years;
    }
}
