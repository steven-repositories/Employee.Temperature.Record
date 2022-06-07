using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Entity;
using Employee.Temperature.Record.Api.Subcontrollers;

namespace Employee.Temperature.Record.Api.Configuration {
    internal class RecordConfiguredServices {
        private BaseController _baseController { get; set; }
        internal BaseController BaseController {
            get {
                return _baseController;
            }

            set {
                _baseController = value;
                RecordInterface = value
                    .ConfigureRecordInterface();
            }
        }
        internal AppDbContext DbContext { get; set; }
        internal IRecordInterface RecordInterface { get; set; }
    }
}
