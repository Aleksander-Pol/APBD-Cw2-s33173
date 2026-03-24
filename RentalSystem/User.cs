namespace RentalSystem;

public abstract class User (string name, string surname, string userType)
{
    private static int _nextId = 1;
    public int Identifier { get; } = _nextId++;
    
    public string Name { get; set; } = name;
    public string Surname { get; set; } = surname;
    public string UserType { get; set; } = userType;

    public abstract int MaxRentalCount { get; }
    public int CurrentRentalCount { get; set; } = 0;



}