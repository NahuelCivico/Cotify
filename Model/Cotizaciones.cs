namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Cotizaciones
    {
        public int Id { get; set; }

        [Required]
        [StringLength(350)]
        public string Cliente { get; set; }

        [Required]
        [StringLength(50)]
        public string TipoSeguro { get; set; }

        [Required]
        [StringLength(50)]
        public string FormaPago { get; set; }

        public DateTime FechaVencimiento { get; set; }

        public DateTime FechaCotizacion { get; set; }

        public bool Activa { get; set; }

        [Required]
        [StringLength(50)]
        public string NumeroPoliza { get; set; }
    }
}
