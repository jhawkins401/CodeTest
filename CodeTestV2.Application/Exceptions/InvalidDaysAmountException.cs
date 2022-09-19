namespace CodeTestV2.Application.Exceptions;

/// <summary>
/// The exception that is thrown when the day value provided is out of the expected range.
/// </summary>
public class InvalidDaysException : ArgumentException
{
    public InvalidDaysException(int providedDayCount, int maximumDayCount, string propertyName)
        : base($"{propertyName}'s value: {providedDayCount} is invalid, {propertyName} needs to be set to an integer value between 0 and {maximumDayCount}")
    {
        
    }
}