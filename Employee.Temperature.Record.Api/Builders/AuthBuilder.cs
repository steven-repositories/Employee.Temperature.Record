using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Configuration;
using Employee.Temperature.Record.Api.Enums;
using Employee.Temperature.Record.Api.Models;
using Employee.Temperature.Record.Api.Utilities;

namespace Employee.Temperature.Record.Api.Builders {
    public class AuthBuilder : Builder<AuthBuilder> {
        internal EmployeeRecord EmployeeRecord { get; set; }
        internal SearchFilter SearchFilter { get; set; }

        public AuthBuilder(AuthTypes type) : base(type) { }

        public AuthBuilder WithEmployeeRecord(EmployeeRecord record) {
            EmployeeRecord = record;
            return this;
        }

        public AuthBuilder WithSearchFilter(SearchFilter filter) {
            SearchFilter = filter;
            return this;
        }

        public override IRecordResponse Execute() {
            base.Execute();

            return RecordContainer
                .GetBaseController()
                .ProcessAuthRequest(this);
        }

        protected override void SetupValidations() {
            switch (AuthType) {
                case AuthTypes.New:
                    if (EmployeeRecord is default(EmployeeRecord)) {
                        throw new BuilderException("Employee record cannot be null or empty.");
                    }
                    break;
                case AuthTypes.Optimization:
                    if (EmployeeRecord is default(EmployeeRecord)
                        || EmployeeId is default(int)) {
                        throw new BuilderException("Employee Id cannot be null.");
                    }
                    break;
                case AuthTypes.Filter:
                    if (SearchFilter is default(SearchFilter)) {
                        throw new BuilderException("Search filter cannot be null.");
                    }
                    break;
                default:
                    throw new BuilderException("Builder auth type is not expected.");
            }
        }
    }
}
