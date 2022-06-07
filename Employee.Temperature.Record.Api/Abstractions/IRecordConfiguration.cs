using Employee.Temperature.Record.Api.Entity;

namespace Employee.Temperature.Record.Api.Abstractions {
    public interface IRecordConfiguration {
        AppDbContext DbContext { get; set; }
    }
}
