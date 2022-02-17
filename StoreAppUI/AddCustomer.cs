using StoreBL;
using CustomerModel;

namespace StoreUI
{
    public class AddCustomer : IMenu
    {
        //static non-access modifier is needed to keep this variable consistent to all objects we create out of our AddCustomer
        private static Customer _newCustomer = new Customer();

        //Dependency Injection
        //=========================
        private IStoreFrontBL _customerBL;
        public AddCustomer(IStoreFrontBL c_customerBL)
        {
            _customerBL = c_customerBL;
        } 
        //================================

        public void Display()
        {
            Console.WriteLine("Enter Customer Information");
            Console.WriteLine("[4] Name - " + _newCustomer.Name);
            Console.WriteLine("[3] Phone Number - " + _newCustomer.PhoneNumber);
            Console.WriteLine("[2] Address - " + _newCustomer.Address);
            Console.WriteLine("[1] Save");
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
                    //Exception handling to have better user experience 
                    try
                    {
                        Log.Information("Adding customer \n" + _newCustomer);
                        _customerBL.AddCustomer(_newCustomer);
                        Log.Information("Successful at adding customer!");
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
                    Console.WriteLine("Please enter an address");
                    _newCustomer.Address = Console.ReadLine();
                    return "AddCustomer";
                
                case "3":
                    Console.WriteLine("Please enter a phone number");
                    _newCustomer.PhoneNumber= Console.ReadLine();
                    return "AddCustomer";
                    //May need some sort of parameter that phone number needs to fit in here
                
                case "4":
                    Console.WriteLine("Please enter a name");
                    _newCustomer.Name = Console.ReadLine();
                    return "AddCustomer";
                default:
                    Console.WriteLine("Please input a valid response");
                    Console.WriteLine("Please press Enter to continue");
                    Console.ReadLine();
                    return "AddCustomer";
            }
        }
    }
}
