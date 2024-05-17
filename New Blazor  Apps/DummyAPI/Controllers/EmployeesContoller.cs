using Microsoft.AspNetCore.Mvc;

namespace DummyAPI.Controllers;

public class EmployeesContoller : Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public readonly IConfiguration _configuration;
        public EmployeeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        //[HttpGet]
        //[Route("GetAllEmployees")]
        //public JsonResult GetEmployees()
        //{
        //    SqlConnection con = new SqlConnection(_configuration.GetConnectionString("SqlServerDb").ToString());
        //    SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Employees", con);
        //    DataTable dt = new DataTable();
        //    da.Fill(dt);

        //    List<Employee> employeeList = new List<Employee>();
        //    if (dt.Rows.Count > 0)
        //    {
        //        for (int i = 0; i < dt.Rows.Count; i++)
        //        {
        //            Employee employee = new Employee();
        //            employee.Id = Convert.ToInt32(dt.Rows[i]["EmpId"]);
        //        }

        //    }


        //    // Convert DataTable to JSON and return it
        //    //return new JsonResult(dt);
        //}

    }
}