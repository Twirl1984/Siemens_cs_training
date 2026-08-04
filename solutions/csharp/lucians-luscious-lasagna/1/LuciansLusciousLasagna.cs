class Lasagna
{
    // TODO: define the 'ExpectedMinutesInOven()' method
    public int ExpectedMinutesInOven() => 40;

    // TODO: define the 'RemainingMinutesInOven()' method
    public int RemainingMinutesInOven(int actualMinutesInOven) => ExpectedMinutesInOven() - actualMinutesInOven;

    // TODO: define the 'PreparationTimeInMinutes()' method
    public int PreparationTimeInMinutes(int actualNumberOfLayers) => actualNumberOfLayers * 2;
    // TODO: define the 'ElapsedTimeInMinutes()' method
    public int ElapsedTimeInMinutes(int actualNumberOfLayers, int actualMinutesInOven) => actualNumberOfLayers*2+actualMinutesInOven;
}
