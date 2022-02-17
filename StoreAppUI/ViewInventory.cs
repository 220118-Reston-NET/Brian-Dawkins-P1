using OrderModel;
using StoreBL;
using StoreFrontModel;

namespace StoreUI
{
    public class ViewInventory : IMenu
    {
        private List<StoreFront> _listOfStore = new List<StoreFront>();
        private IStoreFrontBL _storeBL;
        public ViewInventory(IStoreFrontBL c_storeBL)
        {
             _storeBL = c_storeBL;
             //_listOfStore = _storeBL.ViewInventory();
        }

        public void Display()
        {
            foreach (var item in _listOfStore)
            {
                Console.WriteLine("==================");
                 Console.WriteLine(item);
            }
            Console.WriteLine("[1] Select Store by Id");
            Console.WriteLine("[0] Go Back");
        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            //Switch cases useful if doing a bunch of comparison
            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    Console.WriteLine("Enter Store Id:");

                    try
                    {
                        int storeId = Convert.ToInt32(Console.ReadLine());
                        List<StoreFront> listOfStore = _storeBL.ViewInventory(storeId);
                        foreach (var item in listOfStore)
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
                    return "GetStoreOrder";
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