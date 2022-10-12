using Mybarber.DataTransferObject.Banner;
using Mybarber.DataTransferObject.Contatos;
using Mybarber.DataTransferObject.Enderecos;
using Mybarber.DataTransferObject.Horario;
using Mybarber.DataTransferObject.LadingPageImages;
using Mybarber.DataTransferObject.Temas;
using System.Collections.Generic;

namespace Mybarber.DataTransferObject.Barbearia
{
    public class BarbeariasCompleteRequestDto
    {
        public string NomeBarbearia { get; set; }
        public string CNPJ { get; set; }
        public string Route { get; set; }
        public bool FuncaoAgendamento { get; set; }
        public TemasRequestDto Temas { get; set; }
        public EnderecosRequestDto Enderecos { get; set; }
        public ContatosRequestDto Contatos { get; set; }
        public HorarioFuncionamentoRequestDto HorarioFuncionamento { get; set; }
        public ICollection<BannerRequestDto> Banner { get; set; }
        public ICollection<LandingPageImagesRequestDto> LadingPageImages { get; set; }
    }
}
