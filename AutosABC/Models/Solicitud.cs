using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AutosABC.Models
{
    public class Solicitud
    {
        public int SolicitudID { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Fecha { get; set; }
        [Display(Name = "Número de Lote")]
        public int NumeroLote { get; set; }

        public virtual ICollection<Auto> Autos { get; set; }
    }
}
