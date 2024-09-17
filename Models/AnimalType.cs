using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Farm.Models;

public class AnimalType
{
    public int Id { get; set; }
    public required string Name { get; set; } // "Mammal", "birds", "fishes", "reptails"
    public string? Description { get; set; } //"They are the animal that drink milk from..."

}
