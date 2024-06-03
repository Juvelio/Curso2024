namespace MiApp.Views;

public partial class IMCPage : ContentPage
{
    public IMCPage()
    {
        InitializeComponent();
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        var altura = Convert.ToDouble(txtTalla.Text);
        var peso = Convert.ToDouble(txtPeso.Text);

        var imc = peso / (altura * altura);

        string resultado = "";

        if (imc < 18.5)
        {
            resultado = "Tienes bajo peso";
        }
        else if (imc >= 18.5 && imc <= 24.9)
        {
            resultado = "Tienes un peso normal";
        }
        else if (imc >= 25 && imc <= 29.9)
        {
            resultado = "Tienes sobrepeso";
        }
        else
        {
            resultado = "Tienes obesidad.";
        }

        Shell.Current.DisplayAlert("Resultado", resultado, "OK");

    }
}