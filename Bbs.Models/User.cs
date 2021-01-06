using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace Bbs.Models
{
    public class User : IdentityUser<int>
    {
        /// <summary>
        /// User 이름 
        /// </summary>
      //  [Required]
        public string FirstName { get; set; }
        /// <summary>
        /// User 성
        /// </summary>
      //  [Required]
        public string LastName { get; set; }

    }
}
