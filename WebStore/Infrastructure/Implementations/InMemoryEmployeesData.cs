using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Infrastructure.Implementations
{
    /// <inheritdoc />
    /// <summary>
    /// Реализация интерфейса, хранит инфу в памяти
    /// </summary>
    public class InMemoryEmployeesData : IEmployeesData
    {
        private readonly List<EmployeeView> _employees;

        public object ModelState { get; private set; }

        public InMemoryEmployeesData()
        {
            _employees = new List<EmployeeView>(3)
        {
        new EmployeeView()
        {
            Id = 1,
            FirstName = "Вася",
            SurName = "Пупкин",
            Patronymic ="Иванович",
            Age = 22,
            City = "Иваново"
        },
        new EmployeeView()
        {
            Id = 1,
            FirstName = "Иван",
            SurName = "Иванов",
            Patronymic ="Иванович",
            Age = 30,
            City = "Москва"
        },
        new EmployeeView()
        {
            Id = 1,
            FirstName = "Елена",
            SurName = "Гришина",
            Patronymic ="Павловна",
            Age = 40,
            City = "Н. Новгород"
        }
        };
        }
        public IEnumerable<EmployeeView> GetAll()
        {
            return _employees;
        }
        public EmployeeView GetById(int id)
        {
            return _employees.FirstOrDefault(e => e.Id.Equals(id));
        }
        public void Commit()
        {
            // ничего не делаем
        }
        public void AddNew(EmployeeView model)
        {
            model.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(model);           
        }
        public void Delete(int id)
        {
            var employee = GetById(id);
            if (employee != null)
            {
                _employees.Remove(employee);
            }
        }
    }
}
