namespace MemorabiliaModel
{
public class Memorabilia
{
    public int ProductId { get; set; }
    public string Name { get; set; }
    private int _price;
    public int Price
    {
        get {return _price; }
        set
        {
            if (value > 0)
                {
                    _price = value; 
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
