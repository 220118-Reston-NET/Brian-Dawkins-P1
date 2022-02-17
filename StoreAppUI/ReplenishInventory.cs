using OrderModel;
using MemorabiliaModel;
using StoreBL;
using StoreFrontModel;

namespace StoreUI
{
    public class ReplenishInventory : IMenu
    {
        private List<StoreFront> _listOfStore = new List<StoreFront>();
        private IStoreFrontBL _storeBL;

        public ReplenishInventory(IStoreFrontBL c_storeBL)
        {
             _storeBL = c_storeBL;
             //_listOfStore = _storeBL.ViewInventory();
        }

        public void Display()
        {
            Console.WriteLine("Replenish Inventory Menu");
            Console.WriteLine("Would you like to replinish a stores Inventory?");
            Console.WriteLine("[1] Yes");
            Console.WriteLine("[0] Go Back");
        }
        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Enter Store ID");
                    Console.WriteLine("Enter product ID");
                    Console.WriteLine("Enter Quantity you wish to replenish");
                   try
                    {
                        int c_storeId = Convert.ToInt32(Console.ReadLine());
                        int c_productId = Convert.ToInt32(Console.ReadLine());
                        int c_quanity = Convert.ToInt32(Console.ReadLine());
                        List<StoreFront> listOfStore = _storeBL.ReplenishInventory(c_storeId, c_productId, c_quanity);
                    {
                    Log.Information("Successfully Replenished Store");
                    Console.WriteLine("You have successfully replenished the store ");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    }
                    catch (FormatException)
                    {
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ReplenishInventory";
                    }
                    default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Main Menu";
                }

            }
        }
    }