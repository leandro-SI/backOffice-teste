using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackOffice.Dominio.Validation
{
    public class DominioExceptionValidation : Exception
    {
        public DominioExceptionValidation(string error) : base(error)
        {

        }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DominioExceptionValidation(error);
        }
    }
}
