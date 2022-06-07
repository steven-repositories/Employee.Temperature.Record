using Employee.Temperature.Record.Api.Abstractions;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Employee.Temperature.Record.Api.Entities {
    public abstract class Entity : IEntity {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; protected set; }
        public DateTime CreatedDateTime { get; private set; }
        public DateTime? ModifiedDateTime { get; set; }
        [NotMapped]
        public bool IsNew { get; private set; }

        public Entity() {
            CreatedDateTime = DateTime.Now;
            IsNew = Id == 0;
        }
    }
}
