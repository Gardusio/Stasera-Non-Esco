using StaseraNonEsco.Models;
using StaseraNonEsco.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StaseraNonEsco.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class CartPage : ContentPage
    {
        public ObservableCollection<ShoppingCartItem> ShoppingCartCollection;
        public CartPage()
        {
            InitializeComponent();
            ShoppingCartCollection = new ObservableCollection<ShoppingCartItem>();
            GetShoppingCartItems();
            GetTotalPrice();
        }

        private async void GetTotalPrice()
        {
            var totalPrice = await ApiService.GetCartSubTotal(Preferences.Get("userId", 0));
            LblTotalPrice.Text = totalPrice.subTotal.ToString();
        }

        private async void GetShoppingCartItems()
        {
            var shoppingCartItems = await ApiService.GetShoppingCartItems(Preferences.Get("userId", 0));
            foreach (var shoppingCart in shoppingCartItems)
            {
                ShoppingCartCollection.Add(shoppingCart);
            }
            LvShoppingCart.ItemsSource = ShoppingCartCollection;
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }

        private async void TapClearCart_Tapped(object sender, EventArgs e)
        {
            var response = await ApiService.ClearShoppingCart(Preferences.Get("userId", 0));
            if (response)
            {
                await DisplayAlert("", "Il carrello è ora vuoto", "Ok");
                LvShoppingCart.ItemsSource = null;
                LblTotalPrice.Text = "0";
            }
            else
            {
                await DisplayAlert("", "Sono occupato ora...prova tra poco", "Ok");
            }
        }

        private async void BtnProceed_Clicked(object sender, EventArgs e)
        {
            if (LblTotalPrice.Text.ToString().Equals("0")) {
                await DisplayAlert("Carrello vuoto", "Non accettiamo ordini a vuoto!", "Ok");
            }
            else {
                Navigation.PushModalAsync(new PlaceOrderPage(Convert.ToDouble(LblTotalPrice.Text)));
            }
        }

        private void LvShoppingCart_ItemSelected(object sender, SelectedItemChangedEventArgs e) {

        }
    }
}