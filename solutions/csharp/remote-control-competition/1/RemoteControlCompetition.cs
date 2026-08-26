// TODO implement the IRemoteControlCar interface
public interface IRemoteControlCar
{
    int DistanceTravelled { get; }
    int NumberOfVictories { get; set; }
    void Drive();
    
}
public class ProductionRemoteControlCar : IRemoteControlCar, System.IComparable<ProductionRemoteControlCar>
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 10;
    }

    public int CompareTo(ProductionRemoteControlCar other)
    {
        return this.NumberOfVictories.CompareTo(other.NumberOfVictories);
    }
}

public class ExperimentalRemoteControlCar : IRemoteControlCar
{
    public int DistanceTravelled { get; private set; }
    public int NumberOfVictories { get; set; }

    public void Drive()
    {
        DistanceTravelled += 20;
    }
}

public static class TestTrack
{
    public static void Race(IRemoteControlCar car)
    {
        car.Drive();
    }

    public static List<ProductionRemoteControlCar> GetRankedCars(ProductionRemoteControlCar prc1,
        ProductionRemoteControlCar prc2)
    {
        var cars = new List<ProductionRemoteControlCar> { prc1, prc2 };
        cars.Sort();
        return cars;
    }
}
