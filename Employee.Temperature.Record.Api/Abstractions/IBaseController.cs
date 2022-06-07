using Employee.Temperature.Record.Api.Builders;

namespace Employee.Temperature.Record.Api.Abstractions {
    internal interface IBaseController {
        IRecordResponse ProcessAuthRequest(AuthBuilder builder);
        IRecordResponse ProcessManageRequest(ManageBuilder builder);
    }
}
