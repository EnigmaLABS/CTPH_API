
using CTPH_CoreBusiness.BusinessInterface;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class MuestraValor : IMuestraValor
    {
        public MuestraValor() { }

        public decimal? Temperatura { get; set; }

        public byte? Humedad { get; set; }

        public PuntoMedida PuntoMedida { get; set; } = new PuntoMedida();
    }
}
