using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutosABC.Models
{
    public class Auto
    {
        public int ID { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string Folio { get; set; }
        public string Color { get; set; }
        [Display(Name = "Tipo de Transmisión")]
        public string TipoTransmision { get; set; }
        [Display(Name = "Descripción Estética")]
        public string DescripcionEstetica { get; set; }

        public int SolicitudID { get; set; }
        public virtual Solicitud Solicitud { get; set; } 
    }
}