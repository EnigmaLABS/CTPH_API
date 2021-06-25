using CTPH_CoreBusiness.BusinessInterface;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class ListaValores : IListaValores
    {
        public int idListaValor { get; set; }
        public string NombreListaValor { get; set; }
        public Elemento Elemento { get; set; }
    }
}
