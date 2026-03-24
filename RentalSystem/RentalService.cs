namespace RentalSystem;

public class RentalService
{
    private List<User> _users;
    private List<Device> _devices;
    private List<Rental> _rentals;


    public RentalService()
    {
        _users = new List<User>();
        _devices = new List<Device>();
        _rentals = new List<Rental>();
    }
    
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }


    public void PrintAllDevices()
    {
        foreach (var device in _devices)
            Console.WriteLine(device.Name +": " + device.Status);
    }

    public void PrintAllAvailableDevices()
    {
        foreach (var device in _devices)
        {
            if (device.Status == DeviceStatus.Available)
                Console.WriteLine(device.Name + ": " + device.Status);
        }
    }

    public void RentDevice(User user, Device device, int days)
    {
        if (user.CurrentRentalCount < user.MaxRentalCount && device.Status == DeviceStatus.Available)
        {
            _rentals.Add(new Rental(DateTime.Now,  DateTime.Now.AddDays(days), user, device, device.Price));
            user.CurrentRentalCount++;
            device.Status = DeviceStatus.Unavailable;

            Console.WriteLine($"User {user.Name} rented {device.Name} and currently has {user.CurrentRentalCount} rentals.");
        }
        else Console.WriteLine("Either User exceeded his MaxRentalCount or device is currently unavailable");
    }

    public void ReturnDevice(User user, Device device)
    {
        var rental = _rentals.FirstOrDefault(rental => rental.User == user && rental.Device == device && rental.ReturnDate == null);

        if (rental != null)
        {
            user.CurrentRentalCount--;
            device.Status = DeviceStatus.Available;
            rental.MarkReturn(DateTime.Now);

            Console.WriteLine($"Succesfully returned {rental.Device.Name} from  {user.Name}.");
            if (!rental.IsReturnedOnTime)
            {
                rental.SetPenalty();
                Console.WriteLine($"Penalty for {user.Name} has been set to {rental.PriceOfPenalty}.");
            }
            
        }
    }

    public void MakeDeviceUnavailable(Device device)
    {
        if (device.Status == DeviceStatus.Unavailable)
            Console.WriteLine($"Device {device.Name} has already been unavailable.");
        else if (_rentals.Any(rental => rental.Device == device && rental.ReturnDate == null))
            Console.WriteLine($"Device  {device.Name} is currently rented.");
        else
        {
            device.Status = DeviceStatus.Unavailable;
            Console.WriteLine($"Successfully changed device {device.Name} status to {device.Status}.");
        }
        
    }

    public void ViewActiveUserRentals(User user)
    {
        foreach (var rental in _rentals)
        {
            if (rental.User == user && rental.ReturnDate == null)
            {
                Console.WriteLine($"User {user.Name} rented {rental.Device.Name}.");
            }
        }
    }

    public void ViewOutdatedRentals()
    {
        foreach (var rental in _rentals)
        {
            if (rental.ReturnDate == null && DateTime.Now > rental.DueDate)
                Console.WriteLine($"{rental.Device.Name} - {rental.User.Name}");
        }
    }

}