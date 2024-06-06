using System.Collections.ObjectModel;

namespace MiApp
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<CarouselItem> Items { get; set; }

        int count = 0;

        public MainPage()
        {
            InitializeComponent();

            Items = new ObservableCollection<CarouselItem>
            {
                new CarouselItem { Titulo = "Web APIs RESTful con ASP.NET", Image = "image1.jpg" ,
                    Descripcion="Los Web APIs son fundamentales en el desarrollo web moderno. Ya que nos permiten centralizar y proteger la lógica de nuestras soluciones."},
                new CarouselItem { Titulo = ".NET Multi-platform App UI", Image = "image2.jpg",
                    Descripcion=".NET MAUI, es el potente framework de Microsoft para crear aplicaciones multiplataforma, es decir, aplicaciones para Android, iOS, Windows y MacOS, creando el código una sola vez, y pudiendo desplegarlo en múltiples plataformas."},
                new CarouselItem { Titulo = "Y mucho mas ....", Image = "image3.jpg" ,
                    Descripcion="Mis especialidades incluyen Desarrollo Web, ASP.NET Core & MVC, Entity Framework Core, SQL Server, Javascript, Angular, WPF, Desarrollo Móvil Android y Xamarin. Soy un programador apasionado al que le encanta resolver problemas y automatizar tareas."}
            };

            BindingContext = this;
        }

        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            //if (count == 1)
            //    CounterBtn.Text = $"Clicked {count} time";
            //else
            //    CounterBtn.Text = $"Clicked {count} times";

            //SemanticScreenReader.Announce(CounterBtn.Text);
        }

        private void OnOtherButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnClearButtonClicked(object sender, EventArgs e)
        {

        }

        private void OnOperatorButtonClicked(object sender, EventArgs e)
        {

        }

        private async void btnRepositorio_Clicked(object sender, EventArgs e)
        {
            //await Browser.OpenAsync(new Uri("https://github.com/Juvelio/Curso2024"), BrowserLaunchMode.SystemPreferred);
            await Browser.OpenAsync(new Uri("https://github.com/Juvelio/Curso2024"));
        }
    }

    public class CarouselItem
    {
        public string Titulo { get; set; }
        public string Descripcion { get; set; }

        public string Image { get; set; }
    }

}
