using CodeTestV2.Application.Extensions;
using CodeTestV2.Core.Interfaces.Employees;

namespace CodeTestV2.Application.Models;

public class Employee : IEmployee
{
    public int EmployeeId { get; }
    
    /// <summary>
    /// Constructor for existing entities.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="type"></param>
    protected Employee(int id, EmployeeType type) : this(type)
    {
        this.EmployeeId = id;
    }

    /// <summary>
    /// Constructor for new employees.
    /// </summary>
    /// <param name="type"></param>
    protected Employee(EmployeeType type)
    {
        this.EmployeeType = type;
    }
    
    public virtual void Work(int daysWorked)
    {
        this.AddWorkDays((ushort)daysWorked);
    }

    public virtual void TakeVacation(float vacationDaysRequested)
    {
        this.SubtractVacationDaysUsedForEmployee(vacationDaysRequested);
    }

    public float VacationDaysAccumulated { get; set; }
    public float VacationDaysCurrentBalance { get; set; }
    public ushort TotalDaysWorkedThisYear { get; set; }
    
    public EmployeeType EmployeeType { get; }
    

    protected object Clone()
    {
        return MemberwiseClone();
    }
    
}

public class HourlyEmployee : Employee
{
    public HourlyEmployee CloneHourly()
    {
        return Clone() as HourlyEmployee ?? new HourlyEmployee();
    }
    public HourlyEmployee(int id) : base(id, EmployeeType.Hourly)
    {
    }
    public HourlyEmployee() : base(EmployeeType.Hourly)
    {
    }
}

public class SalariedEmployee : Employee
{
    public SalariedEmployee CloneSalaried()
    {
        return Clone() as SalariedEmployee ?? new SalariedEmployee();
    }
    public SalariedEmployee(int id, EmployeeType type = EmployeeType.Salaried) : base(id, type)
    {
    }
    
    public SalariedEmployee(EmployeeType type = EmployeeType.Salaried) : base(type)
    {
    }
}

public class ManagerEmployee : SalariedEmployee
{
    public ManagerEmployee CloneManager()
    {
        return Clone() as ManagerEmployee ?? new ManagerEmployee();
    }
    public ManagerEmployee(int id) : base(id, EmployeeType.Manager)
    {
    }
    
    public ManagerEmployee() : base(EmployeeType.Manager)
    {
    }
}

