using Employee.Temperature.Record.Api.Abstractions;
using Microsoft.AspNetCore.Mvc;

namespace Employee.Temperature.Record.Api.Substructures {
    public class RecordResponse : IRecordResponse {
        private object _response;

        public RecordResponse(object response) {
            _response = response;
        }

        public JsonResult ToJson() {
            return new JsonResult(new {
                data = _response
            });
        }
    }
}
