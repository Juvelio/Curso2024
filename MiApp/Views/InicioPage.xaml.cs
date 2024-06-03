namespace MiApp.Views;

public partial class InicioPage : ContentPage
{
    public InicioPage()
    {
        InitializeComponent();
    }

    private async void btnContinuar_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"{nameof(IMCPage)}");
    }
}