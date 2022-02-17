using MemorabiliaModel;
using Xunit;

namespace StoreUnitTest
{
    public class ProductTest
    {
        /// <summary>
        /// Checks the validation for Name property for valid data
        /// </summary>
        /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
        [Fact]
        public void CategoryShouldSetValidData()
        {
            //Arrange
            Memorabilia cat = new Memorabilia();
            string validCat = "Basketball";
        
            //Act
            cat.Category = validCat;
        
            //Assert
            Assert.NotNull(cat.Category);//checks that the property is not null meaning we did set data in this property
            Assert.Equal(validCat, cat.Category);//checks if the property does indeed hold the same value as what we set it as
        }
        /// <summary>
        /// Checks the validation for Name property for valid data
        /// </summary>
        /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
        [Fact]
        public void PriceShouldSetValidData()
        {
            //Arrange
            Memorabilia price = new Memorabilia();
            int validPrice = 5;
        
            //Act
            price._price = validPrice;
        
            //Assert
            Assert.NotNull(price._price);//checks that the property is not null meaning we did set data in this property
            Assert.Equal(validPrice, price._price);//checks if the property does indeed hold the same value as what we set it as
        }
         /// <summary>
    /// Checks the validation for Name property for valid data
    /// </summary>
    /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
    [Fact]
    public void NameShouldSetValidData()
    {
        //Arrange
        Memorabilia prod = new Memorabilia();
        string validName = "Brian Dawkins";
        

        //Act
        prod.Name = validName;

        //Assert
        Assert.NotNull(prod.Name); //checks that the property is not null meaning we did set data in this property
        Assert.Equal(validName, prod.Name); //checks if the property does indeed hold the same value as what we set it as
    }
    }
}