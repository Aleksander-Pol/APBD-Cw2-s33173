namespace RentalSystem;

public class Student (string name, string surname, string UserType, string sNumber, int semester) : User (name, surname, UserType)
{
    public string Snumber { get; set; } = sNumber;
    public int Semester { get; set; } = semester;


    public override int MaxRentalCount { get; } = 2;
    
}