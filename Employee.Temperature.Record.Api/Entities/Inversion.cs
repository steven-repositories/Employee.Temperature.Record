namespace Employee.Temperature.Record.Api.Entities {
    public class Inversion : Entity {
        public string Temperature { get; set; }

        public string this[string name] {
            get {
                switch (name.ToLower()) {
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
