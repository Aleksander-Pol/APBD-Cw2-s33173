namespace RentalSystem;

public class Rental (DateTime rentDate, DateTime dueDate, User user, Device device)
{
    private static int _nextId = 1;
    public int Identifier { get; } = _nextId++;

    public User User { get; } = user;
    public Device Device {get; } = device;

    public DateTime RentDate { get; } = rentDate;
    public DateTime DueDate { get; } = dueDate;
    public DateTime? ReturnDate { get; private set; }
    public double PriceOfPenalty { get; private set; } = 0;

    public bool IsReturnedOnTime => ReturnDate.HasValue && ReturnDate <= DueDate;

    public void MarkReturn(DateTime returnDate)
    {
        if (returnDate < RentDate) throw new  Exception("ReturnDate is before RentDate");
        ReturnDate = returnDate;
    }

    public void SetPenalty()
    {
        if (ReturnDate == null) throw new Exception("ReturnDate is null");
        var difference = ReturnDate.Value - DueDate;
        PriceOfPenalty = difference.TotalDays * 0.05 * Device.Price;
    }

}