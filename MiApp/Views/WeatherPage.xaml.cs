namespace MiApp.Views;

public partial class WeatherPage : ContentPage
{
	public WeatherPage()
	{
		InitializeComponent();
        this.BindingContext = this;
    }

    public List<Weather> Weathers { get => WeatherData(); }

    private List<Weather> WeatherData()
    {
        var tempList = new List<Weather>();
        tempList.Add(new Weather { Temp = "22", Date = "Domingo 02", Icon = "weather.png" });
        tempList.Add(new Weather { Temp = "21", Date = "Lunnes 03", Icon = "weather.png" });
        tempList.Add(new Weather { Temp = "20", Date = "Martes 04", Icon = "weather.png" });
        tempList.Add(new Weather { Temp = "12", Date = "Miercoles 05", Icon = "weather.png" });
        tempList.Add(new Weather { Temp = "17", Date = "Jueves 06", Icon = "weather.png" });
        tempList.Add(new Weather { Temp = "20", Date = "Viernes 07", Icon = "weather.png" });

        return tempList;
    }
}

public class Weather
{
    public string Temp { get; set; }
    public string Date { get; set; }
    public string Icon { get; set; }
}
