using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JewelCollector
{
    /// <summary>
    /// Exceção específica para quando tentar um movimento que já existe uma entidade ocupando
    /// </summary>
    public class NonTransitableException : Exception
    {
        public NonTransitableException() {}

    }
}