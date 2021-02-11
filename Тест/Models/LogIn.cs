using System.ComponentModel.DataAnnotations;

namespace Тест.Models
{
    public class LogIn
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Не указано имя")]
        [StringLength(20)]
        [Display(Name="Имя")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Не указана фамилия")]
        [StringLength(20)]
        [Display(Name = "Фамилия")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Не указана почта")]
        [EmailAddress(ErrorMessage = "Некорректный электронный адрес")]
        [StringLength(30)]
        [Display(Name = "Почта")]
        public string Email { get; set; }

        public int True { get; set; }
        public int False { get; set; }

    }
}
