using Microsoft.AspNetCore.Mvc;

namespace Employee.Temperature.Record.Api.Abstractions {
    public interface IRecordResponse {
        JsonResult ToJson();
    }
}
