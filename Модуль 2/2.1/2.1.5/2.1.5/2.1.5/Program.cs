class TemperatureSensor
{
    public double temperature;

    public event EventHandler<double> TemperatureChanged;

    public double Temperature
    {
        get { return temperature; }
        set { if (temperature != value) 
            {
            temperature = value;
                TemperatureChanged?.Invoke(this, temperature);
            }; }


    }

}

class Thermostat
{
    public double line = 22;

    public void OnTemperatureChanged(object sender, double NewTemp)
    {
        if (NewTemp < line)
        {
            Console.WriteLine($"{NewTemp}C - включение отопление");
        }
        else
        {
            Console.WriteLine($"{NewTemp}C - выключение отопления");
        }
    }
}

class Program()
{
    static void Main()
    {
        TemperatureSensor sensor = new TemperatureSensor();
        Thermostat thermostat = new Thermostat();

        sensor.TemperatureChanged += thermostat.OnTemperatureChanged;

        sensor.Temperature = 20.2;
        sensor.Temperature = -14.7;
        sensor.Temperature = 25.9;
        sensor.Temperature = 32;
    }
    
}