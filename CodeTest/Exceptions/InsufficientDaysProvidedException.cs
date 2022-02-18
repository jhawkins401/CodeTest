namespace CodeTest.Exceptions;

/// <summary>
/// The exception that is thrown when the day value provided is too low (less than or equal 0).
/// </summary>
public class InsufficientDaysProvidedException : ArgumentException
{
    public InsufficientDaysProvidedException(int daysProvided)
        : base($"Insufficient day count of {daysProvided}. The amount provided must be greater than 0!")
    {
    }
}