using HamsterWarsWebAssembly.Shared.Models;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost, Authorize(Roles = "Admin")]
        public async Task<IActionResult> PostFile(UploadedFile uploadedFile)
        {
            if (uploadedFile.FileContent == null)
            {
                return BadRequest("No file.");
            }
            if (uploadedFile.FileContent.Length > 501760)
            {
                return BadRequest("The size of the file is more than 502 kb.");
              
            }
            string[] validTypes = { "jpg", "jpeg", "png" };

            string fileExtension = uploadedFile.FileName.Split(".").Last();

            if (string.IsNullOrEmpty(fileExtension) || !validTypes.Contains(fileExtension.ToLower()))
            {
                return BadRequest("The file does not have an extension or it is not an image.");
            }

            var path = $"wwwroot/images/{uploadedFile.FileName}";
            await using var fs = new FileStream(path, FileMode.Create);
            fs.Write(uploadedFile.FileContent, 0, uploadedFile.FileContent.Length);
            return new CreatedResult(_env.WebRootPath, uploadedFile.FileName);
        }
    }
}

