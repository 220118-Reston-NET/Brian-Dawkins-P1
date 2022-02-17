namespace StoreUI
{
    /*
    MainMenu inherits IMenu interface but since it is a class it needs to give actual implementation details to the methods
    stated inside of the interface
    */

    public class MainMenu : IMenu
    {
        public void Display()
        {
            Console.WriteLine("Welcome to The Shop Memorabilia Store");
            Console.WriteLine("              ");
            Console.WriteLine("Who do we have the pleasure of helping today?");
            Console.WriteLine("[5] Add Customer");
            Console.WriteLine("[6] Search Existing Customer");
            Console.WriteLine("              ");
            Console.WriteLine(" What would you like to do?");
            Console.WriteLine("[1] Check available inventory");
            Console.WriteLine("[2] Shop");
            Console.WriteLine("[3] See previous order");
            Console.WriteLine("[4] Find Location");
            Console.WriteLine("[7] Get customer order");
            Console.WriteLine("[8] View Order History from store");
            Console.WriteLine("[9] Replenish Inventory");
            Console.WriteLine("[10] Place Order");
            Console.WriteLine("[11] Add Product");
            Console.WriteLine("[0] Exit");
        }
        //Need to add search customers option into display 
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases useful if doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return "Exit";
                case "1":
                    return "ViewInventory";
                case "2":
                    return "Shop";
                case "3":
                    return "Previous Order";
                case "4":
                    return "Find Location";
                case "5":
                    return "AddCustomer";
                case "6":
                    return "SearchCustomer";
                case "7":
                    return "GetCustomerOrder";
                case "8":
                    return "ViewOrderHistory";
                case "9":
                    return "ReplenishInventory";
                case "10":
                    return "PlaceOrder";
                case "11":
                    return "AddProduct";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Main Menu";                    
            }
        }
    }
}