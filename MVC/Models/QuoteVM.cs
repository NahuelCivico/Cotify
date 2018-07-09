using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC.Models
{
    public class QuoteVM
    {
        #region Members
        private Int64 _id;
        private String _cliente;
        private String _tipoSeguro;
        private String _formaPago;
        private DateTime _fechaVencimiento;
        private DateTime _fechaCotizacion;
        private Boolean _activa;
        private String _numeroPoliza;
        #endregion

        #region Properties
        public Int64 Id { get => _id; set => _id = value; }
        [Required]
        [Display(Name = "Cliente")]
        [StringLength(350, ErrorMessage = "Ingresá el cliente")]
        public String Cliente { get => _cliente; set => _cliente = value; }

        [Required]
        [Display(Name = "Tipo de seguro")]
        [StringLength(50, ErrorMessage = "Ingresá el tipo de seguro")]
        public String TipoSeguro { get => _tipoSeguro; set => _tipoSeguro = value; }

        [Required]
        [Display(Name = "Pago")]
        [StringLength(50, ErrorMessage = "Ingresá la forma de pago")]
        public String FormaPago { get => _formaPago; set => _formaPago = value; }

        [Display(Name = "Vencimiento")]
        public DateTime FechaVencimiento { get => _fechaVencimiento; set => _fechaVencimiento = value; }

        public DateTime FechaCotizacion { get => _fechaCotizacion; set => _fechaCotizacion = value; }

        public Boolean Activa { get => _activa; set => _activa = value; }

        [Required]
        [Display(Name = "Nº de Poliza")]
        public String NumeroPoliza { get => _numeroPoliza; set => _numeroPoliza = value; }
        #endregion
    }
}