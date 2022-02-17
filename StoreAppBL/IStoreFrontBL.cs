using CustomerModel;
using OrderModel;
using StoreAppModel;
using StoreFrontModel;

namespace StoreBL
{

/// <summary>
/// Business Layer is responsible for further validation or processing of data obtained from either the database or the user
/// What kind of processing? That all depends on the type of functionality you will be doing
/// </summary>
public interface IStoreFrontBL
{
    /// <summary>
    /// Will add a customer to the database
    /// Initial addition of a pokemon will give it some sort of a randomize stats
    /// Can only have the total of 4 pokemons in the database
    /// </summary>
    /// <param name="c_customer"></param>
    /// <returns></returns>
    Customer AddCustomer(Customer c_customer);

    /// <summary>
    /// Will give a list of customer objects that are related to the searched name
    /// </summary>
    /// <param name="c_name"></param>
    /// <returns></returns>
    List<Customer> SearchCustomer(string c_name);

        /// <summary>
        /// Will give a list of customers from the database
        /// </summary>
        /// <returns>list collection with customer objects</returns>
        List<Customer> GetAllCustomers();
    /// <summary>
    /// Will give the order associated with a specific customer Id
    /// </summary>
    /// <param name="c_customerId"></param>
    /// <returns>list collection with customer orders</returns>
    List<Orders> GetOrdersByCustomerId(int c_customerId);
    /// <summary>
    /// Will give the order associated with a specific store Id
    /// </summary>
    /// <param name="c_storeId"></param>
    /// <returns>list collection associated with store orders</returns>
    List<StoreFront> GetAllStores(int c_storeId);
    List<Orders> GetOrdersByStoreId(int c_storeId);
    /// <summary>
    /// Will give the inventory associated with all of the store fronts 
    /// </summary>
    /// <param name="c_storeId"></param>
    /// <returns>list collection of inventory at each store location</returns>
    List<StoreFront> ViewInventory(int c_storeId);
    List<StoreFront> GetAllStores();
    StoreFront GetStoresById(int c_storeId);
    List<ProductModel> GetProductsByStoreId(int c_storeId);
    /// <summary>
    /// Will replinish product inventory to base store amount
    /// </summary>
    /// <param name="c_productId"></param>
    List<StoreFront> ReplenishInventory(int c_storeId,int c_productId, int c_quantity);
    
    ProductModel AddProducts(ProductModel p_name);
    List<ProductModel> GetProducts();
    public Customer GetCustomerByID(int customerId)
    {
        return GetAllCustomers().Where(customer => customer.CustomerId.Equals(customerId)).First();
    }
    void PlaceOrder(int c_customerId, int c_storeId, int c_total, List<LineItems> c_cart);
    }
}