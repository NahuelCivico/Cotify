using BusinessServices.Interfaces;
using Model;
using Model.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessServices.Services
{
    public class QuoteServices : IQuoteServices
    {
        private readonly UnitOfWork _unitOfWork;

        public QuoteServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public long Create(Cotizaciones entity)
        {
            try
            {
                _unitOfWork.QuoteRepository.Insert(entity);
                _unitOfWork.Commit();
                return entity.Id;
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }

        public List<Cotizaciones> GetAll(string filter)
        {
            try
            {
                IQueryable<Cotizaciones> entity = _unitOfWork.QuoteRepository.GetAllByFilters(x => (x.Cliente.Contains(filter) || (String.IsNullOrEmpty(filter)) || x.NumeroPoliza.Contains(filter) || (String.IsNullOrEmpty(filter))) && x.Activa == true);
                return entity.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Error: " + ex.Message);
            }
        }
    }
}
