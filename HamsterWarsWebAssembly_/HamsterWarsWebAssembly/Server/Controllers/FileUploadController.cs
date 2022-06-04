using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Components.Forms;
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
        public async Task<IActionResult> PostFile(UploadedFile uploadedFile)
        {
            string[] validTypes = { "jpg", "jpeg", "png" };

            string fileExtension = uploadedFile.FileName.Split(".").Last();

            if (string.IsNullOrEmpty(fileExtension) || !validTypes.Contains(fileExtension.ToLower()))
            {
                return BadRequest("The file does not have an extension or it is not an image.");
            }

            if(uploadedFile.FileContent.Length > 512000)
            {
                return BadRequest("The size of file is more than 512 kb.");
            }


            var path = $"wwwroot/images/{uploadedFile.FileName}";
            await using var fs = new FileStream(path, FileMode.Create);
            fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
            return new CreatedResult(_env.WebRootPath, uploadedFile.FileName);

            
        }

    }

}

