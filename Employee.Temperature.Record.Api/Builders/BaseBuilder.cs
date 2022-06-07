using Employee.Temperature.Record.Api.Enums;

namespace Employee.Temperature.Record.Api.Builders {
    public abstract class BaseBuilder<TResult> {
        public AuthTypes AuthType { get; set; }
        public ManageTypes ManageType { get; set; }

        internal BaseBuilder(AuthTypes type) {
            AuthType = type;
        }

        internal BaseBuilder(ManageTypes type) {
            ManageType = type;
        }

        public virtual TResult Execute() {
            SetupValidations();
            return default(TResult);
        }

        protected abstract void SetupValidations();
    }
}
