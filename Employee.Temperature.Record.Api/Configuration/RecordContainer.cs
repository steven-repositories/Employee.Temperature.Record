using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Subcontrollers;

namespace Employee.Temperature.Record.Api.Configuration {
    internal class RecordContainer {
        private static RecordConfiguredServices _configuration;

        public static void ConfigureService<T>(T config) where T : RecordConfig {
            _configuration = GetConfiguration();
            config.ConfigureRecordContainer(_configuration);
        }

        private static RecordConfiguredServices GetConfiguration() {
            return new RecordConfiguredServices();
        }

        internal static IRecordInterface GetRecordInterface() {
            return _configuration
                .RecordInterface;
        }

        internal static BaseController GetBaseController() {
            return _configuration
                .BaseController;
        }
    }
}
