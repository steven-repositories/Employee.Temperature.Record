using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Services;
using Employee.Temperature.Record.Api.Substructures;

namespace Employee.Temperature.Record.Api.Subcontrollers {
    internal class RecordController : BaseController {
        public RecordController(IRecordConfiguration configuration) : base(configuration) { }

        internal override ICommunicationInterface ConfigureCommunicationInterface() {
            return new RestService(_configuration.DbContext);
        }

        internal override IRecordInterface ConfigureRecordInterface() {
            return new RecordInterface();
        }
    }
}
