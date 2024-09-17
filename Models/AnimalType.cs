using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace API_Farm.Models;

[Table("animal_type")]
public class AnimalType
{
    [Column("id")]
    public int Id { get; set; }
    [Column("name")]
    public required string Name { get; set; } // "Mammal", "birds", "fishes", "reptails"
    [Column("descrition")]
    public string? Description { get; set; } //"They are the animal that drink milk from..."

}
