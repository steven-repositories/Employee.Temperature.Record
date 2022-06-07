using Employee.Temperature.Record.Api.Abstractions;

namespace Employee.Temperature.Record.Api.Configuration {
    public class RecordService {
        public static IRecordInterface CreateInterface(RecordConnectionConfig config) {
            RecordContainer
                .ConfigureService(config);

            return RecordContainer
                .GetRecordInterface();
        }
    }
}
