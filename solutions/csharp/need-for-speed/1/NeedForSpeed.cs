class RemoteControlCar
{
    private readonly int speed;
    private readonly int batteryDrain;

    private int batteryCapacityPercentage = 100;

    private int distanceDriven = 0;
    public RemoteControlCar(int speed, int batteryDrain)
    {
        if (speed <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(speed), "Speed must be greater than zero.");
        }

        if (batteryDrain <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(batteryDrain), "Battery drain must be greater than zero.");
        }

        this.speed = speed;
        this.batteryDrain = batteryDrain;
    }

    public bool BatteryDrained()
    {
        return batteryCapacityPercentage < batteryDrain;
    }

    public int DistanceDriven()
    {
        return distanceDriven;
    }

    public void Drive()
    {
        if (!this.BatteryDrained())
        {
            checked
            {
                distanceDriven += speed;
            }

            batteryCapacityPercentage -= batteryDrain;
        }
    }

    public static RemoteControlCar Nitro()
    {
        return new RemoteControlCar(50, 4);
    }

    public bool CanFinishTrack(int trackDistance)
    {
        if (trackDistance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(trackDistance), "Track distance cannot be negative.");
        }

        var drivesPossible = batteryCapacityPercentage / batteryDrain;
        var maximumDistance = (long)drivesPossible * speed;

        return maximumDistance >= trackDistance;
    }
}

class RaceTrack
{
    private readonly int distance;

    public RaceTrack(int distance)
    {
        if (distance < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(distance), "Track distance cannot be negative.");
        }

        this.distance = distance;
    }

    public bool TryFinishTrack(RemoteControlCar car)
    {
        ArgumentNullException.ThrowIfNull(car);

        return car.CanFinishTrack(this.distance);
    }
}
