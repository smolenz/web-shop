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
        public string FirstName { get; set; }

        [Display(Name = "Фамилия:")]
        public string SurName { get; set; }

        [Display(Name = "Отчество:")]
        public string Patronymic { get; set; }

        [Display(Name = "Возраст:")]
        public int Age { get; set; }

        [Display(Name = "Город:")]
        public string City { get; set; }

        [Display(Name = "Хобби:")]
        public string Hobby { get; set; }
    }
}
