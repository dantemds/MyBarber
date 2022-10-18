using System;

namespace Mybarber.DataTransferObject.Banner
{
    public class BannerResponseDto
    {
        public Guid IdBanner { get; set; }
        public string URL { get; set; }
        public bool Mobile { get; set; }
    }
}
