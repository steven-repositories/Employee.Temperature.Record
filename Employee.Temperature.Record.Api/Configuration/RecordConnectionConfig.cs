using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Entity;
using Employee.Temperature.Record.Api.Subcontrollers;

namespace Employee.Temperature.Record.Api.Configuration {
    public class RecordConnectionConfig : RecordConfig, IRecordConfiguration {
        public AppDbContext DbContext { get; set; }

        internal override void ConfigureRecordContainer(RecordConfiguredServices service) {
            service.DbContext = DbContext;
            service.BaseController = new RecordController(this);
        }
    }
}
