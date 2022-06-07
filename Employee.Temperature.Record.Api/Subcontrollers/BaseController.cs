using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Builders;
using Employee.Temperature.Record.Api.Enums;
using Employee.Temperature.Record.Api.Utilities;

namespace Employee.Temperature.Record.Api.Subcontrollers {
    internal abstract class BaseController : IBaseController {
        protected IRecordConfiguration _configuration;
        protected ICommunicationInterface _communication;

        public BaseController(IRecordConfiguration configuration) {
            _configuration = configuration;
            _communication = ConfigureCommunicationInterface();
        }

        internal abstract IRecordInterface ConfigureRecordInterface();
        internal abstract ICommunicationInterface ConfigureCommunicationInterface();

        public IRecordResponse ProcessAuthRequest(AuthBuilder builder) {
            switch (builder.AuthType) {
                case AuthTypes.New:
                case AuthTypes.Filter:
                    return _communication
                        .Post(builder);
                case AuthTypes.Optimization:
                    return _communication
                        .Put(builder);
                default:
                    throw new ControllerException("Auth type is not expected.");
            }
        }

        public IRecordResponse ProcessManageRequest(ManageBuilder builder) {
            switch (builder.ManageType) {
                case ManageTypes.Pull:
                    return _communication
                        .Get(builder);
                case ManageTypes.Delete:
                    return _communication
                        .Delete(builder);
                default:
                    throw new ControllerException("Manage type is not expected.");
            }
        }
    }
}
