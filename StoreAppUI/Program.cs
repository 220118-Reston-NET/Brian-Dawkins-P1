// See https://aka.ms/new-console-template for more information
//using CustomerModel;
global using Serilog;
using StoreBL;
using StoreAppDL;
using StoreUI;
using Microsoft.Extensions.Configuration;

//Console.WriteLine("Hello, World!");

//Creating and configuring our logger
Log.Logger = new LoggerConfiguration()
    .WriteTo.File("./logs/user.txt") //We configure our logger to save in this file 
    .CreateLogger();

//Reading and obtaining connectionString from appsettings.json
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

string _connectionString = configuration.GetConnectionString("Reference2DB");

bool repeat = true;
IMenu menu = new MainMenu();

while(repeat)
{
    Console.Clear();
    menu.Display();
    string ans = menu.UserChoice();

    switch (ans)
    {
        // case "PlaceOrder":
        // Log.Information("Displaying Place Order Menu to user");
        //     menu = new PlaceOrder(new StoreFrontBL(new SQLRepository(_connectionString)));
        //     break;
        // case "ReplenishInventory":
        // Log.Information("Displaying Replenish Inventory Menu to user");
        //     menu = new ReplenishInventory(new StoreFrontBL(new SQLRepository(_connectionString)));
        //     break;
        case "AddProduct":
        Log.Information("Displaying add product menu to user");
            menu = new AddProducts(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "ShopMenu":
        Log.Information("Displaying ShopMenu to user");
            menu = new ShopMenu(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "ShopUI":
        Log.Information("Displaying ShopUI Menu to user");
            menu = new ShopUI(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "PlaceOrder":
        Log.Information("Displaying Place Order Menu to user");
            menu = new PlaceOrder(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "ReplenishInventory":
        Log.Information("Displaying Replenish Inventory Menu to user");
            menu = new ReplenishInventory(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "ViewOrderHistory":
        Log.Information("Displaying View Order History Menu to user");
            menu = new ViewOrderHistory(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "ViewInventory":
        Log.Information("Displaying View Inventory Menu to user");
            menu = new ViewInventory(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "GetCustomerOrder":
        Log.Information("Displaying Get Customer Order Menu to user");
            menu = new GetCustomerOrder(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "SearchCustomer":
        Log.Information("Displaying SearchCustomer Menu to user");
            menu = new SearchCustomer(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "AddCustomer":
        Log.Information("Displaying AddCustomer Menu to user");
            menu = new AddCustomer(new StoreFrontBL(new SQLRepository(_connectionString)));
            break;
        case "MainMenu":
            Log.Information("Displaying MainMenu to user");
            menu = new MainMenu();
            break;
        case "Exit":
            Log.Information("Exiting application");
            Log.CloseAndFlush(); //To close our logger resource
            repeat = false;
            break;
        default:
            Log.Information("User entered an ivalid key");
            Console.WriteLine("Page does not exist!");
            Console.WriteLine("Please press Enter to continue");
            Console.ReadLine();
            break;
    }
}