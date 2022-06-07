using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Temperature.Record.Api.Entities {
    [Table("Person")]
    public class Person : Entity {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [NotMapped]
        public string this[string name] {
            get {
                switch (name.ToLower()) {
                    case "firstname":
                        return FirstName;
                    case "lastname":
                        return LastName;
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
