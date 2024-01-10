/// <summary>
/// Класс, представляющий дату (день, месяц, год).
/// </summary>
public class Date
{
    private readonly int day;
    private readonly int month;
    private readonly int year;

    /// <summary>
    /// Конструктор класса Date.
    /// </summary>
    /// <param name="day">День.</param>
    /// <param name="month">Месяц.</param>
    /// <param name="year">Год.</param>
    public Date(int day, int month, int year)
    {
        this.day = day;
        this.month = month;
        this.year = year;
    }

    /// <summary>
    /// Перегрузка оператора + для добавления дней к дате.
    /// </summary>
    public static Date operator +(Date date, int daysToAdd) => date.AddDays(daysToAdd);

    /// <summary>
    /// Перегрузка оператора - для вычитания дней из даты.
    /// </summary>
    public static Date operator -(Date date, int daysToSubtract) => date.AddDays(-daysToSubtract);

    /// <summary>
    /// Перегрузка оператора == для сравнения двух объектов даты.
    /// </summary>
    public static bool operator ==(Date date1, Date date2) => date1.Equals(date2);

    /// <summary>
    /// Перегрузка оператора != для сравнения двух объектов даты.
    /// </summary>
    public static bool operator !=(Date date1, Date date2) => !date1.Equals(date2);

    /// <summary>
    /// Метод для вывода даты в формате "дд.мм.гггг".
    /// </summary>
    public string ToShortDateString() => $"{day:D2}.{month:D2}.{year:D4}";

    /// <summary>
    /// Метод для вывода даты в формате "месяц день, год".
    /// </summary>
    public string ToLongDateString() => $"{GetMonthName(month)} {day}, {year}";

    /// <summary>
    /// Метод для добавления или вычитания дней из даты.
    /// </summary>
    private Date AddDays(int days)
    {
        DateTime dateTime = new DateTime(year, month, day).AddDays(days);
        return new Date(dateTime.Day, dateTime.Month, dateTime.Year);
    }

    /// <summary>
    /// Переопределение метода Equals для сравнения двух объектов Date.
    /// </summary>
    public override bool Equals(object obj) =>
        obj is Date otherDate && day == otherDate.day && month == otherDate.month && year == otherDate.year;

    /// <summary>
    /// Переопределение метода GetHashCode.
    /// </summary>
    public override int GetHashCode() => day.GetHashCode() ^ month.GetHashCode() ^ year.GetHashCode();

    /// <summary>
    /// Метод для получения названия месяца по его номеру.
    /// </summary>
    private string GetMonthName(int monthNumber) => new DateTime(year, monthNumber, 1).ToString("MMMM");

    /// <summary>
    /// Статический метод для получения текущей даты.
    /// </summary>
    public static Date Today() => new Date(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
}

class Program
{
    static void Main()
    {
        // Пример использования класса Date 
        Date date1 = Date.Today();
        Date date2 = date1 + 10;
        Date date3 = date2 - 25;

        Console.WriteLine("Дата 1: " + date1.ToShortDateString());
        Console.WriteLine("Дата 2: " + date2.ToLongDateString());
        Console.WriteLine("Дата 3: " + date3.ToShortDateString());

        // Проверка операторов == и != 
        Console.WriteLine("Даты равны: " + (date1 == date2));
        Console.WriteLine("Даты не равны: " + (date1 != date2));
    }
}
