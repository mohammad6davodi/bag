using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UploadAndDisplayImageInMvc.Models
{
    public class Problem
    {
        [Key]
        public int ID { get; set; }

        [Required]
        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "شماره تلفن")]
        public string PhoneNumber { get; set; }

        [Required]
        [Display(Name = "توضیحات")]
        public string Paragraph { get; set; }
    }
}