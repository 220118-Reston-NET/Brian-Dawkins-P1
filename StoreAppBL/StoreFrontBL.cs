using StoreAppDL;
using CustomerModel;
using OrderModel;
using StoreFrontModel;
using System.Linq;
using StoreAppModel;

namespace StoreBL
{
    public class StoreFrontBL : IStoreFrontBL
    {
        //Dependency Injection Pattern
        //- This is the main reason why we created interface first before the class
        //- This will save you time on re-writing code that breaks if you updated a completely seperate class
        //- Main reason is to prevent us from re-writing code that already existed on (potentially) 50 file or more without
        //the compiler helping us
        //===========================
        private IRepository _repo;
        public StoreFrontBL(IRepository p_repo)
        {
            _repo = p_repo;
        }
        //===========================

        public Customer AddCustomer(Customer c_customer)
        {
            //Random rand = new Random(); (Not sure if this makes sense for my project yet)

        //     //Processing data to meet conditions
        //     //Not sure if this step is needed for adding customers

        //     //Validation Process
            return _repo.AddCustomer(c_customer);
        }

        public List<Customer> GetAllCustomers()
        {
            return _repo.GetAllCustomers();
        }

        public List<Orders> GetOrdersByCustomerId(int c_customerId)
        {
            return _repo.GetOrdersByCustomerId(c_customerId);
        }

        public List<Customer> SearchCustomer(string c_name)
        {
            List<Customer> listOfCustomers = _repo.GetAllCustomers();

            //LINQ library
            return listOfCustomers
                    .Where(customer => customer.Name.Contains(c_name))//Where method is designed to filter a collection based on a condition
                    .ToList(); //ToList method just converts into a list collection that our method needs to return
        }
        List<StoreFront> GetAllStores(int c_storeId)
        {
            throw new NotImplementedException();
        }
        // public List<StoreFront> ViewInventory(int c_storeId)
        // {
        //     return _repo.ViewInventory(c_storeId);
        // }
        // public List<StoreFront> ViewInventory(int c_storeId)
        // {
        //      List<StoreFront> listOfStores = _repo.GetAllStores();

        //     //LINQ library
        //     return listOfStores
        //             .Where(store => store.StoreId.Equals(c_storeId))//Where method is designed to filter a collection based on a condition
        //             .ToList(); //ToList method just converts into a list collection that our method needs to return
        // }
        public List<StoreFront> ViewInventory(int c_storeId)
        {
            return _repo.ViewInventory(c_storeId);
        }
        public List<ProductModel> GetProductsByStoreID(int c_storeId)
        {
            return GetProducts().FindAll(p =>p.productID.Equals(c_storeId));
        }

        public List<Orders> GetOrdersByStoreId(int c_storeId)
        {
            return _repo.GetOrdersByStoreId(c_storeId);
        }

        List<StoreFront> IStoreFrontBL.GetAllStores(int c_storeId)
        {
            throw new NotImplementedException();
        }

        public List<StoreFront> GetAllStores()
        {
            return _repo.GetAllStores();
        }

        // public List<Products> ViewProductsByStoreId(int c_storeId)
        // {
        //     throw new NotImplementedException();
        // }

        public List<StoreFront> ReplenishInventory(int c_storeId, int c_productId, int c_quantity)
        {
            return _repo.ReplenishInventory(c_storeId, c_productId, c_quantity);
        }
        public  StoreFront GetStoresById(int storeid)
        {
            return GetAllStores().Where(storeid=>storeid.Equals(storeid)).First();

        }
        public List<ProductModel> GetProductsByStoreId(int storeid)
        {
            List<ProductModel> listOfProduct = new List<ProductModel>();
            foreach (var p_name in GetProductsByStoreID(storeid))
            {
                listOfProduct.Add(GetProducts().Find(p => p.productID.Equals(p_name.productID)));
            }
            //return GetAllProducts().Where(storeID=> storeID.Equals(storeid)).ToList();
            return listOfProduct;
        }

        public List<ProductModel> GetProducts()
        {
            return _repo.GetProducts();
        }
        public void PlaceOrder(int c_customerId, int c_storeId, int c_total, List<LineItems> c_cart)
        {

        }

        public ProductModel AddProducts(ProductModel pName)
        {
            return _repo.AddProduct(pName);
        }

        public List<Inventory> ViewInventoryByStoreId(int c_storeId)
        {
            throw new NotImplementedException();
        }

        public List<Inventory> GetInventory()
        {
            throw new NotImplementedException();
        }
    }
}
