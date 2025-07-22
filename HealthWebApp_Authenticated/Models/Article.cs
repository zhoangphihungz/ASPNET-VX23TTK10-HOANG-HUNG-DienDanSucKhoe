using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Web.Mvc;

namespace HealthWebApp_Authenticated.Models
{
    public class Article
    {
        public int Id { get; set; }

        [DisplayName("Tiêu đề")]
        [Required(ErrorMessage = "Tiêu đề không được để trống.")]
        public string Title { get; set; }

        [DisplayName("Nội dung")]
        [DataType(DataType.MultilineText)] // Thêm dòng này để tạo ô nhập liệu nhiều dòng
        [AllowHtml]
        public string Content { get; set; }

        [DisplayName("Tác giả")]
        public string Author { get; set; }

        [DisplayName("Ngày xuất bản")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime PublishedDate { get; set; }

        [DisplayName("URL Hình ảnh")]
        public string ImageUrl { get; set; }
    }
}