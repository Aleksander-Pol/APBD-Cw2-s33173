namespace RentalSystem;

class Program
{
    static void Main(string[] args)
    {
       var rentalService = new RentalService();

       var laptop = new Laptop("Acer Swift Go 14", DeviceStatus.Available, 100, "Intel Irix Xe", "Business");
       var camera = new Camera("Sony Alpha", DeviceStatus.Available, 90, "4K", "10x");
       var projector = new Projector("Epson", DeviceStatus.Available, 50, 3000, "10000:1");
       
       rentalService.AddDevice(laptop);
       rentalService.AddDevice(camera);
       rentalService.AddDevice(projector);

       var student = new Student("Andy", "Weir", "s33982", 2);
       var employee = new Employee("Ryland", "Grace", 6400, "Physics");
       
       rentalService.AddUser(student);
       rentalService.AddUser(employee);

       Console.WriteLine("Successfull rental: ");
       rentalService.RentDevice(student, laptop, 5);
       rentalService.RentDevice(employee, camera, 2);

       Console.WriteLine("Unsuccessfull rental: ");
       rentalService.RentDevice(employee, laptop, 5);

       Console.WriteLine("Return within deadline: ");
       rentalService.ReturnDevice(student, laptop);

       Console.WriteLine("Return after deadline: ");
       rentalService.ReturnDevice(employee, camera, 6 );

       Console.WriteLine("\nReport:");
       rentalService.GenerateReport();
    }
}