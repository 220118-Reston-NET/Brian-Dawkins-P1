using System.Collections.Generic;
using CustomerModel;
using Moq;
using Xunit;
using StoreBL;
using StoreAppDL;
using StoreFrontModel;
using OrderModel;
using StoreAppModel;

namespace StoreUnitTest 
{
    public class ShopBLTest
    {
        [Fact]
        public void Should_Get_Customer()
        {
            //Arrange
            string c_name = "Brian";
            Customer custom = new Customer()
            {
                Name = c_name
            };

            List<Customer> expectedListOfCustomer = new List<Customer>();
            expectedListOfCustomer.Add(custom);

            //We are mocking one of the required dependecies of StoreAppBL which is IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedListOfCustomer);

            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object);       
            
            //Act 
            List<Customer> actualListOfCustomer = _storeBL.GetAllCustomers();
        
            //Assert
            Assert.Same(expectedListOfCustomer, actualListOfCustomer); //Checks if both list are the same thing
            Assert.Equal(c_name, actualListOfCustomer[0].Name); //Checks the first element of actualListOfCustomer to have the same name
        }

        [Fact]
        public void Should_Get_Employee()
        {

            //Arrange
            int c_empId = 0;
            string pass = "Testpassword";
            Employee emp = new Employee()
            {
                EmployeeId = c_empId,
                password = pass
            };

            List<Employee> expectedListOfEmployee = new List<Employee>();
            expectedListOfEmployee.Add(emp);

            //We are mocking one of the required dependecies of StoreAppBL which is IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetEmployee(c_empId, pass)).Returns(expectedListOfEmployee);

            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object);  

            //Act
            List<Employee> actualListOfEmployee = _storeBL.GetEmployee(c_empId, pass);

