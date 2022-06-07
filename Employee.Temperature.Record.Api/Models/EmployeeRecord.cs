namespace Employee.Temperature.Record.Api.Models {
    public class EmployeeRecord { 
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Temperature { get; set; }

        public string this[string name] {
            get {
                switch (name.ToLower()) {
                    case "firstname":
                        return FirstName;
                    case "lastname":
                        return LastName;
                    case "temperature":
                        return Temperature
                            .ToString();
                    default:
                        return string.Empty;
                }
            }
        }
    }
}
