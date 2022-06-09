using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Configuration;
using Employee.Temperature.Record.Api.Enums;
using Employee.Temperature.Record.Api.Utilities;

namespace Employee.Temperature.Record.Api.Builders {
    public class ManageBuilder : Builder<ManageBuilder> {
        internal PullTypes PullType { get; set; }

        public ManageBuilder(ManageTypes type) : base(type) { }

        public ManageBuilder WithPullType(PullTypes type) {
            PullType = type;
            return this;
        }

        public override IRecordResponse Execute() {
            base.Execute();

            return RecordContainer
                .GetBaseController()
                .ProcessManageRequest(this);
        }

        protected override void SetupValidations() {
            switch (ManageType) {
                case ManageTypes.Delete:
                case ManageTypes.Pull:
                    if (EmployeeId is default(int)
                        && PullType is PullTypes.Single) {
                        throw new BuilderException("Employee Id cannot be null.");
                    }
                    break;
                default:
                    throw new BuilderException("Manage type is not expected.");
            }
        }
    }
}
