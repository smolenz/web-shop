using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebStore.Models
{
    public class EmployeeView
    {
        public int Id { get; set; }

        [Display(Name = "Имя:")]
        [Required(ErrorMessage ="Поле должно быть заполнено")]
        public string FirstName { get; set; }

        [Display(Name = "Фамилия:")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string SurName { get; set; }

        [Display(Name = "Отчество:")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст:")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        [Range(1,120,ErrorMessage ="Неверное значение поля")]
        public int Age { get; set; }

        [Display(Name = "Город:")]
        [Required(ErrorMessage = "Поле должно быть заполнено")]
        public string City { get; set; }
    }
}
