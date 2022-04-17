namespace Mybarber.DesignerPatters.Factory.ConcreteServico
{
    public class ServicoBasico : ServicoPrestado
    {
        private readonly string _nomeServico;
        private float _valor;



        public ServicoBasico( float valor)
        {
            this._nomeServico = "Básico";
            this._valor = valor;
        }

        public override string NomeServico 
        {
        get { return _nomeServico; }
           
        
        }
        public override float ValorDoServico 
        { 
            get { return _valor; }
            set { _valor = value; }
        }
    }
}
