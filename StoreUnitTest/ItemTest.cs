using LineItemModel;
using Xunit;

namespace StoreUnitTest
{
    public class ItemTest
    {
        /// <summary>
        /// Checks the validation for Name property for valid data
        /// </summary>
        /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
        [Fact]
        public void ProductShouldSetValidData()
        {
            //Arrange
            Items prod = new Items();
            string validProd = "Jersey";

            //Act
            prod.Product = validProd;
        
            //Assert
            Assert.NotNull(prod.Product);//checks that the property is not null meaning we did set data in this property
            Assert.Equal(validProd, prod.Product);//checks if the property does indeed hold the same value as what we set it as
        }
        /// <summary>
        /// Checks the validation for Name property for valid data
        /// </summary>
        /// [Fact] is a data annotation in C# and all it means is it will tell the compiler that this specific method is a unit test
        [Fact]
        public void QuantityShouldSetValidData()
        {
            //Arrange
            Items quant = new Items();
            int validquant = 10;

            //Act
            quant._quantity = validquant;

            //Assert
            Assert.NotNull(quant._quantity);//checks that the property is not null meaning we did set data in this property
            Assert. Equal(validquant, quant._quantity);//checks if the property does indeed hold the same value as what we set it as
        }
    }
}