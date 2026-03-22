namespace RentalSystem;

public abstract class Device (string name, DeviceStatus status, int price)
{
    private static int _nextId = 1;
    public int Identifier { get; } = _nextId++;
    public string Name { get; set; } = name;
    public DeviceStatus Status { get; set; } = status;
    public int Price { get; set; } =  price;
    
}