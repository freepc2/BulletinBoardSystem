using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc.Controllers
{
    public class UploadController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public UploadController(IHostingEnvironment environment)
        {
            _environment = environment;
        }


        [HttpPost, Route("api/upload")]
        public async Task<IActionResult> ImageUpload(IFormFile fileToUpload)
        {
            /* # 이미지나 파일을 업로드 할때 필요한 구성
             * 1. Path(경로)  - 저장위치(wwwroot/image/upload)
             * 2. Name(경로)  - DateTime(동시 업로드시 문제), GUID(전역고유식별자)- 중복 가능성이 조금 있음
             * 3. Extension(확장자)
             * File 이름 변경
             */
            // Path = wwwroot/image/upload
            var path = Path.Combine(_environment.WebRootPath, @"image\upload\");
            var fileFullName = fileToUpload.FileName.Split('.');
            var fileName = $"{Guid.NewGuid()}_{Guid.NewGuid()}.{fileFullName[1]}";
            // 파일 저장
            using(var fileStream = new FileStream(Path.Combine(path,fileName),FileMode.Create))
            {
                await fileToUpload.CopyToAsync(fileStream);
            }
            // 저장된 파일 위치 및 이름 전송
            return Ok(new { file = "/image/upload/" + fileName, success = true });
        }
    }
}
