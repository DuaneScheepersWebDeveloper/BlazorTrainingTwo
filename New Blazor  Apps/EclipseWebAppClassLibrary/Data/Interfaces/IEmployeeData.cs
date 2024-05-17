using EclipseWebAppClassLibrary.Data.Models;

namespace EclipseWebAppClassLibrary.Data.Interfaces;

public interface IEmployeeData
{
    List<Employee> GetEmployees();
}