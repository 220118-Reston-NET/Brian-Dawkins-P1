namespace LineItemModel
{
    public class Items
    {
        //Acts as our primary key 
        public int ItemId { get; set;}
        public string Product { get; set; }
        private int _quantity;
        public int Quantity
        {
            get {return _quantity;}
            set
            {
                if (value >= 0)
                {
                    _quantity = value; 
                }
                else
                {
                    throw new Exception("You cannot have a quantity lower than 0!");
                }
            }
        }
        public override string ToString()
        {
            return $"===================\nID: {ItemId}\nQuantity: {Quantity}\n";
        }

            }
        }
    
