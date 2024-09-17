using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Farm.Models;

[Table("animal_type")]
public class AnimalType
{
    [Column("id")]
    [Key]
    public int Id { get; set; }
    [Column("name")]
    [MinLength(4, ErrorMessage ="The field only accept 4 letters at minimun.")]
    public required string Name { get; set; } // "Mammal", "birds", "fishes", "reptails"

    [Column("descrition")]
    [MaxLength(500, ErrorMessage = "The field only accept 500 letters at maximun")]
    public string? Description { get; set; } //"They are the animal that drink milk from..."

}
