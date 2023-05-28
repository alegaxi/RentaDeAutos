using Microsoft.Maui.Controls.Maps;
using Microsoft.Maui.Maps;
using System.Text;
using System.Text.Json;
using System.Device.Location;
using System.Net.Http;

namespace Prueba2;

public partial class UbicacionPage : ContentPage
{
	public UbicacionPage()
	{
		InitializeComponent();
        //Creacion de pines
        Pin pin = new Pin
        {
            Label = "Renta de Carros Flor",
            Address = "Renta variada de carros",
            Type = PinType.Place,
            Location = new Location(25.5730820, -108.4712446)
        };
        map.Pins.Add(pin);

        Pin pin2 = new Pin
        {
            Label = "Renta de Carros Flor",
            Address = "Renta variada de carros",
            Type = PinType.Place,
            Location = new Location(25.5707916, -108.4726501)
        };
        map.Pins.Add(pin2);

        Pin pin3 = new Pin
        {
            Label = "Renta de Carros Flor",
            Address = "Renta variada de carros",
            Type = PinType.Place,
            Location = new Location(25.5768587, -108.4725226)
        };
        map.Pins.Add(pin3);

        //Creacion de radios
        Circle circle = new Circle
        {
            Center = new Location(25.5730820, -108.4712446),
            Radius = new Distance(180),
            StrokeColor = Color.FromArgb("#88FF0000"),
            StrokeWidth = 8,
            FillColor = Color.FromArgb("#88FFC0CB")
        };
        map.MapElements.Add(circle);

        Circle circle2 = new Circle
        {
            Center = new Location(25.5707916, -108.4726501),
            Radius = new Distance(180),
            StrokeColor = Color.FromArgb("#88FF0000"),
            StrokeWidth = 8,
            FillColor = Color.FromArgb("#88FFC0CB")
        };
        map.MapElements.Add(circle2);

        Circle circle3 = new Circle
        {
            Center = new Location(25.5768587, -108.4725226),
            Radius = new Distance(180),
            StrokeColor = Color.FromArgb("#88FF0000"),
            StrokeWidth = 8,
            FillColor = Color.FromArgb("#88FFC0CB")
        };
        map.MapElements.Add(circle3);

        //Creacion de rutas
        Polygon polygon1 = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromArgb("#1BA1E2"),
            FillColor = Color.FromArgb("#881BA1E2"),
            Geopath =
            {
                new Location(25.5730820, -108.4712446),
                new Location(25.5707916, -108.4726501),
             }
        };
        map.MapElements.Add(polygon1);

        Polygon polygon2 = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromArgb("#1BA1E2"),
            FillColor = Color.FromArgb("#881BA1E2"),
            Geopath =
            {
                new Location(25.5707916, -108.4726501),
                new Location(25.5768587, -108.4725226),
             }
        };
        map.MapElements.Add(polygon2);

        Polygon polygon3 = new Polygon
        {
            StrokeWidth = 8,
            StrokeColor = Color.FromArgb("#1BA1E2"),
            FillColor = Color.FromArgb("#881BA1E2"),
            Geopath =
            {
                new Location(25.5730820, -108.4712446),
                new Location(25.5768587, -108.4725226),
             }
        };
        map.MapElements.Add(polygon3);

    }
}