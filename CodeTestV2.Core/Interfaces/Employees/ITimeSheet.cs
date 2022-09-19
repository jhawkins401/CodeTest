namespace CodeTestV2.Core.Interfaces.Employees;

public interface ITimeSheet
{
    /// <summary>
    /// The amount of vacation days an employee has accumulated this year.
    /// </summary>
    float VacationDaysAccumulated { get; set; }
    
    /// <summary>
    /// The amount of vacation days remaining.
    /// </summary>
    float VacationDaysCurrentBalance { get; set; }
    
    /// <summary>
    /// The amount of work days completed thus far this year.
    /// </summary>
    ushort TotalDaysWorkedThisYear { get; set; }
}