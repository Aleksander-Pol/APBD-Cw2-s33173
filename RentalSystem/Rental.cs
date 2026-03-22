namespace RentalSystem;

public class Rental (DateTime rentDate, DateTime dueDate, User user, Device device, double rentalFee)
{
    //•	Wypożyczenie - obiekt opisujący moment wypożyczenia, termin zwrotu, faktyczny zwrot oraz wynikające opłaty lub kary.
    //•	Każde wypożyczenie powinno przechowywać informację: kto, co, kiedy wypożyczył, na jak długo i czy zwrot był terminowy.
    
    private static int _nextId = 1;
    public int Identifier { get; } = _nextId++;

    public User User { get; } = user;
    public Device Device {get; } = device;

    public DateTime RentDate { get; } = rentDate;
    public DateTime DueDate { get; } = dueDate;
    public DateTime? ReturnDate { get; private set; }

    public double RentalFee { get; private set; } = rentalFee;
    public double PriceOfPenalty { get; private set; } = 0;

    public bool IsReturnedOnTime => ReturnDate.HasValue && ReturnDate <= DueDate;

    public void MarkReturn(DateTime returnDate)
    {
        ReturnDate = returnDate;
    }

    public void SetPenalty(double penalty)
    {
        PriceOfPenalty = penalty;
    }

}