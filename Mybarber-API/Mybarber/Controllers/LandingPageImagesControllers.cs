using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mybarber.Controllers
{
    [EnableCors]
    [ApiController]
    [Route("api/v1/agendamentos")]
    public class LandingPageImagesControllers:ControllerBase
    {
        public LandingPageImagesControllers()
        {

        }
        public async Task<IActionResult> PostLadingPageImageS3Async()
        {

        }
    }
}
