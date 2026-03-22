namespace RentalSystem;

public class Camera(string name, DeviceStatus status, int price, string resolution, string zoom) : Device (name, status, price)
{
    public string Resolution { get; set; } = resolution;
    public string Zoom { get; set; } = zoom;

}