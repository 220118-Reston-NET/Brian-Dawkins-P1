using MemorabiliaModel;
using StoreAppModel;
using StoreBL;
using StoreFrontModel;

namespace StoreUI
{
    public class ShopMenu : IMenu
    {
        private IStoreFrontBL _storeBL;
        private static List<ProductModel> listOfProducts = new List<ProductModel>();
        private static List<StoreFront> listOfInventory = new List<StoreFront>();
        public static StoreFront storeselected = new StoreFront();
        public ShopMenu(IStoreFrontBL c_storeBL)
        {
            _storeBL = c_storeBL;
            listOfProducts = _storeBL.GetProductsByStoreId(ShopUI.storeselected.StoreId);
            listOfInventory = _storeBL.ViewInventory(ShopUI.storeselected.StoreId);
        } 
        private static List<LineItems> _cart = new List<LineItems>();
        public void Display()
        {
            Log.Information("Products Have Been Shown");
            Console.WriteLine("==== Products ====");
            foreach (var item in listOfProducts)
            {
                Console.WriteLine(item);
                Console.WriteLine("===============");

            }
            Console.WriteLine("==================");
            Console.WriteLine("[1] Start Order");
            Console.WriteLine("[2] Place Order");
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
                    Log.Information("Order Started");
                    Console.WriteLine("Please enter product ID");
                    int ProductID = Convert.ToInt32(Console.ReadLine());
                    
                    while (listOfProducts.All(product => product.productID != ProductID))
                    {

                         Console.WriteLine("Please enter product ID");
                         ProductID = Convert.ToInt32(Console.ReadLine());

                    }
                    Console.WriteLine("How much would you like to buy?");
                    int quantity = Convert.ToInt32(Console.ReadLine());

                    _cart.Add (new LineItems(){
                        ProductId = ProductID, 
                        Quantity = quantity
                    });
                    Console.WriteLine("=== Shopping Cart ===");
                    foreach (var pname in _cart)
                    {
                        Console.WriteLine("Product ID: " + listOfProducts.Find(prod => prod.productID == pname.ProductId));
                        //Console.WriteLine("Product Name: " + listOfProducts.Find(prod => prod.ProductId == pname.ProductId).Name);
                        Console.WriteLine("======================");

                    }
                    Console.WriteLine("=======================");
                    Console.ReadLine();
                    return "ShopMenu";
                case "2":
                    Log.Information("Order has been submitted");
                    Console.WriteLine("Order submitted successfully!");
                    _storeBL.PlaceOrder(PlaceOrder.selectedCustomer.CustomerId, ShopUI.storeselected.StoreId, 0, _cart);
                    Console.ReadLine();
                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "ShopMenu";
           }
               
        }
    }
}
