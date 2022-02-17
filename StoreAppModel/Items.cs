namespace LineItemModel
{
    public class Items
    {
        //Acts as our primary key 
        public int ItemId { get; set;}
        public string Product { get; set; }
        public int _quantity { get; set; }
        public int Quantity
        {
            get {return Quantity;}
            set
            {
                if (value >= 0)
                {
                    Quantity = value; 
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
    
