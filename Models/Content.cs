using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace UploadAndDisplayImageInMvc.Models
{
    public class Content 
    {
        [Key]
        public int ID { get; set; }
        [Required]
        [Display(Name = "سر تیتر")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "توضیحات")]
        public string Description { get; set; }
        [Display(Name = "سه بعدی")]
        public string Link1 { get; set; }

        [Display(Name = "پیش نمایش عکس")]
        public byte[] Image { get; set; }
    }
}