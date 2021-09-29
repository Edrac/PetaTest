using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PetaTest.Interfaces
{    public interface IDbInitializer
    {
        /// <summary>
        /// Adds the data to the Db
        /// </summary>
        void SeedData();
    }
}
