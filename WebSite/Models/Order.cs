using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Order
    {
        [BindNever]
        public int id { get; set; }
        [Display(Name = "Введите имя")]
        [StringLength(10)]
        [Required(ErrorMessage ="Длина имени не больше 10 символов")]
        public string name { get; set; }

        [Display(Name = "Введите фамилию")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина не больше 15 символов")]
        public string surname { get; set; }

        [Display(Name = "Введите адрес")]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина не больше 15 символов")]
        public string adress { get; set; }

        [Display(Name = "Введите телефон")]
        [StringLength(15)]
        [DataType(DataType.PhoneNumber)]
        [Required(ErrorMessage = "Длина не больше 15 символов")]
        public string phone { get; set; }

        [Display(Name = "Введите Email")]
        [DataType(DataType.EmailAddress)]
        [StringLength(15)]
        [Required(ErrorMessage = "Длина не больше 15 символов")]
        public string email { get; set; }

        [BindNever]
        [ScaffoldColumn(false)]
        public DateTime orderTime { get; set; }
        public List<OrderDetail> orderDetails { get; set; }

    }
}
