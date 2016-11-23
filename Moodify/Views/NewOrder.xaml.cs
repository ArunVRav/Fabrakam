using Moodify.DataModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moodify
{
    public partial class NewOrder : ContentPage
    {   
        public NewOrder()
        {
            InitializeComponent();

            var foods = Menus.GetMenu();
            var select = Menus.GetNumber();
            //Title
            Label header = new Label
            {
                Text = "Choose and Order!",
                FontSize = 50,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Navy
            };

            //Picker
            Picker picker1 = new Picker
            {
                Title = "Food!",
                VerticalOptions = LayoutOptions.CenterAndExpand
            };



            //Populate the picker
            foreach (string foodName in foods.Keys)
            {
                picker1.Items.Add(foodName);
            }

            //Button
            Button addItem = new Button
            {
                Text = "Add Item!",
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center
            };

            //Selected Foods
            Label selected = new Label
            {
                FontSize = 20,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Black
            };

            //PriceLabel
            Label Price = new Label
            {
                FontSize = 30,
                HorizontalOptions = LayoutOptions.Center,
                TextColor = Color.Blue,
                Text = "0"
            };

            //When the additem button is clicekd
            addItem.Clicked += (sender, args) =>
            {
                if (picker1.SelectedIndex != -1)
                {
                    string foodName = picker1.Items[picker1.SelectedIndex];
                    selected.Text = "";
                    double PriceTotal = 0;
                    if (select.ContainsKey(foodName))
                    {
                        select[foodName]++;
                    }
                    else
                    {
                        select.Add(foodName, 1);
                    }
                    //Adding text to both price and current order
                    foreach (string food in select.Keys)
                    {
                        //As long as 1 or more of it is selected
                        if (select[food] > 0)
                        {
                            selected.Text += food + " x" + select[food].ToString();
                            selected.Text += "\n";
                            PriceTotal += (select[food]) * (foods[food]);
                        }
                    }
                    Price.Text = PriceTotal.ToString();
                }
            };

            //Button for saving and continuing with order
            Button finish = new Button
            {
                Text = "ADD ORDER",
                FontSize = 30,
                BackgroundColor = Color.Black,
                TextColor = Color.White
            };

            Content = new StackLayout
            {
                Spacing = 0,
                Children =
                {
                    header,
                    picker1,
                    addItem,
                    selected,
                    Price,
                    finish
                }
            };

            finish.Clicked += (sender, args) =>
            {
                Orders order = new DataModels.Orders();
                //order.Price = 0;
                foreach (string foodselected in select.Keys)
                {
                    switch (foodselected)
                    {
                        case "Hot Chips":
                            order.HotChips = select[foodselected];
                            order.Price += select[foodselected] * foods[foodselected];
                            break;
                        case "Roast Potatoes":
                            order.RoastPotatoes = select[foodselected];
                            order.Price += select[foodselected] * foods[foodselected];
                            break;
                        case "Vegetable Salad":
                            order.VegetableSalad = select[foodselected];
                            order.Price += select[foodselected] * foods[foodselected];
                            break;
                        case "Fruit Salad":
                            order.FruitSalad = select[foodselected];
                            order.Price += select[foodselected] * foods[foodselected];
                            break;
                        case "Eggplant Parm":
                            order.EggplantParm = select[foodselected];
                            order.Price += select[foodselected] * foods[foodselected];
                            break;
                        case "Veggie Burger":
                            order.VeggieBurger = select[foodselected];
                            order.Price += select[foodselected] * foods[foodselected];
                            break;
                        case "Strawberry Smoothies":
                            order.Smoothie = select[foodselected];
                            order.Price += select[foodselected] * foods[foodselected];
                            break;
                        default:
                            break;
                    }
                }
                AddTheOrder(order);
            };
        }
        private async void AddTheOrder(Orders order)
        {
            var loginList = await AzureManager.AzureManagerInstanceLogins.GetLogins();
            int currIndex = logins.indexer;
            string Email = loginList[3].Email;
            await AzureManager.AzureManagerInstanceOrders.AddOrder(order);
            order.login1 = Email;
            await AzureManager.AzureManagerInstanceOrders.UpdateOrder(order);
            App.RootPage.Detail = new NavigationPage(new YourOrders());
        }

    };      
}

            
