using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class Movilidad
    {
        public int? idMov { get; set; }
        public int CodEmpresa { get; set; }
        public string CCosto { get; set; }
        public string Origen { get; set; }
        public string Destino { get; set; }
        public string Motivo { get; set; }
        public string Transporte { get; set; }
        public string InstDestino { get; set; }
        public DateTime HoraSalida { get; set; }
        public DateTime HoraRetorno { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaRegistro { get; set; }



        public DateTime fecIni { get; set; }
        public DateTime fecFin { get; set; }
        public int userId { get; set; }
        public int companyId { get; set; }
    }
}
