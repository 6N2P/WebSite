using System.ComponentModel.DataAnnotations;

namespace WebSite.Models
{
    public class Contact
    {
        [Display(Name = "Введите имя")]
        [Required(ErrorMessage ="Обязательное поле")]
        public string Name { get; set; }

        [Display(Name = "Введите фамилию")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Sername { get; set; }

        [Display(Name = "Введите возраст")]
        [Required(ErrorMessage = "Обязательное поле")]
        public int Age { get; set; }

        [Display(Name = "Введите почту")]
        [Required(ErrorMessage = "Обязательное поле")]
        public string Email { get; set; }

        [Display(Name = "Введите сообщение")]
        [Required(ErrorMessage = "Обязательное поле")]
        [StringLength(2,ErrorMessage ="Сообщение немение 2х символов")]
        public string Message { get; set; }
    }
}
