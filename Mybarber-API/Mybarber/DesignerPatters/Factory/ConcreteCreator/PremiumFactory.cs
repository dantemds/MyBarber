using Mybarber.DesignerPatters.Factory.ConcreteServico;
using Mybarber.DesignerPatters.Factory.Creator;

namespace Mybarber.DesignerPatters.Factory.ConcreteCreator
{
    public class PremiumFactory : ServicoFactory
    {
        private float _valor;


        public PremiumFactory(float valor)
        {
            this._valor = valor;
        }
        public override ServicoPrestado BuscarServicoPrestado()
        {
            return new SevicoPremium(_valor);
        }


    }
}

