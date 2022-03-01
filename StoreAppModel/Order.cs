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
        private double _total;
        public double Total
        {
            get {return _total; }
            set
            {
                if (value > 0)
                {
                    _total = value; 
                }
                else
                {
                    throw new Exception("You cannot have a negative Total!");
                }
            }
        }

        public DateTime DateCreated { get; set; }

        public int CustomerId { get; set; }
        public string StoreLocation {get; set; }

        public Orders()
        {
            OrderId = 0;
            StoreId = 2;
            _total = 50;
            DateCreated = new DateTime();
            CustomerId = 5;
            StoreLocation = "Southside";
            Location = "Northiside";

        }
         
        public override string ToString()
        {
            return $"Id: {CustomerId}\nOderId: {OrderId}\nStoreId: {StoreId}\nTotal: {_total}\n";
        }
    }
}