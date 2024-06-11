using MiApp.Models;
using MiApp.Repositorios;

namespace MiApp.Views;

public partial class CitasPage : ContentPage
{
    private readonly RepositorioCita _Servicio;

    public CitasPage()
    {
        InitializeComponent();
        
        this.BindingContext = this;
        _Servicio = new RepositorioCita();
    }
    protected override void OnAppearing()
    {
        base.OnAppearing();
        ListarCitas();
    }
    private async void ListarCitas()
    {
       var Citas = await _Servicio.GetCitas("https://sws.policia.gob.pe/curso/api/v1/Citas");
        ColeccionCitas.ItemsSource = Citas;
    }

    private async void GuardarDatos()
    {
      //await _Servicio.GuardarDatos("", null);
      //  ColeccionCitas.ItemsSource = Citas;
    }
}