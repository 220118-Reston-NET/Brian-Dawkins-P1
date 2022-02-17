using StoreBL;
using StoreFrontModel;

namespace StoreUI
{
    public class ShopUI : IMenu
    {
        private IStoreFrontBL _storeBL;
        List<StoreFront> listOfStores = new List<StoreFront>();
        public static StoreFront storeselected = new StoreFront();
        public ShopUI(IStoreFrontBL c_storeBL)
        {
            _storeBL = c_storeBL;
            listOfStores = _storeBL.GetAllStores();
        } 
        public void Display()
        {
            Log.Information("User is being displayed ShopUI Menu");
            foreach (var storeId in listOfStores)
            {
                Console.WriteLine(storeId);
                Console.WriteLine("=============");
            }
            Console.WriteLine("What Store which you like to shop from?");
            Console.WriteLine("[1] Choose Store");
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
                    int storeId = Convert.ToInt32(Console.ReadLine());
                    if (storeId != 0)
                    {
                        while (listOfStores.All(shop => shop.StoreId != storeId))
                        {
                            Console.WriteLine("Enter Store ID");
                            storeId = Convert.ToInt32(Console.ReadLine());
                        }
                        storeselected = _storeBL.GetStoresById(storeId);
                        return "ShopMenu";
                    }
                    else
                    {
                        Log.Warning("User made an error");
                        Console.WriteLine("Please press enter to continue");
                        Console.ReadLine();
                        return "ShopUI";
                    }
                    default:
                        Console.WriteLine("Please input a valid response");
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                        return "ShopUI";
            }
        }
    }
}