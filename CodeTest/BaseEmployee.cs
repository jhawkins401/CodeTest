using CodeTest.Exceptions;

namespace CodeTest;

public abstract class BaseEmployee
{
/// <summary>
    /// The maximum amount of days an employee works in a year.
    /// </summary>
    private int MaximumDaysEmployeeCanWork { get; }
    
    /// <summary>
    /// The total amount of vacation days an employee can accumulate
    /// if they worked every possible work day.
    /// </summary>
    private int MaximumVacationDaysForEmployeeType { get; }

    /// <summary>
    /// The amount of vacation days an employee has accumulated this year.
    /// </summary>
    private float VacationDaysAccumulated { get; set; }
    
    /// <summary>
    /// The amount of vacation days remaining.
    /// </summary>
    public float VacationDaysCurrentBalance { get; set; }
    
    /// <summary>
    /// The amount of work days completed thus far this year.
    /// </summary>
    private int TotalDaysWorkedThisYear { get; set; }

    /// <summary>
    /// Amount vacation day increases per workday.
    /// </summary>
    private float VacationDaysIncrementBy => (float)MaximumVacationDaysForEmployeeType / MaximumDaysEmployeeCanWork;

    /// <summary>
    /// Instantiates an employee with the option override the default maximum days worked.
    /// </summary>
    /// <param name="maximumVacationDaysForEmployeeType">Sets value for: <see cref="MaximumVacationDaysForEmployeeType"/></param>
    /// <param name="maximumDaysCanWork">If provided, will override the default value for <see cref="MaximumDaysEmployeeCanWork"/></param>
    protected BaseEmployee(int maximumVacationDaysForEmployeeType, int? maximumDaysCanWork = null)
    {
        if (!(maximumVacationDaysForEmployeeType > 0))
        {
            throw new InsufficientDaysProvidedException(maximumVacationDaysForEmployeeType);
        }

        switch (maximumDaysCanWork)
        {
            case < 0:
                throw new InvalidDaysException(
                    (int) maximumDaysCanWork,
                    MaximumDaysEmployeeCanWork,
                    nameof(maximumDaysCanWork));
            case > 0:
                this.MaximumDaysEmployeeCanWork = (int)maximumDaysCanWork;
                break;
            default:
                const int defaultMaximumDaysWorked = 260;
                this.MaximumDaysEmployeeCanWork = defaultMaximumDaysWorked;
                break;
        }

        if (maximumVacationDaysForEmployeeType >= MaximumDaysEmployeeCanWork)
        {
            throw new InvalidDaysException(
                maximumVacationDaysForEmployeeType, 
                MaximumDaysEmployeeCanWork,
                nameof(maximumVacationDaysForEmployeeType));
        }
        
        this.MaximumVacationDaysForEmployeeType = maximumVacationDaysForEmployeeType;
    }

    private void SetNewVacationDaysValue(int daysWorked)
    {
        var vacationDaysEarned = this.VacationDaysIncrementBy * daysWorked;
        this.VacationDaysAccumulated += vacationDaysEarned;
        this.VacationDaysCurrentBalance += vacationDaysEarned;
    }

    private void AddWorkDaysToEmployee(int daysWorked)
    {
        var newTotalDaysWorked = this.TotalDaysWorkedThisYear + daysWorked;
        if (daysWorked <= 0)
        {
            throw new InsufficientDaysProvidedException(daysWorked);
        }

        if (newTotalDaysWorked > this.MaximumDaysEmployeeCanWork)
        {
            var daysOverMax = newTotalDaysWorked - this.MaximumDaysEmployeeCanWork;
            
            throw new ExcessiveWorkDaysAmountException(daysWorked, this.MaximumDaysEmployeeCanWork, daysOverMax);
        }

        this.TotalDaysWorkedThisYear = newTotalDaysWorked;
    }

    private void SubtractVacationDaysUsedForEmployee(float vacationDaysRequested)
    {
        if (vacationDaysRequested > VacationDaysAccumulated)
        {
            throw new InsufficientDaysRemainingException(vacationDaysRequested, this.VacationDaysAccumulated);
        }

        this.VacationDaysCurrentBalance -= vacationDaysRequested;
    }

    public virtual void Work(int daysWorked)
    {
        this.AddWorkDaysToEmployee(daysWorked);
        this.SetNewVacationDaysValue(daysWorked);
    }

    public virtual void TakeVacation(float vacationDaysRequested)
    {
        this.SubtractVacationDaysUsedForEmployee(vacationDaysRequested);
    }

}