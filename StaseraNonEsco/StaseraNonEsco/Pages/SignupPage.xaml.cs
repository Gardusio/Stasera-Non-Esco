using StaseraNonEsco.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StaseraNonEsco.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SignupPage : ContentPage
    {
        public SignupPage()
        {
            InitializeComponent();
        }

        private async void BtnSignUp_Clicked(object sender, EventArgs e)
        {
            if (!EntPassword.Text.Equals(EntConfirmPassword.Text))
            {
                await DisplayAlert("Le password non coincidono!", "Controlla di nuovo i dati", "Cancella");
            }
            else
            {
                var response = await ApiService.RegisterUser(EntName.Text, EntEmail.Text, EntPassword.Text);
                if (response)
                {
                    await DisplayAlert("Ciao", "Sei pronto per ordinare e rimanere a casa!", "Ok");
                    await Navigation.PushModalAsync(new LoginPage());
                }
                else
                {
                    await DisplayAlert("Oops", "Questa email è gia in uso!", "Cancella");
                }
            }
        }


        private async void BtnLogin_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new LoginPage());
        }
    }
}