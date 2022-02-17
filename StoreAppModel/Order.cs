using LineItemModel;

namespace OrderModel
{
    public class Orders 
    {
        //Acts as our primary key
        public int OrderId { get; set; }
        public int StoreId { get; set; }
        private List<Items> _lineItems; 
        public List<Items> LineItems
        {
            get{ return _lineItems; }
            set
            {
                _lineItems = value;
            }
        }
        public string Location { get; set ;}
        public double _total {get; set; }
        public double Total
        {
            get {return Total; }
            set
            {
                if (value > 0)
                {
                    Total = value; 
                }
                else
                {
                    throw new Exception("You cannot have a negative Total!");
                }
            }
        }

        public int CustomerId { get; set; }
        public string StoreLocation {get; set; }
         
        public override string ToString()
        {
            return $"Id: {CustomerId}\nOderId: {OrderId}\nStoreId: {StoreId}\nTotal: {_total}\n";
        }
    }
}