            //Assert
            Assert.Same(expectedListOfEmployee, actualListOfEmployee); //Checks if both list are the same thing
            Assert.Equal(c_empId, actualListOfEmployee[0].EmployeeId); //Checks the first element of actualListOfEmployee to have the same Id
            Assert.Equal(pass, actualListOfEmployee[0].password); //Checks the first element of actualListOfEmployee to have the same password   
            
        }

        [Fact]
        public void Should_Get_Order_By_Id()
        {
            //Arrange
            int c_customerId = 2;
            Orders ord = new Orders()
            {
              CustomerId = c_customerId
            };

            List<Orders> expectedListOfOrders = new List<Orders>();
            expectedListOfOrders.Add(ord);

            //We are mocking one of the required dependecies of StoreAppBL which is IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetOrdersByCustomerId(c_customerId)).Returns(expectedListOfOrders);
        
            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 
            
            //Act
            List<Orders> actualListOfOrders = _storeBL.GetOrdersByCustomerId(c_customerId);
            
            //Assert
            Assert.Same(expectedListOfOrders, actualListOfOrders); //Checks if both list are the same thing
            Assert.Equal(c_customerId, actualListOfOrders[0].CustomerId); //Checks the first element of actualListOfEmployee to have the same Id
        }

        [Fact]
        public void Should_Get_Inventory()
        {
            int c_storeId = 2;
            StoreFront _store = new StoreFront()
            {
              StoreId = c_storeId
            };

            List<StoreFront> expectedListOfStores = new List<StoreFront>();
            expectedListOfStores.Add(_store);

            //We are mocking one of the required dependecies of StoreAppBL which is IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.ViewInventory(c_storeId)).Returns(expectedListOfStores);
        
            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 
            
            //Act
            List<StoreFront> actualListOfStores = _storeBL.ViewInventory(c_storeId);
            
            //Assert
            Assert.Same(expectedListOfStores, actualListOfStores); //Checks if both list are the same thing
            Assert.Equal(c_storeId, actualListOfStores[0].StoreId); //Checks the first element of actualListOfEmployee to have the same Id
        }

        [Fact]
        public void Should_Get_Store()
        {
            StoreFront _store = new StoreFront();

            List<StoreFront> expectedListOfStores = new List<StoreFront>();
            expectedListOfStores.Add(_store);

            //We are mocking one of the required dependecies of StoreAppBL which is IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetAllStores()).Returns(expectedListOfStores);
        
            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 
            
            //Act
            List<StoreFront> actualListOfStores = _storeBL.GetAllStores();
            
            //Assert
            Assert.Same(expectedListOfStores, actualListOfStores); //Checks if both list are the same thing
            
        }

        [Fact]
        public void Should_Get_Products()
        {
            ProductModel _product = new ProductModel();

            List<ProductModel> expectedListOfProducts = new List<ProductModel>();
            expectedListOfProducts.Add(_product);

            //We are mocking one of the required dependecies of StoreAppBL which is IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetProducts()).Returns(expectedListOfProducts);
        
            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 
            
            //Act
            List<ProductModel> actualListOfStores = _storeBL.GetProducts();
            
            //Assert
            Assert.Same(expectedListOfProducts, actualListOfStores); //Checks if both list are the same thing
            
        }

        [Fact]
        public void Should_Add_Customer()
        {
            //Arrange
            string name = "Brian";
            Customer _customer = new Customer()
            {
                Name = name,
                Address = "5058 Brighton Drive",
                PhoneNumber = "888-888-8888"
            };

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.AddCustomer(_customer)).Returns(_customer);
        
            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 

            //Act 
            Customer actualCustomer = _storeBL.AddCustomer(_customer);

            //Assert
            Assert.Same(_customer, actualCustomer);
            Assert.NotNull(actualCustomer);
        }

        [Fact]
        public void Should_Add_Product()
        {
            //Arrange
            string name = "test";
            ProductModel _product = new ProductModel()
            {
                pName = name
            };

            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.AddProduct(_product)).Returns(_product);
        
            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 

            //Act
            ProductModel actualProduct = _storeBL.AddProduct(_product);

            //Assert
            Assert.Same(_product, actualProduct);
            Assert.NotNull(actualProduct);
        }

        [Fact]
        public void Should_Get_Store_By_Id()
        {
            int _storeId = 2;
            StoreFront _newStore = new StoreFront()
            {
                StoreId = _storeId
            };

            List<StoreFront> expectedListOfStores = new List<StoreFront>();
            expectedListOfStores.Add(_newStore);

            //We are mocking one of the required dependecies of StoreAppBL which is IRepository
            Mock<IRepository> mockRepo = new Mock<IRepository>();

            //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
            //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
            mockRepo.Setup(repo => repo.GetStoresById(_storeId)).Returns(expectedListOfStores);
        
            //We passed in the mock version of IRepository
            IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 
            
            //Act
            List<StoreFront> actualListOfStores = _storeBL.GetStoresById(_storeId);
            
            //Assert
            Assert.Same(expectedListOfStores, actualListOfStores); //Checks if both list are the same thing
            Assert.Equal(_storeId, actualListOfStores[0].StoreId);

        }

        // [Fact]
        // public void Should_Replinish_Inventory()
        // {
        //     //Arrange
        //     int _storeId = 2;
        //     int _productId = 2;
        //     int _quantity = 100;
        //     StoreFront _newStore = new StoreFront()
        //     {
        //         StoreId = _storeId,
        //         ProductId = _productId,
        //         Quantity = _quantity
        //     };

        //     List<StoreFront> expectedListOfStores = new List<StoreFront>();
        //     expectedListOfStores.Add(_newStore);

        //     //We are mocking one of the required dependecies of StoreAppBL which is IRepository
        //     Mock<IRepository> mockRepo = new Mock<IRepository>();

        //     //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
        //     //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
        //     mockRepo.Setup(repo => repo.ReplenishInventory(_newStore)).Returns(_newStore);
        
        //     //We passed in the mock version of IRepository
        //     IStoreFrontBL _storeBL = new StoreFrontBL(mockRepo.Object); 
            
        //     //Act
        //     List<StoreFront> actualListOfStores = _storeBL.ViewInventory(_newStore);
            
        //     //Assert
        //     Assert.Same(expectedListOfStores, actualListOfStores); //Checks if both list are the same thing
        //     Assert.Equal(_newStore, actualListOfStores[0].StoreId); 
        
        //     // When
        
        //     // Then
        }
        }
        
    
