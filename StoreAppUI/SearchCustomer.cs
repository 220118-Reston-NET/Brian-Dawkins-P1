using CustomerModel;
using StoreBL;
using StoreFrontModel;

namespace StoreUI
{
    public class SearchCustomer : IMenu
    {
        private IStoreFrontBL _storeBL;
        public SearchCustomer(IStoreFrontBL c_storeBL)
        {
            _storeBL = c_storeBL;

        }

        public void Display()
        {
            Console.WriteLine("Please select an option to filter the customer database");
            Console.WriteLine("[1] By Name");
            Console.WriteLine("[0] Go back");

        }

        public string UserChoice()
        {
            string userInput = Console.ReadLine();

            switch (userInput)
            {
                case "0":
                    return "MainMenu";
                case "1":
                    //Logic to grab user input
                    Console.WriteLine("Please enter a name");
                    string name = Console.ReadLine();

                    //Logic to display the result
                    List<Customer> listOfCustomers = _storeBL.SearchCustomer(name);
                    foreach (var item in listOfCustomers)
                    {
                        Console.WriteLine("================");
                        Console.WriteLine(item);

                    }

                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();

                    return "MainMenu";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "SearchCustomer";
            }
        }
    }
}