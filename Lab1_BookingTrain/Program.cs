using System.Configuration;

string mainFee = ConfigurationManager.AppSettings["MainFee"];

var bookingSystem = new BookingSystem();
bookingSystem.Booking(12);
bookingSystem.Booking(1);
bookingSystem.Booking(6);


public class BookingSystem
{
    public BookingStrategy BookingStrategy { get; set; }
    string mainFee = ConfigurationManager.AppSettings["MainFee"];
    string path = @"C:\Users\asses\source\repos\DesignPattern\Lab1_BookingTrain\BookingRecord.txt";
    public BookingSystem()
    {

    }

    public double Booking(int month)
    {
        string saveRecordLine = "";
        if (month == 12)
        {
            BookingStrategy = new DoubleFeeBooking();
            saveRecordLine = $"{mainFee} {month} 0 {BookingStrategy.Booking()}";
        }else if (month == 6 || month == 7)
        {
            BookingStrategy = new DiscountBooking();
            saveRecordLine = $"{mainFee} {month} 25 {BookingStrategy.Booking()}";
        }
        else
        {
            BookingStrategy = new NormalBooking();
            saveRecordLine = $"{mainFee} {month} 0 {BookingStrategy.Booking()}";
        }

       
        try
        {
            StreamWriter writer = new StreamWriter(path, true);
            writer.WriteLine(saveRecordLine);
            writer.Close();
        }
        catch (IOException e)
        {
            Console.WriteLine(e.Message);
        }
       

        return BookingStrategy.Booking();
    }


}

public interface BookingStrategy
{
    
    public double Booking();
}

public class NormalBooking : BookingStrategy
{
    string mainFee = ConfigurationManager.AppSettings["MainFee"];
    
    public double Booking()
    {

        return Convert.ToDouble(mainFee);
    }
}

public class DiscountBooking : BookingStrategy
{
    string mainFee = ConfigurationManager.AppSettings["MainFee"];
    public double Booking()
    {
        return Convert.ToDouble(mainFee)*0.75;
    }
}

public class DoubleFeeBooking : BookingStrategy
{
    string mainFee = ConfigurationManager.AppSettings["MainFee"];
    public double Booking()
    {
        return Convert.ToDouble(mainFee) * 2;
    }
}