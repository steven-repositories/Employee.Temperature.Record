using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Temperature.Record.Api.Entities {
    [Table("Employee")]
    public class Laborer : Entity {
        public Person Person { get; set; }
        public Inversion Temperature { get; set; }
    }
}
