namespace CodeTestV2.Core.Interfaces.Employees;

public interface IVacation
{ 
    /// <summary>
    /// Use vacation days, if available.
    /// </summary>
    /// <param name="vacationDaysRequested"></param>
    void TakeVacation(float vacationDaysRequested);
}