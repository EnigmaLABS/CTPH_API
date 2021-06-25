using CTPH_CoreBusiness.BusinessInterface;

namespace CTPH_CoreBusiness.BusinessObjects
{
    public class ElementoValor : IElementoValor
    {
        public Elemento Elemento { get; set; }
        public string Valor { get; set; }
        public int? idListaValor { get; set; }
    }
}
