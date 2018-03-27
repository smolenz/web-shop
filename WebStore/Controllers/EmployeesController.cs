﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebStore.Infrastructure.Interfaces;
using WebStore.Models;

namespace WebStore.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly IEmployeesData _employeesData;

        public EmployeesController(IEmployeesData employeesData)
        {
            _employeesData = employeesData;
        }
        /// <summary>
        /// Вывод списка
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            return View(_employeesData.GetAll());
        }
        /// <summary>
        /// Детали о сотруднике
        /// </summary>
        /// <param name="id">Id сотрудника</param>
        /// <returns></returns>
        public IActionResult Details(int id)
        {
            // Получаем сотрудника по Id
            var employee = _employeesData.GetById(id);
            // Если такого не существует
            if (ReferenceEquals(employee, null))
                return NotFound();// возвращаем результат 404 Not Found
                                  // Иначе возвращаем сотрудника
            return View(employee);
        }

        public IActionResult Edit(int? id)
        {
            EmployeeView model;
            if (id.HasValue)
            {
                model = _employeesData.GetById(id.Value);
                if (ReferenceEquals(model, null))
                    return NotFound();// возвращаем результат 404 Not Found
            }
            else
            {
                model = new EmployeeView();
            }
            return View(model);
        }
        [HttpPost]

        public IActionResult Edit(EmployeeView model)
        {
            if (ModelState.IsValid)
            {
                if (model.Id > 0)
                {
                    var dbItem = _employeesData.GetById(model.Id);
                    if (ReferenceEquals(dbItem, null))
                        return NotFound();// возвращаем результат 404 Not Found
                    dbItem.FirstName = model.FirstName;
                    dbItem.SurName = model.SurName;
                    dbItem.Age = model.Age;
                    dbItem.Patronymic = model.Patronymic;
                    dbItem.City = dbItem.City;
                }
                else
                {
                    _employeesData.AddNew(model);
                }
                _employeesData.Commit();
                return RedirectToAction(nameof(Index));
            }
            return View(model);   
        }        public IActionResult Delete(int id)
        {
            _employeesData.Delete(id);
            return RedirectToAction(nameof(Index));
        }
    }
}