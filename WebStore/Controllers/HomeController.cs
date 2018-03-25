using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class HomeController : Controller
    {
        private readonly List<EmployeeView> _employees = new List<EmployeeView>
{
        new EmployeeView
        {
        Id = 1,
        FirstName = "Иван",
        SurName = "Иванов",
        Patronymic = "Иванович",
        Age = 22,
        City= "Москва",
        Hobby="Аквариумистика"
        },
        new EmployeeView
        {
        Id = 2,
        FirstName = "Владислав",
        SurName = "Петров",
        Patronymic = "Иванович",
        Age = 35,
        City= "Иваново",
        Hobby="Моделизм"
        }
        };

        public IActionResult Index()
        {
            return View(_employees);
        }

        public IActionResult Details(int id)
        {
            EmployeeView employee = _employees.Where(x => x.Id == id).FirstOrDefault();
            if (employee == null)
                return NotFound();
            return View(employee);
        }

        public IActionResult Shop()
        {
            return View();
        }
        public IActionResult ProductDetails()
        {
            return View();
        }
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult ContactUs()
        {
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Cart()
        {
            return View();
        }
        public IActionResult BlogSingle()
        {
            return View();
        }
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult NotFound()
        {
            return View();
        }
    }
}