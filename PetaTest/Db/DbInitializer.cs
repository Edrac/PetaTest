using CsvHelper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using PetaTest.Interfaces;
using PetaTest.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PetaTest.Db
{
    public class DbInitializer: IDbInitializer
    {
        private readonly IServiceScopeFactory _scopeFactory;

        public DbInitializer(IServiceScopeFactory scopeFactory)
        {
            this._scopeFactory = scopeFactory;
        }

        public void SeedData()
        {
            using (var serviceScope = _scopeFactory.CreateScope())
            {
                using (var context = serviceScope.ServiceProvider.GetService<PokemonContext>())
                {
                    if (!context.PokemonList.Any())
                    {
                        using (var reader = new StreamReader("Db\\pokemon.csv"))
                        using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                        {
                            var records = csv.GetRecords<Pokemon>();
                            context.PokemonList.AddRange(records);
                        }
                    }
                    context.SaveChanges();
                }
            }
        }
    }
}
