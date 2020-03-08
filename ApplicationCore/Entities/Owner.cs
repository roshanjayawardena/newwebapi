using ApplicationCore.Entities.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ApplicationCore.Entities
{
    [Table("owner")]
    public class Owner : IEntity
    {
        [Key]
        [Column("OwnerId")]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }


    }
}
