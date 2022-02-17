using OrderModel;
using MemorabiliaModel;
using StoreBL;
using StoreFrontModel;

namespace StoreUI
{
    public class ViewOrderHistory : IMenu
    {
        private List<StoreFront> _listOfStores;
        private IStoreFrontBL _storeBL;
        public ViewOrderHistory(IStoreFrontBL c_storeBL)
        {
            _storeBL = c_storeBL;
            _listOfStores = _storeBL.GetAllStores();
        }
        public void Display()
        {
            // foreach (var item in _listOfStores)
            // {
            //     Console.WriteLine("==================");
            //      Console.WriteLine(item);
            // }
            Console.WriteLine("[1] Select Store by Id");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();
            switch (userInput)
            {
                case "1":
                    Console.WriteLine("Enter Store Id:");

                    try
                    {
                        int storeId = Convert.ToInt32(Console.ReadLine());
                        List<Orders> listOfOrders = _storeBL.GetOrdersByStoreId(storeId);
                        foreach (var item in listOfOrders)
                        {
                            Console.WriteLine("===================");
                            Console.WriteLine(item);
                        }

                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    catch (FormatException)
                    {
                        
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ViewOrderHistory";
                    }
                case "0":
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "Main Menu";
            }
        }
    }
}