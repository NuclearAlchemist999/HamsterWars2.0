using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HamsterWarsWebAssembly.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IWebHostEnvironment _env;

        public FileUploadController(IWebHostEnvironment env)
        {
            _env = env;
        }

        [HttpPost]
        public async Task <IActionResult> Post(UploadedFile uploadedFile)
        {
            var path = $"{_env.WebRootPath}\\{uploadedFile.FileName}";
            // var path = $"wwwroot/Content/images/savedImages/{uploadedFile.FileName}";
            var fs = System.IO.File.Create(path);
            await fs.WriteAsync(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
            

            return Ok();
        }

    }
}
