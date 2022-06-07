using System;

namespace Employee.Temperature.Record.Api.Abstractions {
    public interface IEntity {
        int Id { get; }
        DateTime CreatedDateTime { get; }
        DateTime? ModifiedDateTime { get; }
    }
}
