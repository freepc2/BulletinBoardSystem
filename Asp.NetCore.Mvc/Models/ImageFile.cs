using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Asp.NetCore.Mvc.Models
{
    public class ImageFile
    {
        public int Id { get; set; }
        public byte[] Content { get; set; }
        [Display(Name ="File Name")]
        public string Note { get; set; }
        [Display(Name ="Size(bytes")]
        [DisplayFormat(DataFormatString ="{0:N0")]
        public long Size { get; set; }

        [Display(Name ="Uploaded (UTC)")]
        [DisplayFormat(DataFormatString ="{0:G}")]
        public DateTime UploadDT { get; set; }
    }
    public class FileBufferModel
    {
        [Required]
        [Display(Name = "File")]
        public IFormFile FormFile { get; set; }

        [Display(Name = "Note")]
        [StringLength(50, MinimumLength = 0)]
        public string Note { get; set; }

    }
}
