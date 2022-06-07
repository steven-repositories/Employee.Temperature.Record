using Employee.Temperature.Record.Api.Builders;

namespace Employee.Temperature.Record.Api.Abstractions {
    internal interface ICommunicationInterface {
        IRecordResponse Get<T>(T builder) where T : Builder<T>;
        IRecordResponse Post<T>(T builder) where T : Builder<T>;
        IRecordResponse Put<T>(T builder) where T : Builder<T>;
        IRecordResponse Delete<T>(T builder) where T : Builder<T>;
    }
}
