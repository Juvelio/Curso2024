using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace MiApp.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage()
    {
        InitializeComponent();
    }

    private async void btnContinuar_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrEmpty(txtNombre.Text))
        {
            var toast = Toast.Make("Ingrese nombre", ToastDuration.Short, 14);
            await toast.Show();
            return;
        }

        Preferences.Default.Set("Nombre", txtNombre.Text);
        await Shell.Current.GoToAsync($"{nameof(IMCPage)}");
    }
}