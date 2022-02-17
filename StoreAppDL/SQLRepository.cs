using System.Data;
using System.Data.SqlClient;
using CustomerModel;
using OrderModel;
using StoreFrontModel;
using LineItemModel;
using StoreAppModel;

namespace StoreAppDL
{
    public class SQLRepository : IRepository
    {
        //SQLRepository now requires you to provide a connectionString to an existing database to create an object out of it
        //It will also allow SQLRepository to dynamically point to different databases as long as you have the connection string for it 
        private readonly string _connectionStrings;
        public SQLRepository (string p_connectionStrings)
        {
            _connectionStrings = p_connectionStrings;
        }
        public Customer AddCustomer(Customer c_customer)
        {
            //@before the string will ignore the special characters like \n
            //This is where you specify the sql statement required to whatever operation you need based on the method
            //
            string sqlQuery = @"insert into customer 
                                values(@Name, @_address)";

            //using block is different from our normal using statement
            //It is used to automatically close any resource you stated inside of the parenthesis
            //If an exception occurs it will still automatically close any resources
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens the connection to the database
                con.Open();

                //SqlCommand class is a class specialized in executing SQL statements
                //Command will hold the sqlQuery that wil execute on the current connection that we have in the con object
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@Name", c_customer.Name);
                command.Parameters.AddWithValue("@_address", c_customer.Address);

                //Executes the SQL statement
                command.ExecuteNonQuery();
            }

            return c_customer;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> listOfCustomers = new List<Customer>();

            string sqlQuery = @"select * from customer";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();

                //Create command object that has our sqlQuery and con object
                SqlCommand command = new SqlCommand(sqlQuery, con);

                //SqlDataReader is a class specialized in reading outputs that came from a sql statement
                //Usually this outputs are in a form of a table and keep that in mind 
                SqlDataReader reader = command.ExecuteReader();

                //Read() method checks if you have more rows to go through
                //If there is another row = true, if not = false
                while (reader.Read())
                {
                    //Zero based column index
                    listOfCustomers.Add(new Customer(){
                        CustomerId = reader.GetInt32(0), //It will get the column customerId since that is the very first column of our select statement
                        Name = reader.GetString(1), //It will get the name of the Name column since it is the second column of our select statement
                        Address = reader.GetString(2), //It will get the address of the Address column since it is the third column of our select statement
                        //Orders = GetOrdersByCustomerId(reader.GetInt32(1)) (Maybe)
                    });
                }
            }

