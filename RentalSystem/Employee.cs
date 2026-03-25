namespace RentalSystem;

public class Employee (string name, string surname, double salary, string subject) : User (name, surname,  "Employee")
{
    public double Salary { get; set; } = salary;
    public string Subject  { get; set; } = subject;
    public override int MaxRentalCount { get; } = 5;
    
}