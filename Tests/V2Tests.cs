using CodeTestV2.Application;
using CodeTestV2.Application.Exceptions;
using CodeTestV2.Application.Extensions;
using CodeTestV2.Application.Factories;
using CodeTestV2.Application.Models;

using Xunit;

namespace Tests;

public class V2Tests
{
    [Theory]
    [InlineData(EmployeeType.Hourly, Constants.MaxWorkDays, 1)]
    [InlineData(EmployeeType.Hourly, Constants.MaxWorkDays, .5)]
    [InlineData(EmployeeType.Salaried, Constants.MaxWorkDays, 1)]
    [InlineData(EmployeeType.Salaried, Constants.MaxWorkDays, .5)]
    [InlineData(EmployeeType.Manager, Constants.MaxWorkDays, 1)]
    [InlineData(EmployeeType.Manager, Constants.MaxWorkDays, .5)]
    public void Employee_Work_Should_Succeed(EmployeeType type, int daysWorked, float reductionMultiplier)
    {
        // arrange
        var e = EmployeeFactory.CreateEmployee(type) as Employee;
        var daysToWork = daysWorked * reductionMultiplier;

        //act
        e.Work((int) daysToWork);

        //assert
        Assert.Equal(e.GetVacationDaysForEmployeeType() * reductionMultiplier, e.VacationDaysCurrentBalance);
    }
    
    //Vacation
    [Theory]
    [InlineData(EmployeeType.Hourly, 1)]
    [InlineData(EmployeeType.Hourly, .5)]
    [InlineData(EmployeeType.Hourly, 0)]
    [InlineData(EmployeeType.Salaried, 1)]
    [InlineData(EmployeeType.Salaried,  .5)]
    [InlineData(EmployeeType.Salaried,  0)]
    [InlineData(EmployeeType.Manager,  1)]
    [InlineData(EmployeeType.Manager, .5)]
    [InlineData(EmployeeType.Manager, 0)]
    public void Employee_Vacation_Should_Succeed(EmployeeType type, float reductionMultiplier)
    {
        // arrange
        var e = EmployeeFactory.CreateEmployee(type) as Employee;
        e.Work(Constants.MaxWorkDays);

        var maxVacationDays = e.GetVacationDaysForEmployeeType();
        var reductionAmount = maxVacationDays * reductionMultiplier;
        
        var expectedBalance = maxVacationDays - reductionAmount; 
        
        //act
        e.TakeVacation(reductionAmount);
        
        //assert
        Assert.Equal(expectedBalance, e.VacationDaysCurrentBalance);
    }
    
    // Exceptions
    
    [Theory] 
    [InlineData(EmployeeType.Hourly, 261)]
    [InlineData(EmployeeType.Salaried,  261)]
    [InlineData(EmployeeType.Manager, 261)]
    public void Should_Throw_ExcessiveWorkException_Work(EmployeeType type, int daysWorked)
    {
        // arrange
        var e = EmployeeFactory.CreateEmployee(type) as Employee;
        
        //act and assert
        Assert.Throws<ExcessiveWorkDaysAmountException>(() => e.Work(daysWorked));
    }
    
    [Theory] 
    [InlineData(EmployeeType.Hourly)]
    [InlineData(EmployeeType.Salaried)]
    [InlineData(EmployeeType.Manager)]
    public void Should_Throw_Exception_Take_Vacation(EmployeeType type)
    {
        // arrange
        var e = EmployeeFactory.CreateEmployee(type) as Employee;
        var maxVacationDays = e.GetVacationDaysForEmployeeType();
        
        e.Work(Constants.MaxWorkDays);
        
        //act and assert
        Assert.Throws<InsufficientDaysRemainingException>(() => e.TakeVacation(maxVacationDays + 1));
    }
    
    [Theory] 
    [InlineData(EmployeeType.Hourly)]
    [InlineData(EmployeeType.Salaried)]
    [InlineData(EmployeeType.Manager)]
    public void Employee_Should_Throw_Exception(EmployeeType type)
    {
        // arrange
        var e = EmployeeFactory.CreateEmployee(type) as Employee;

        // act and assert
        Assert.Throws<InsufficientDaysProvidedException>(() => e.Work(0));
    }
}
