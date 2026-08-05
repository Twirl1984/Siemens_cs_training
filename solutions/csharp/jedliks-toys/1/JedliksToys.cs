class RemoteControlCar
{
    private int _metersDriven=0;
    private int _percentageBattery=100;

    public static RemoteControlCar Buy()
    {
        return new RemoteControlCar();
    }

    public string DistanceDisplay()
    {
        return $"Driven {_metersDriven} meters";
    }

    public string BatteryDisplay()
    {
        if(_percentageBattery>0)
            return $"Battery at {_percentageBattery}%";
        else
            return "Battery empty";

    }

    public void Drive()
    {
        //throw new NotImplementedException("Please implement the RemoteControlCar.Drive() method");
        if(_percentageBattery>0)
        {
            _metersDriven+=20;
            _percentageBattery-=1;
        }   
    }
}
