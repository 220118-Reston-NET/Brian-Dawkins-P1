// using CustomerModel;
// using OrderModel;
// using StoreBL;
// using StoreFrontModel;

// namespace StoreUI
// {
//     public class GetStoreOrder : IMenu
//     { public List<StoreFront> _Stores;
//     private IStoreFrontBL _storeBL;
//     public GetStoreOrder(IStoreFrontBL c_storeBL)
//      {
//             _storeBL = c_storeBL;
//             //_Stores = _storeBL.GetAllStores();
//         }

//         public void Display()
//         {
//             foreach (var item in _Stores)
//             {
//                 Console.WriteLine("==================");
//                  Console.WriteLine(item);
//             }
//             Console.WriteLine("[1] Select Store by Id");
//             Console.WriteLine("[0] Go Back");
//         }

//         public string UserChoice()
//         {
//              string userInput = Console.ReadLine();

//             //Switch cases useful if doing a bunch of comparison
//             switch (userInput)
//             {
//                 case "0":
//                     return "MainMenu";
//                 case "1":
//                     Console.WriteLine("Enter Store Id:");

//                     try
//                     {
//                         int StoreId = Convert.ToInt32(Console.ReadLine());
//                         List<Orders> listOfOrders = _storeBL.GetOrdersByStoreId(StoreId);
//                         foreach (var item in listOfOrders)
//                         {
//                             Console.WriteLine("===================");
//                             Console.WriteLine(item);
//                         }

//                     Console.WriteLine("Please press Enter to continue");
//                     Console.ReadLine();
//                     return "MainMenu";
//                     }
//                     catch (FormatException)
//                     {
                        
//                     Console.WriteLine("Please input a valid response");
//                     Console.WriteLine("Please press Enter to continue");
//                     Console.ReadLine();
//                     return "GetStoreOrder";
//                     }
                    
//                    default:
//                     Console.WriteLine("Please input a valid response");
//                     Console.WriteLine("Please press Enter to continue");
//                     Console.ReadLine();
//                     return "Main Menu";
//                 }
//             }
//         }
// }
  