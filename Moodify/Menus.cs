using Moodify;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Moodify
{
    public class Food
    {
        public string foodName { get; set; }
        public double Price { get; set; }
        public int noOrders { get; set; }
    }

    public class Menus
    {
        public static Dictionary<string, double> foods = new Dictionary<string, double>
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
        public static Dictionary<string, int> select = new Dictionary<string, int> {
            {"Hot Chips",0 },
            {"Roast Potatoes",0 },
            {"Vegatable Salad",0 },
            {"Fruit Salad",0 },
            {"Eggplant Parm",0 },
            {"Veggie Burger",0 },
            {"Strawberry Smoothies",0 }
        };
        public static Dictionary<string,double> GetMenu()
        {
            return foods;
        }
        public static Dictionary<string,int> GetNumber()
        {
            return select;
        }

        public static ObservableCollection<Food> FullMenu = new ObservableCollection<Food>
        {

        };
        public static void PopulateCollection(Dictionary<string,int> select)
        {
            foreach (string foodname in foods.Keys)
            {
                Food current = new Food();
                if (select.ContainsKey(foodname) && select[foodname]!=0)
                {
                    current.foodName = foodname;
                    current.noOrders = select[foodname];
                    current.Price = foods[foodname]*(select[foodname]);
                    FullMenu.Add(current);
                }
            }
        }
    }

    
}
