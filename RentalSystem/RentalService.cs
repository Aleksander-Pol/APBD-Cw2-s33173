namespace RentalSystem;

public class RentalService
{
    private List<User> _users;
    private List<Device> _devices;


    public RentalService()
    {
        _users = new List<User>();
        _devices = new List<Device>();
    }
    
    public void AddUser(User user)
    {
        _users.Add(user);
    }

    public void AddDevice(Device device)
    {
        _devices.Add(device);
    }
    
    
    
}