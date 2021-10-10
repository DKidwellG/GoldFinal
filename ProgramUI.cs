using KomodoCafe.Data;
using KomodoCafe.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe
{
    class ProgramUI
    {
        private MenuRepo _menuItems = new MenuRepo();


        public void Run()
        {
            SeedMenuList();
            Menu();
        }
        // menu
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {


                //list of menu
                Console.WriteLine("selsct an option from the menu then press enter:\n" +
                    "1. Enter a new menu item\n" +
                    "2. List of all menu items\n" +
                    "3. list of meal numbers\n" +
                    "4. Delete menu item\n" +
                    "5. Exit");

                //get input
                string input = Console.ReadLine();

                //evaluate input
                switch (input)
                {
                    case "1":
                        //create
                        CreatNewMenuItem();
                        break;
                    case "2":
                        //list 
                        ViewAllMenuItems();
                        break;

                    case "3":
                        //list by number
                        ViewMealById();
                        break;
                    case "4":
                        //delete 
                        DeleteItem();
                        break;
                    case "10":
                        //exit
                        Console.WriteLine("Bu-by");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("pleas enter a number from the menu");
                        break;




                }
                Console.WriteLine("Press any key to continue.....");
                Console.ReadKey();
                Console.Clear();
            }

        }
        //new Item
        private void CreatNewMenuItem()
        {
            /*MealNumber = mealNumber;
        MealName = mealName;
        Description = description;
        PriceOfMeal*/
            //item number
            Console.Clear();
            Menu newItem = new Menu();
            Console.WriteLine(" enter meal number, then press enter");
            string idAsString = Console.ReadLine();
            newItem.MealNumber = int.Parse(idAsString);

            //item name
            Console.WriteLine(" enter menu item name, then press enter");
            newItem.MealName = Console.ReadLine();

            Console.WriteLine(" enter menu item discription, then press enter");
            newItem.Description = Console.ReadLine();

            Console.WriteLine(" enter meal price, then press enter");
            newItem.PriceOfMeal = decimal.Parse(Console.ReadLine());

            _menuItems.AddMenuItemToList(newItem);


        }
        //view all 
        private void ViewAllMenuItems()
        {
            Console.Clear();
            List<Menu> listOfItems = _menuItems.GetMenus();
            foreach (Menu content in listOfItems)
            {
                Console.WriteLine($"meal number: {content.MealNumber}\n" +
                    $"meal name: {content.MealName}, meal description: {content.Description}\n" +
                    $"price {content.PriceOfMeal}\n" +
                    $"press enter to continue");
            }
        }
        //view by id
        private void ViewMealById()
        {
            Console.Clear();
            Console.WriteLine("enter meal number");
            int mealNumber = int.Parse(Console.ReadLine());
            Menu content = _menuItems.GetMealByNumber(mealNumber);
            if (content != null)
            {
                Console.WriteLine($"ID: {content.MealNumber}\n" +
                   $"item name: {content.MealName},\n" +
                   $" description: {content.Description}\n" +
                   $"price {content.PriceOfMeal}");
            }
            else
            {
                Console.WriteLine(" no item found");
            }

        }


        //delete item
        private void DeleteItem()
        {
            ViewAllMenuItems();
            Console.WriteLine("\n enter the name of the item that you want to delete. then press enter:");
            short input = short.Parse(Console.ReadLine());
            bool wasDeleted = _menuItems.RemoveMenuItemFromList(input);
            if (wasDeleted)
            {
                Console.WriteLine("they are removed form the list");
            }
            else
            {
                Console.WriteLine("oops try agin");
            }
        }

        //seed
        private void SeedMenuList()
        {
            Menu handwitch = new Menu(1, "Handwitch", "finger licking good", 5.43m);
            Menu chickenNuckles = new Menu(2, "Chicken Nuckles", "get them befor they get away", 2.99m);

            _menuItems.AddMenuItemToList(handwitch);
            _menuItems.AddMenuItemToList(chickenNuckles);
        }
    }
}
