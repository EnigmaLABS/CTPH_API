using CTPH_CoreBusiness.BusinessObjects;

namespace CTPH_CoreBusiness.BusinessInterface
{
    public interface IMuestraValor
    {
        byte? Humedad { get; set; }
        decimal? Temperatura { get; set; }
        PuntoMedida PuntoMedida { get; set; }
    }
}
