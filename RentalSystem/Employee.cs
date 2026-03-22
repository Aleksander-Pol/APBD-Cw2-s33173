namespace RentalSystem;

public class Employee (string name, string surname, string userType, double salary, string subject) : User (name, surname,  userType)
{
    public double Salary { get; set; } = salary;
    public string Subject  { get; set; } = subject;
}