

using System;

namespace Mybarber.DataTransferObject.Images
{
    public class BarbeiroImagemResponseDto
    {
        public Guid IdBarbeiroImagem { get; set; }

        public Guid IdBarbeiro { get; set; }
        public string URL { get; set; }

    }
}
