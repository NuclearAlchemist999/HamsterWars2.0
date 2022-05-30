using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

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
        public async Task<ActionResult> PostFile(UploadedFile uploadedFile)
        {
            // var path = $"{_env.WebRootPath}\\{uploadedFile.FileName}";
            var path = $"wwwroot/images/{uploadedFile.FileName}";
            await using var fs = new FileStream(path, FileMode.Create);
            fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
            return new CreatedResult(_env.WebRootPath, uploadedFile.FileName);
        }
    }

}

