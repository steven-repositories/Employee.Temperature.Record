using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Configuration;
using Employee.Temperature.Record.Api.Entity;
using Employee.Temperature.Record.Api.Enums;
using Employee.Temperature.Record.Api.Models;
using Microsoft.AspNetCore.Mvc;
using FromUri = System.Web.Http.FromUriAttribute;

namespace Employee.Temperature.Record.Api.Controllers {
    [Route("api/records")]
    [ApiController, Produces("application/json")]
    public class EmployeeController : ControllerBase {
        private IRecordInterface _record;

        public EmployeeController(AppDbContext dbContext) {
            _record = RecordService
                .CreateInterface(new RecordConnectionConfig() {
                    DbContext = dbContext
                });
        }

        [HttpPost, Route("employees/temperature/new")]
        public JsonResult AddNewEmployeeRecord([FromBody] EmployeeRecord record) {
            return _record
                .AuthEmployee(AuthTypes.New)
                .WithEmployeeRecord(record)
                .Execute()
                .ToJson();
        }

        [HttpPut, Route("employees/temperature/{id}/update")]
        public JsonResult OptimizeEmployeeRecord([FromUri] int id, [FromBody] EmployeeRecord record) {
            return _record
                .AuthEmployee(AuthTypes.Optimization)
                .WithEmployeeId(id)
                .WithEmployeeRecord(record)
                .Execute()
                .ToJson();
        }

        [HttpGet, Route("employees/temperature/{id}")]
        public JsonResult GetEmployeeTemperature([FromUri] int id) {
            return _record
                .ManageEmployee(ManageTypes.Pull)
                .WithEmployeeId(id)
                .WithPullType(PullTypes.Single)
                .Execute()
                .ToJson();
        }

        [HttpGet, Route("employees/temperature")]
        public JsonResult GetAllEmployees() {
            return _record
                .ManageEmployee(ManageTypes.Pull)
                .WithPullType(PullTypes.All)
                .Execute()
                .ToJson();
        }

        [HttpPost, Route("employees/temperature/search")]
        public JsonResult FilterByEmployees([FromBody] SearchFilter filter) {
            return _record
                .AuthEmployee(AuthTypes.Filter)
                .WithSearchFilter(filter)
                .Execute()
                .ToJson();
        }
    }
}
