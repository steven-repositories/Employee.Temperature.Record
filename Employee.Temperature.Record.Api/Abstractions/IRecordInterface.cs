using Employee.Temperature.Record.Api.Builders;
using Employee.Temperature.Record.Api.Enums;

namespace Employee.Temperature.Record.Api.Abstractions {
    public interface IRecordInterface {
        AuthBuilder AuthEmployee(AuthTypes type);
        ManageBuilder ManageEmployee(ManageTypes type);
    }
}
