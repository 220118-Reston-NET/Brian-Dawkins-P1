using OrderModel;

namespace CustomerModel
{
    public class Customer 
    { 
        //Acts as our primary key
        public int CustomerId { get; set;}
        public string Name { get; set;}
        private string _address { get; set; }
         public string Address 
        {
            get {return _address; }
            set {_address = value; }
            //Make sure to understand why set was needed here when you added it 
        }
        private string _phoneNumber { get; set; }
        public string PhoneNumber
        {
            get { return _phoneNumber; }
            set { _phoneNumber = value; }

        }
        //public string listOfOrders { get; set; }
        private List<Orders> _orders;
        public List<Orders> Orders
        {
            get {return _orders; }
            set { _orders = value; }
        }

        public override string ToString()
        {
            return $"Id: {CustomerId}\nName: {Name}\nAddress: {Address}\nPhoneNumber: {PhoneNumber}\n";
        }

       
        
    }
}