using Bogus;
using EclipseWebAppClassLibrary.Data.Interfaces;
using EclipseWebAppClassLibrary.Data.Models;

namespace EclipseWebAppClassLibrary.Data.GridData;

public class EmployeeData : IEmployeeData
{
    private static readonly Faker<Employee> EmployeeFaker = new Faker<Employee>()
        .RuleFor(e => e.EmployeeID, f => f.IndexFaker + 1)
        .RuleFor(e => e.FirstName, f => f.Person.FirstName)
        .RuleFor(e => e.LastName, f => f.Person.LastName)
        .RuleFor(e => e.Title, f => f.Name.JobTitle())
        .RuleFor(e => e.TitleOfCourtesy, f => f.Name.Prefix())
        .RuleFor(e => e.BirthDate, f => f.Person.DateOfBirth)
        .RuleFor(e => e.HireDate, f => f.Date.Past())
        .RuleFor(e => e.Address, f => f.Address.StreetAddress())
        .RuleFor(e => e.City, f => f.Address.City())
        .RuleFor(e => e.Region, f => f.Address.State())
        .RuleFor(e => e.PostalCode, f => f.Address.ZipCode())
        .RuleFor(e => e.Country, f => f.Address.Country())
        .RuleFor(e => e.HomePhone, f => f.Phone.PhoneNumber())
        .RuleFor(e => e.Extension, f => f.Random.AlphaNumeric(5))
        .RuleFor(e => e.Notes, f => f.Lorem.Sentences(3))
        .RuleFor(e => e.Photo, f => f.Internet.Avatar());

    public List<Employee> GetEmployees()
    {
        return EmployeeFaker.Generate(10);
    }
}