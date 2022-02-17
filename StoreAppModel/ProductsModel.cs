namespace StoreAppModel
{
    public class ProductModel
    {
        public int productID {get;set;}
        public string pName {get;set;}
        public string Description {get;set;}
        public double Price {get;set;}
    
        public override string ToString()
        {
            return $"ID: {productID}\n Name: {pName}";
        }
    }

    
}