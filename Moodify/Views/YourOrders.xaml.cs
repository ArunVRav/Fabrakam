using Moodify.DataModels;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;

using Xamarin.Forms;
using System.Collections.ObjectModel;

namespace Moodify
{
	public partial class YourOrders : ContentPage
	{
		public YourOrders()
		{
			InitializeComponent();
            GetOrder();
            Title = "Your Orders";
		}
        public void GetOrder()
        {
            ObservableCollection<Food> specMenu = new ObservableCollection<Food> { };
            specMenu = Menus.FullMenu;
            ListView.ItemsSource = Menus.FullMenu;
           
        }
        public async void MakeOrder(Object sender,EventArgs e)
        {
            var answer = await DisplayAlert("Get Order?", "Would you like to confirm your order?", "Yes", "No");
            if (answer == true)
            {
                await DisplayAlert("Great!", "Your order will be ready in 15 minutes, would you like to favourite this order?", "Sure!","No thanks!");
            }
        }
    }
}
