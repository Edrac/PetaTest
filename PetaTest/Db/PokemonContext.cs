using CsvHelper;
using Microsoft.EntityFrameworkCore;
using PetaTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetaTest.Db
{
    public class PokemonContext : DbContext
    {
        public PokemonContext(DbContextOptions<PokemonContext> options) : base(options)
        {

        }

        public DbSet<Pokemon> PokemonList { get; set; }
    }
}
