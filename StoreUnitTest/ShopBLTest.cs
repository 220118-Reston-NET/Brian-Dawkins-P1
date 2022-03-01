using System.Collections.Generic;
using CustomerModel;
using Moq;
using Xunit;
using StoreBL;
using StoreAppDL;
using StoreFrontModel;
using OrderModel;

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
    }
}