namespace MemorabiliaModel
{
public class Memorabilia
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    public int _price { get; set; }
    public int Price
    {
        get {return Price; }
        set
        {
            if (value > 0)
                {
                    Price = value; 
                }
                else
                {
                    throw new Exception("You cannot have a negative price!");
                }
        }
    }
    public string Category { get; set; }
    // public Memorabilia()
    // {
    //     Name = "";
    //     Price = 0;
    //     Category = "";
    // }

    public override string ToString()
    {
        return $"=================\nId: {ProductId}\nName: {Name}\nPrice: {_price}\nCatogory: {Category}";
    }

    }
}
