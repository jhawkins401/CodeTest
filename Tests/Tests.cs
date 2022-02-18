using CodeTest.Employees;
using CodeTest.Exceptions;
using Xunit;

namespace Tests;

public class UnitTest1
{
    //WORK
    
    [Fact] 
    public void HE_Should_Get_All_Vacation()
    {
        // arrange
        var e = new HourlyEmployee();
        
        //act
        e.Work(260);
        
        //assert
        Assert.Equal(10,e.VacationDaysCurrentBalance);
    }

    [Fact] 
    public void HE_Should_Get_Some_Vacation()
    {
        // arrange
        var e = new HourlyEmployee();
        
        //act
        e.Work(130);
        
        //assert
        Assert.Equal(5,e.VacationDaysCurrentBalance);
    }
    
    
    [Fact] 
    public void SE_Should_Get_All_Vacation()
    {
        // arrange
        var e = new SalariedEmployee();
        
        //act
        e.Work(260);
        
        //assert
        Assert.Equal(15,e.VacationDaysCurrentBalance);
    }
    

    
    [Fact] 
    public void SE_Should_Get_Some_Vacation()
    {
        // arrange
        var e = new SalariedEmployee();
        
        //act
        e.Work(130);
        
        //assert
        Assert.Equal(7.5,e.VacationDaysCurrentBalance);
    }
    
    
    [Fact] 
    public void Manager_Should_Get_All_Vacation()
    {
        // arrange
        var e = new Manager();
        
        //act
        e.Work(260);
        
        //assert
        Assert.Equal(30,e.VacationDaysCurrentBalance);
    }

    [Fact] 
    public void Manager_Should_Get_Some_Vacation()
    {
        // arrange
        var e = new Manager();
        
        //act
        e.Work(130);
        
        //assert
        Assert.Equal(15,e.VacationDaysCurrentBalance);
    }
    
    
    //Vacation
    [Fact] 
    public void HE_Should_Use_All_Vacation()
    {
        // arrange
        var e = new HourlyEmployee();
        e.Work(260);
        
        //act
        e.TakeVacation(10);
        
        //assert
        Assert.Equal(0,e.VacationDaysCurrentBalance);
    }
    
    [Fact] 
    public void HE_Should_Use_No_Vacation()
    {
        // arrange
        var e = new HourlyEmployee();
        e.Work(260);
        
        //act
        e.TakeVacation(0);
        
        //assert
        Assert.Equal(10,e.VacationDaysCurrentBalance);
    }
    
    [Fact] 
    public void HE_Should_Use_Some_Vacation()
    {
        // arrange
        var e = new HourlyEmployee();
        e.Work(260);

        //act
        e.TakeVacation(5);
        
        //assert
        Assert.Equal(5,e.VacationDaysCurrentBalance);
    }
    
    
    [Fact] 
    public void SE_Should_Use_All_Vacation()
    {
        // arrange
        var e = new SalariedEmployee();
        e.Work(260);

        //act
        e.TakeVacation(15);
        
        //assert
        Assert.Equal(0,e.VacationDaysCurrentBalance);
    }
    
    [Fact] 
    public void SE_Should_Use_No_Vacation()
    {
        // arrange
        var e = new SalariedEmployee();
        e.Work(260);

        //act
        e.TakeVacation(0);
        
        //assert
        Assert.Equal(15,e.VacationDaysCurrentBalance);
    }
    
    [Fact] 
    public void SE_Should_Use_Some_Vacation()
    {
        // arrange
        var e = new SalariedEmployee();
        e.Work(260);

        //act
        e.TakeVacation(7.5f);
        
        //assert
        Assert.Equal(7.5,e.VacationDaysCurrentBalance);
    }
    
    
    [Fact] 
    public void Manager_Should_Use_All_Vacation()
    {
        // arrange
        var e = new Manager();
        e.Work(260);
        //act
        e.TakeVacation(30);
        
        //assert
        Assert.Equal(0,e.VacationDaysCurrentBalance);
    }
    
    [Fact] 
    public void Manager_Should_Use_No_Vacation()
    {
        // arrange
        var e = new Manager();
        e.Work(260);
        //act
        e.TakeVacation(0);
        
        //assert
        Assert.Equal(30,e.VacationDaysCurrentBalance);
    }
    
    [Fact] 
    public void Manager_Should_Use_Some_Vacation()
    {
        // arrange
        var e = new Manager();
        e.Work(260);
        //act
        e.TakeVacation(15);
        
        //assert
        Assert.Equal(15,e.VacationDaysCurrentBalance);
    }
    
    
    
    
    // Exception
    [Fact] 
    public void Should_Throw_Exception_Work()
    {
        // arrange
        var e = new Manager();
        
        //act and assert
        Assert.Throws<ExcessiveWorkDaysAmountException>(() => e.Work(261));
    }
    
    [Fact] 
    public void Should_Throw_Exception_Take_Vacation()
    {
        // arrange
        var e = new Manager();
        e.Work(260);
        
        //act and assert
        Assert.Throws<InsufficientDaysRemainingException>(() => e.TakeVacation(31));
    }
    
    [Fact] 
    public void HE_Should_Throw_Exception()
    {
        // arrange
        var e = new HourlyEmployee();

        // act and assert
        Assert.Throws<InsufficientDaysProvidedException>(() => e.Work(0));
    }
    
    [Fact] 
    public void SE_Should_Throw_Exception()
    {
        // arrange
        var e = new SalariedEmployee();
        
        // act and assert
        Assert.Throws<InsufficientDaysProvidedException>(() => e.Work(0));
    }
    
    [Fact] 
    public void Manager_Should_Throw_Exception()
    {
        // arrange
        var e = new Manager();
        
        // act and assert
        Assert.Throws<InsufficientDaysProvidedException>(() => e.Work(0));
    }
    
}
