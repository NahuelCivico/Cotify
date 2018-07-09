using Model.Interfaces;
using Model.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region Members
        private QuoteContext _context = null;
        private IQuoteRepository _quoteRepository;
        #endregion

        #region Properties
        public IQuoteRepository QuoteRepository
        {
            get {
                if (_quoteRepository == null)
                {
                    _quoteRepository = new QuoteRepository(_context);
                }
                return _quoteRepository;
            }

            set {
                _quoteRepository = value;
            }
        }
        #endregion

        public UnitOfWork()
        {
            _context = new QuoteContext();
        }

        #region Override Methods
        public void Commit()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
        #endregion
    }
}
