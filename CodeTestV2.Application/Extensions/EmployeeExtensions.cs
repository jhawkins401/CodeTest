using CodeTestV2.Application.Exceptions;
using CodeTestV2.Application.Models;

namespace CodeTestV2.Application.Extensions;

public static class Constants
{
    public const ushort MaxWorkDays = 260;
    public const ushort HourlyAnnualVacation = 10;
    public const ushort SalariedAnnualVacation = 15;
    public const ushort ManagerAnnualVacation = 30;
}

public static class EmployeeWorkExtensions
{
    public static void AddWorkDays(this Employee employee, ushort daysWorked)
    {
        employee
            .TryAddWork(daysWorked)
            .UpdateVacationDays(daysWorked);
    }

    private static Employee TryAddWork(this Employee employee, 
        ushort daysWorked)
    {
        if (!daysWorked.ValidPositiveValue())
            throw new InsufficientDaysProvidedException(daysWorked);
        
        var newTotalDaysWorked = (ushort) (employee.TotalDaysWorkedThisYear + daysWorked);
        
        if (!newTotalDaysWorked.ValidUnderMaxWorkDays())
            throw new ExcessiveWorkDaysAmountException(daysWorked, Constants.MaxWorkDays);

        employee.TotalDaysWorkedThisYear = newTotalDaysWorked;

        return employee;
    }
    
}

public static class EmployeeVacationExtensions
{
    public static void UpdateVacationDays(this Employee employee, ushort daysWorked)
    {
        var vacationDaysEarned = employee.CalculateVacationDaysEarned(daysWorked);
        
        employee.VacationDaysAccumulated += vacationDaysEarned;
        employee.VacationDaysCurrentBalance += vacationDaysEarned;
    }
    
    private static float CalculateVacationDaysEarned(
        this Employee employee, ushort daysWorked)
    {
        var vacationDays = employee.CalculateVacationIncrement() * daysWorked;
        
        if (employee.ValidVacationUnderMax(vacationDays))
            vacationDays = employee.CalculateAllowableVacationIncrease();

        if (vacationDays <= 0)
            throw new Exception();

        return vacationDays;
    }
    
    private static bool ValidVacationUnderMax(this Employee employee, float vacationDaysEarned) 
        => vacationDaysEarned + employee.VacationDaysAccumulated > employee.GetVacationDaysForEmployeeType();

    private static float CalculateAllowableVacationIncrease(this Employee employee)
        => employee.GetVacationDaysForEmployeeType() - employee.VacationDaysAccumulated;
    
    private static float CalculateVacationIncrement(this Employee employee)
        => (float)employee.GetVacationDaysForEmployeeType() / Constants.MaxWorkDays; 

    public static ushort GetVacationDaysForEmployeeType(this Employee employee)
        => employee switch
        {
            HourlyEmployee => Constants.HourlyAnnualVacation,
            ManagerEmployee => Constants.ManagerAnnualVacation,
            SalariedEmployee => Constants.SalariedAnnualVacation,
            _ => throw new Exception()
        };
    
    public static void SubtractVacationDaysUsedForEmployee(
        this Employee employee,
        float vacationDaysRequested)
    {
        if (vacationDaysRequested > employee.VacationDaysCurrentBalance)
            throw new InsufficientDaysRemainingException(vacationDaysRequested, employee.VacationDaysCurrentBalance);
        
        employee.VacationDaysCurrentBalance -= vacationDaysRequested;
    }
}

public static class DataExtensions
{
    public static bool ValidPositiveValue(this ushort daysWorked) => daysWorked > 0;
    public static bool ValidUnderMaxWorkDays(this ushort daysWorked) => Constants.MaxWorkDays >= daysWorked;
}