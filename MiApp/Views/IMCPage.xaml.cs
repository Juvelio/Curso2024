namespace MiApp.Views;

public partial class IMCPage : ContentPage
{
    public IMCPage()
    {
        InitializeComponent();

        var nombre = Preferences.Default.Get("Nombre", string.Empty);
        lblNombre.Text = $"Hola, {nombre}";
    }

    private void Button_Clicked(object sender, EventArgs e)
    {
        // Validar la entrada de texto para evitar errores de conversión
        if (double.TryParse(txtTalla.Text, out double altura) && double.TryParse(txtPeso.Text, out double peso))
        {
            // Verificar que la altura y el peso sean valores positivos
            if (altura > 0 && peso > 0)
            {
                // Calcular el IMC y redondearlo a un decimal
                var imc = Math.Round(peso / (altura * altura), 1);

                // Determinar el resultado basado en el IMC calculado
                string resultado;

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

                // Mostrar el resultado en una alerta
                Shell.Current.DisplayAlert($"Resultado IMC: {imc}", resultado, "OK");
            }
            else
            {
                // Mostrar una alerta si la altura o el peso son valores no positivos
                Shell.Current.DisplayAlert("Error", "Por favor, introduce valores positivos para la altura y el peso.", "OK");
            }
        }
        else
        {
            // Mostrar una alerta si la conversión de texto a número falla
            Shell.Current.DisplayAlert("Error", "Por favor, introduce valores numéricos válidos para la altura y el peso.", "OK");
        }
    }
}