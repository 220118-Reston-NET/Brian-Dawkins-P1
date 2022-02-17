using CustomerModel;
using OrderModel;
using StoreBL;

namespace StoreUI
{

    public class GetCustomerOrder : IMenu
    {
        private List<Customer> _listOfCustomer;
        private IStoreFrontBL _storeBL;
        public GetCustomerOrder(IStoreFrontBL c_storeBL)
        {
            _storeBL = c_storeBL;
            _listOfCustomer = _storeBL.GetAllCustomers();
        }
        public void Display()
        {
            // foreach (var item in _listOfCustomer)
            // {
            //     Console.WriteLine("==================");
            //      Console.WriteLine(item);
            // }
            Console.WriteLine("[1] Select Customer by Id");
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
                    Console.WriteLine("Enter CustomerId:");

                    try
                    {
                        int customerId = Convert.ToInt32(Console.ReadLine());
                        List<Orders> listOfOrders = _storeBL.GetOrdersByCustomerId(customerId);
                        foreach (var item in listOfOrders)
                        {
                            Console.WriteLine("===================");
                            Console.WriteLine(item);
                        }
                    Log.Information("Successful at getting Customer Order");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "MainMenu";
                    }
                    catch (FormatException)
                    {
                        
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "GetCustomerOrder";
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