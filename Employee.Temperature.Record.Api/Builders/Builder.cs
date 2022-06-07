using Employee.Temperature.Record.Api.Abstractions;
using Employee.Temperature.Record.Api.Enums;

namespace Employee.Temperature.Record.Api.Builders {
    public abstract class Builder<T> : BaseBuilder<IRecordResponse> where T : Builder<T> {
        internal int EmployeeId { get; set; }

        public Builder(AuthTypes type) : base(type) { }
        public Builder(ManageTypes type) : base(type) { }

        public T WithEmployeeId(int id) {
            EmployeeId = id;
            return (T)this;
        }
    }
}
