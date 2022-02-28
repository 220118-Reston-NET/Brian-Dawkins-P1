// using System.Collections.Generic;
// using CustomerModel;
// using Moq;
// using Xunit;
// using StoreBL;
// using StoreAppDL;
// using StoreFrontModel;

// namespace StoreUnitTest 
// {
//     public class ShopBLTest
//     {
//         [Fact]
//         public void Should_Get_Customer()
//         {
//             //Arrange
//             string c_name = "Brian";
//             Customer custom = new Customer()
//             {
//                 Name = c_name
//             };

//             List<Customer> expectedListOfCustomer = new List<Customer>();
//             expectedListOfCustomer.Add(custom);

//             //We are mocking one of the required dependecies of StoreAppBL which is IRepository
//             Mock<IRepository> mockRepo = new Mock<IRepository>();

//             //We change that if our IRepository.GetAllCustomers() is called it will always return our expectedListOfPoke
//             //In this way we guaranteed taht our dependency will always work so is something goes wrong it is the business layer's fault
//             mockRepo.Setup(repo => repo.GetAllCustomers()).Returns(expectedListOfCustomer);

//             //We passed in the mock version of IRepository
//             IStoreFrontBL _storeBL = new IStoreFrontBL(mockRepo.Object);       
            
//             //Act 
//             List<Customer> actualListOfCustomer = StoreFrontBL.GetAllCustomers();
        
//             //Assert
//             Assert.Same(expectedListOfCustomer, actualListOfCustomer); //Checks if both list are the same thing
//             Assert.Equal(c_name, actualListOfCustomer[0].Name); //Checks the first element of actualListOfCustomer to have the same name
//         }
//     }
// }