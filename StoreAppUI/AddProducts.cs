using StoreAppModel;
using StoreBL;

namespace StoreUI

{
    public class AddProducts : IMenu
    {
        private static ProductModel _Info = new ProductModel();

        private IStoreFrontBL _productBL;
        public AddProducts(IStoreFrontBL c_productBL)
        {
            _productBL = c_productBL;
        } 
        //================================
        public void Display()
        {
            Log.Information("Displaying Add Product Menu");
            Console.WriteLine("[5] Description - " + _Info.Description);
            Console.WriteLine("[3] Price - " + _Info.Price);
            Console.WriteLine("[2] Name - " + _Info.pName);
            Console.WriteLine("[1] Add Product");
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
                Log.Information("");
                     try
                    {
                        Log.Information("Adding Product \n" + _Info);
                        _productBL.AddProducts(_Info);
                        Log.Information("Successful at adding product!");
                    } 
                    catch (System.Exception exc)
                    {
                        Log.Warning("Failed to add customer");
                        Console.WriteLine(exc.Message);
                        Console.WriteLine("Please press Enter to continue");
                        Console.ReadLine();
                    }
                    return "MainMenu";
                case "2":
                    Console.WriteLine("Please enter a name");
                    _Info.pName = Console.ReadLine();
                    return "AddProduct";
                case "3":
                    Console.WriteLine("Please enter a phone number");
                    _Info.Price = Convert.ToInt32(Console.ReadLine());
                    return "AddProduct";
                case "5":
                    Console.WriteLine("Please enter a category");
                    _Info.Description = Console.ReadLine();
                    return "AddProduct";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddProduct";
            }
        }
    }
}