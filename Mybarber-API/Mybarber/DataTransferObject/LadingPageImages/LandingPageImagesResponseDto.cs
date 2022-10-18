using System;

namespace Mybarber.DataTransferObject.LadingPageImages
{
    public class LandingPageImagesResponseDto
    {
        public Guid IdLandingPageImage { get; set; }
        public string URL { get; set; }
        public int NumeroImagem { get; set; }
        public string Especificacao { get; set; }
        public string Posicao { get; set; }
    }
}
