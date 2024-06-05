using MiApp.ViewModels;

namespace MiApp.Views;

public partial class CientificaPage : ContentPage
{
    public CientificaPage()
    {
        InitializeComponent();

        BindingContext = new CientificaViewModel();
    }
}