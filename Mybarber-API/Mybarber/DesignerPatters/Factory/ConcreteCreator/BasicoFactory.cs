using Mybarber.DesignerPatters.Factory.ConcreteServico;
using Mybarber.DesignerPatters.Factory.Creator;

namespace Mybarber.DesignerPatters.Factory.ConcreteCreator
{
    public class BasicoFactory : ServicoFactory
    {
        private float _valor;


        public BasicoFactory(float valor)
        {
            this._valor = valor;
        }
        public override ServicoPrestado BuscarServicoPrestado()
        {
            return new ServicoBasico(_valor);
        }
    }
}
