using Asp.NetCore.Mvc.Models;
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
    public class ImageController : Controller
    {
        private readonly IHostingEnvironment _environment;
        public ImageController(IHostingEnvironment environment)
        {
            _environment = environment;
        }

        public IActionResult Index()
        {

            var imageSavePath = Path.Combine(_environment.WebRootPath, @"image\list\");
            var imageList = Directory
                                    .GetFiles(imageSavePath)    
                                    .Select(x => new FileInfo(x))           // 파일 정보 수집
                                    .OrderByDescending(x => x.LastWriteTime)// 시간의 내림차순으로 정렬
                                    .Select(x => @"image\list\" + x.Name)   // 파일 표시 목록 생성
                                    .ToList();
            return View(imageList);
        }


        //루트를 설정하여 강제로 이동하게 만듬
        [Route("Image/Upload")]
        [Route("Image/Upload/{fileModel?}")]
        public async Task<IActionResult> Upload(FileBufferModel fileModel)
        {
            // 저장 실패시에 메세지 출력 필요
            if(ModelState.IsValid)
            {
                var path = Path.Combine(_environment.WebRootPath, @"image\list\");
                var fileFullName = fileModel.FormFile.FileName.Split('.');
                var fileName = $"{Guid.NewGuid()}_{Guid.NewGuid()}.{fileFullName[1]}";
                using (var fileStream = new FileStream(Path.Combine(path, fileName), FileMode.Create))
                {

                    await fileModel.FormFile.CopyToAsync(fileStream);
                }
            }
            return RedirectToAction("Index", "Image");
        }
    }
}