            return listOfCustomers;
        }
        public List<StoreFront> GetAllStores()
        {
            List<StoreFront> listofStores = new List<StoreFront>();

            string sqlQuery = @"select * from Location";


            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                //command.Parameters.AddWithValue("@StoreId", c_storeId);

                SqlDataReader reader = command.ExecuteReader();
                
                 while (reader.Read())
                {
                    listofStores.Add(new StoreFront(){
                        //Reader column is NOT based on table structure but based on what your select statement is displaying 
                        Name = reader.GetString(1),
                        StoreId = reader.GetInt32(0),
                        Address = reader.GetString(2)
                    });
                }
            }
            return listofStores;
        }

        // public List<StoreFront> GetAllStoresById(int c_storeId)
        // {
        //     List<StoreFront> listOfStores = new List<StoreFront>();

        //     string sqlQuery = @"select o.OrderId, o.StoreId, total from Orders o 
        //                         inner join Location l on o.StoreId = l.StoreId
        //                         where o.StoreId = @StoreId";
            
        //     using (SqlConnection con = new SqlConnection(_connectionStrings))
        //     {
        //         con.Open();

        //         SqlCommand command = new SqlCommand(sqlQuery, con);
        //         command.Parameters.AddWithValue("@StoreId", c_storeId);

        //         SqlDataReader reader = command.ExecuteReader();
                
        //         while (reader.Read())
        //         {
        //             listOfStores.Add(new StoreFront(){
        //                 //Reader column is NOT based on table structure but based on what your select statement is displaying 
        //                 OrderId = reader.GetInt32(0),
        //                 StoreId = reader.GetInt32(1),
        //                 Total = reader.GetInt32(2)
        //             });
        //         }
        //     }
        //     return listOfStores;
        // }

        public List<Orders> GetOrdersByCustomerId(int c_customerId)
        {
            List<Orders> listOfOrders = new List<Orders>();

            string sqlQuery = @"select c.CustomerId, o.OrderId, o.total from Orders o  
                                inner join customer c on o.CustomerId  = c.CustomerId
                                where o.CustomerId = @CustomerId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@CustomerId", c_customerId);

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    listOfOrders.Add(new Orders(){
                        //Reader column is NOT based on table structure but based on what your select statement is displaying 
                        OrderId = reader.GetInt32(1),
                        CustomerId = reader.GetInt32(0),
                        _total = reader.GetInt32(2)
                    });
                }
            }
            return listOfOrders;
        }
        public List<Orders> GetOrdersByStoreId(int c_storeId)
        {
            List<Orders> listOfOrders = new List<Orders>();

            string sqlQuery = @"select o.StoreId, o.OrderId, o.total from Orders o 
                                inner join Location l on o.StoreId = L.StoreId 
                                where o.StoreId = @StoreId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreId", c_storeId);

                SqlDataReader reader = command.ExecuteReader();
                
                while (reader.Read())
                {
                    listOfOrders.Add(new Orders(){
                        //Reader column is NOT based on table structure but based on what your select statement is displaying 
                        OrderId = reader.GetInt32(1),
                        StoreId = reader.GetInt32(0),
                        _total = reader.GetInt32(2)
                    });
                }
            }
            return listOfOrders;
        }

        public List<StoreFront> ViewInventory(int c_storeId)
        {
            List<StoreFront> listOfStores = new List<StoreFront>();
            
            string sqlQuery = @"select * from Inventory
                                where StoreId = @StoreId";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                
                //Create command object 
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreId", c_storeId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStores.Add(new StoreFront(){
                        //Reader column is NOT based on table structure but based on what your select statement is displaying 
                        StoreId = reader.GetInt32(1),
                        ProductId = reader.GetInt32(0),
                        Quantity = reader.GetInt32(2)
                    });
            }
        }
        return listOfStores;
        }
        public List<StoreFront> ReplenishInventory(int c_storeId, int c_productId, int c_quantity)
        {
            List<StoreFront> listOfStores = new List<StoreFront>();
            
            string sqlQuery = @"Update Inventory set Quantity = @Quantity
                                where ProductId = @ProductId and StoreId = @StoreId";
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                
                //Create command object 
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@StoreId", c_storeId);
                command.Parameters.AddWithValue("@Quantity", c_quantity);
                command.Parameters.AddWithValue("@ProductId", c_productId);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfStores.Add(new StoreFront(){
                        //Reader column is NOT based on table structure but based on what your select statement is displaying 
                        StoreId = reader.GetInt32(1),
                        ProductId = reader.GetInt32(0),
                        Quantity = reader.GetInt32(2)
                        });
                         }
        }
        return listOfStores;
        }
        
        public void PlaceOrder(int c_customerId, int c_storeId, int c_total, List<LineItems> c_cart)
       {


           string sqlQuery = @"insert into Orders 
                                values (@total, @StoreId, @CustomerId);
                                select scope_identity();";

           string sqlQuery2 = @"update Inventory set Quantity = Quantity - @Quantity
                                where ProductId = @ProductId and StoreId = @StoreId"; 

           string sqlQuery3 =  @"insert into LineItems 
                                values (@ProductId, @OrderId, @Quantity)";

                                
            
            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                
                //Create command object 
                SqlCommand command = new SqlCommand(sqlQuery, con);
                command.Parameters.AddWithValue("@total", c_total);
                command.Parameters.AddWithValue("@StoreId", c_storeId);
                command.Parameters.AddWithValue("@CustomerId", c_customerId);
                int OrderId = Convert.ToInt32(command.ExecuteScalar());
                
               
                foreach(var item in c_cart)
                {
                    SqlCommand command1 = new SqlCommand(sqlQuery2, con);
                    command1.Parameters.AddWithValue("@Quantity", item.Quantity);
                    command1.Parameters.AddWithValue("@ProductId", item.ProductId);
                    command1.Parameters.AddWithValue("@StoreId", c_storeId);

                    command1.ExecuteNonQuery();

                    SqlCommand command2 = new SqlCommand(sqlQuery3, con);
                    command2.Parameters.AddWithValue("@ProductId", item.ProductId);
                    command2.Parameters.AddWithValue("@OrderId", OrderId);
                    command2.Parameters.AddWithValue("@Quantity", item.Quantity);

                    command2.ExecuteNonQuery();
                }

               
                
            }
       }

        public List<ProductModel> GetProducts()
        {
            List<ProductModel> listOfProducts = new List<ProductModel>();
            
            string sqlQuery = @"select * from Product";

            using (SqlConnection con = new SqlConnection(_connectionStrings))
            {
                //Opens connection to the database
                con.Open();
                
                //Create command object 
                SqlCommand command = new SqlCommand(sqlQuery, con);
                

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    listOfProducts.Add(new ProductModel(){
                        //Reader column is NOT based on table structure but based on what your select statement is displaying 
                        
                        productID = reader.GetInt32(0),
                        pName = reader.GetString(1)
                    });
            }
        }
        return listOfProducts;
        
    }

        public ProductModel AddProduct(ProductModel p_name)
        {
            string sqlQuery = @"INSERT INTO Product (Name, Price, Description) VALUES(@pName, @Price, @Description)";
            using(SqlConnection con = new SqlConnection(_connectionStrings))
            {
                con.Open();

                SqlCommand command = new SqlCommand(sqlQuery,con);

                command.Parameters.AddWithValue("@pName", p_name.pName);
                command.Parameters.AddWithValue("@Price", p_name.Price);
                command.Parameters.AddWithValue("@Description", p_name.Description);

                command.ExecuteNonQuery();

            }
            return p_name;
        }
    }
}

        