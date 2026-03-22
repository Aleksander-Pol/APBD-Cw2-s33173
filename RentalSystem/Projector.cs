namespace RentalSystem;

public class Projector(string name, DeviceStatus status, int price, int brightnessInLumens, string contrast) : Device(name, status, price)
{
    public int BrightnessInLumens { get; set; } = brightnessInLumens;
    public string Contrast {get; set;} =contrast;

}