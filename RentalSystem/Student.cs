namespace RentalSystem;

public class Student (string name, string surname, string sNumber, int semester) : User (name, surname, "Student")
{
    public string Snumber { get; set; } = sNumber;
    public int Semester { get; set; } = semester;
    
    public override int MaxRentalCount { get; } = 2;
    
}