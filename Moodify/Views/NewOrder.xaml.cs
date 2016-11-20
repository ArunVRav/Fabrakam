using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Moodify
{
    public partial class NewOrder : ContentPage
    {
        Dictionary<string, double> foods = new Dictionary<string, double>
        {
            //All the info for the menu
            {"Hot Chips",2.50 },
            {"Roast Potatoes",3.50 },
            {"Vegatable Salad",2.00 },
            {"Fruit Salad",2.00 },
            {"Eggplant Parm",5.50 },
            {"Veggie Burger",7.50 },
            {"Strawberry Smoothies",5.00 }
        };
        public NewOrder()
        {
            InitializeComponent();

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

            //Dictionary of Selected stuffs
            Dictionary<string, int> select = new Dictionary<string, int>{ };

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
                    selected.Text += food + " x" + select[food].ToString();
                    selected.Text += "\n";
                    PriceTotal += (select[food]) * (foods[food]);
                }
                Price.Text = PriceTotal.ToString();
            };

            //Button for saving and continuing with order
            Button finish = new Button
            {
                Text = "ADD ORDER",
                FontSize = 30,
                BackgroundColor = Color.Blue
            };
            this.Content = new StackLayout
            {
                Spacing = 0,
                Children =
                {
                    header,
                    picker1,
                    addItem,
                    selected,
                    Price
                }
            };
        }
    }
        //private void InitializeComponent()
        //{
        //    this.LoadFromXaml(typeof(NewOrder));
        //}
        

            
}
