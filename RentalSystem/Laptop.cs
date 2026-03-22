namespace RentalSystem;

public class Laptop(string name, string status, int price, string graphicsCard, string type) :Device (name, status, price)
{
    public string GraphicsCard { get; set; } = graphicsCard;
    public string Type { get; set; } = type;
    

}