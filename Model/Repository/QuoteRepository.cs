using Model.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Repository
{
    public class QuoteRepository : GenericRepository<Cotizaciones>, IQuoteRepository
    {
        public QuoteRepository(QuoteContext _context) : base(_context)
        {
        }
    }
}
