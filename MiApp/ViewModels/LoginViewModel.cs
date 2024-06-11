using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MiApp.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private bool isPassword = true;
        public bool IsPassword
        {
            get => isPassword;
            set => SetProperty(ref isPassword, value);
        }

        public Command LoginCommand { get; }
        public Command RegisterCommand { get; }
        public ICommand IsPasswordCommand => new Command(() => IsPassword = !IsPassword);


        public LoginViewModel()
        {
            LoginCommand = new Command(OnLoginClicked);
            RegisterCommand = new Command(onRegistrar);
        }

        private async void OnLoginClicked(object obj)
        {
            //// Prefixing with `//` switches to a different navigation stack instead of pushing to the active one


            //aqui va toda la logica de autenticacion
            await Application.Current.MainPage.DisplayAlert("Alerta", "Cualquier mensaje", "Ok");

        }


        private async void onRegistrar(object obj)
        {
            //await Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
    }
}
