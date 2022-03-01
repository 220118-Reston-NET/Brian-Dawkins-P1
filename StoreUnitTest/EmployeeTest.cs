using Xunit;
using StoreFrontModel;

namespace StoreUnitTest;

public class EmployeeTest
{
    /// <summary>
    ///  Checks the validation for Name property for valid data
    /// </summary>
    [Fact]
    public void Employee_Should_Set_Valid_Data()
    {
        //Arrange
        Employee emp = new Employee();
        string validname = "Test";
    
        //Act
        emp.Name = validname;
    
        //Assert
         Assert.NotNull(emp.Name); //checks that the property is not null meaning we did set data in this property
        Assert.Equal(validname, emp.Name); //checks if the property does indeed hold the same value as what we set it as
    }
}