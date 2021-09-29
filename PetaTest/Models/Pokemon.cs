using CsvHelper.Configuration.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PetaTest.Models
{
    public class Pokemon
    {
        [Name("#")]
        public int Id { get; set; }
        [Key]
        public string Name { get; set; }
        [Name("Type 1")]
        public string Type1 { get; set; }
#nullable enable
        [Name("Type 2")]
        public string? Type2 { get; set; }
#nullable disable
        public int Total { get; set; }
        public int HP { get; set; }
        public int Attack { get; set; }
        public int Defense { get; set; }
        [Name("Sp. Atk")]
        public int SpAtk { get; set; }
        [Name("Sp. Def")]
        public int SpDef { get; set; }
        public int Speed { get; set; }
        public int Generation { get; set; }
        public bool Legendary { get; set; }

    }
}
