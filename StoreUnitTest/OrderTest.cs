using OrderModel;
using Xunit;

namespace StoreUnitTest
{
    public class OrderTest
    {
        /// <summary>
        /// Checks the validation for Name property for valid data
        /// </summary>
        /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
        [Fact]
        public void LocationShouldSetValidData()
        {
            //Arrange
            Orders loc = new Orders();
            string validlocation = "Southside Location";
        
            //Act
            loc.Location = validlocation;
        
            //Assert
            Assert.NotNull(loc.Location);//checks that the property is not null meaning we did set data in this property
            Assert.Equal(validlocation, loc.Location); //checks if the property does indeed hold the same value as what we set it as
        }
        /// <summary>
        /// Checks the validation for Name property for valid data
        /// </summary>
        /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
        [Fact]
        public void TotalShouldSetValidData()
        {
            //Arrange
            Orders tot = new Orders();
            double validtotal = 22.50;
        
            //Act
            tot._total = validtotal;
        
            //Assert
            Assert.NotNull(tot._total);//checks that the property is not null meaning we did set data in this property
            Assert.Equal(validtotal, tot._total);//checks if the property does indeed hold the same value as what we set it as
        }
    }
}