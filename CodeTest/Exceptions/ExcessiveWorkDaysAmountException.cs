namespace CodeTest.Exceptions;

public class ExcessiveWorkDaysAmountException : ArgumentException
{
    public ExcessiveWorkDaysAmountException(int daysProvided, int maximumWorkDays, int amountOver)
        : base($"Excessive total work day count when adding {daysProvided}. The amount provided cannot allow employee to exceed {maximumWorkDays}.")
    {
    }
}