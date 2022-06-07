using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Builders;
using Employee.Temperature.Record.Api.Enums;

namespace Employee.Temperature.Record.Api.Substructures {
    internal class RecordInterface : IRecordInterface {
        public AuthBuilder AuthEmployee(AuthTypes type) {
            return new AuthBuilder(type);
        }

        public ManageBuilder ManageEmployee(ManageTypes type) {
            return new ManageBuilder(type);
        }
    }
}
