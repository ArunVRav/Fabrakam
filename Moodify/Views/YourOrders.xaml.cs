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
            TopText.Text = "Here are your favourite orders " + logins.Current;
            GetOrderList();
            Title = "Your Orders";
		}
        public async void GetOrderList()
        {
            var orderTot = await AzureManager.AzureManagerInstanceOrders.GetOrders();
            GetOrder(orderTot);


        }
        public async void MakeOrder(Object sender,EventArgs e)
        {
            var answer = await DisplayAlert("Get Order?", "Would you like to confirm your order?", "Yes", "No");
            if (answer == true)
            {
                await DisplayAlert("Great!", "Your order will be ready in 15 minutes, would you like to favourite this order?", "Sure!","No thanks!");
            }
        }
        public void GetOrder(List<Orders> orderList)
        {
            ObservableCollection<Orders> ordersFrom = new ObservableCollection<Orders> { };
            foreach (Orders order in orderList)
            {
                if (order.login1 == logins.CurrentName)
                {
                    ordersFrom.Add(order);
                }
            }
            ListView.ItemsSource = ordersFrom;
        }
    }
}
