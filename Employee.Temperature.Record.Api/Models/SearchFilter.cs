using System;

namespace Employee.Temperature.Record.Api.Models {
    public class SearchFilter {
        public int[] Id { get; set; }
        public string[] FirstName { get; set; }
        public string[] LastName { get; set; }
        public DateTime CreatedDateTimeFirst { get; set; }
        public DateTime CreatedDateTimeLast { get; set; }
        public string[] Temperature { get; set; }

        public object this[string name] {
            get {
                switch (name.ToLower()) {
                    case "id":
                        return Id;
                    case "firstname":
                        return FirstName;
                    case "lastname":
                        return LastName;
                    case "createddatetimefirst":
                        return CreatedDateTimeFirst;
                    case "createddatetimelast":
                        return CreatedDateTimeLast;
                    case "temperature":
                        return Temperature;
                    default:
                        return default(object);
                }
            }
        }
    }
}
