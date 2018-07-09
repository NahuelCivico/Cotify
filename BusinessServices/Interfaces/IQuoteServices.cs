using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Interfaces
{
    public interface IQuoteServices
    {
        List<Cotizaciones> GetAll(String filter);
        Int64 Create(Cotizaciones entity);
    }
}
