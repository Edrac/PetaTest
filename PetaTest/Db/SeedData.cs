using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetaTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetaTest.Db
{
    public static class SeedData
    {
        //public static void Initialize(IServiceProvider serviceProvider)
        public static void Initialize(PokemonContext context)
        {

            var n = context.PokemonList.Count();

            if (n > 0) return;
            //using (var context = new PokemonContext(serviceProvider.GetRequiredService<DbContextOptions<PokemonContext>>()))
            using (var reader = new StreamReader("Db\\pokemon.csv"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<Pokemon>();

                context.PokemonList.AddRange(records);
                context.SaveChanges();
            }
        }
    }
}
