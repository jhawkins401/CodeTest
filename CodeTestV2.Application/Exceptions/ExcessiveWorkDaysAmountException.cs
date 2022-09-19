namespace CodeTestV2.Application.Exceptions;

public class ExcessiveWorkDaysAmountException : ArgumentException
{
    public ExcessiveWorkDaysAmountException(int daysProvided, int maximumWorkDays)
        : base(
            $"Excessive total work day count when adding {daysProvided}.  The amount provided cannot allow employee to exceed {maximumWorkDays}.  Reduce by {daysProvided - maximumWorkDays}")
    {
    }
}