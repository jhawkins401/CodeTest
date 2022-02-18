namespace CodeTest.Exceptions;

public class InsufficientDaysRemainingException : ArgumentException
{
    public InsufficientDaysRemainingException(float daysRequested, float daysRemaining)
        : base(
            $"Not enough vacation time is available, days requested: {daysRequested} - days remaining: {daysRemaining}.")
    {
        
    }
}