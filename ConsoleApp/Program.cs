﻿using System;
using System.Collections.Generic;
using Application;
using Domain.Entities;


CompanyService companyService = new CompanyService();
EmployeeService employeeService = new EmployeeService();

while (true)
{
    Console.WriteLine("\nВыберите действие:");
    Console.WriteLine("1. Управление компаниями");
    Console.WriteLine("2. Управление сотрудниками");
    Console.WriteLine("0. Выход");

    var choice = Console.ReadLine();

    if (choice == "1")
    {
        ManageCompanies();
    }
    else if (choice == "2")
    {
        ManageEmployees();
    }
    else if (choice == "0")
    {
        Console.WriteLine("Завершение работы...");
        break;
    }
    else
    {
        Console.WriteLine("Неверный ввод. Попробуйте снова.");
    }
}

void ManageCompanies()
{

    while (true)
    {
        Console.WriteLine("\n--- Управление компаниями ---");
        Console.WriteLine("1. Показать все компании");
        Console.WriteLine("2. Найти компанию по ID");
        Console.WriteLine("3. Добавить новую компанию");
        Console.WriteLine("4. Обновить компанию");
        Console.WriteLine("5. Удалить компанию");
        Console.WriteLine("0. Назад");

        var choice = Console.ReadLine();

        if (choice == "1")
        {
            var companies = companyService.GetAllCompanies();
            foreach (var company in companies)
            {
                Console.WriteLine($"ID: {company.Id}, Name: {company.Name}, Description: {company.Descrition}");
            }
        }
        else if (choice == "2")
        {
            Console.Write("Введите ID компании: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var company = companyService.GetCompanyById(id);
                if (company != null)
                {
                    Console.WriteLine($"ID: {company.Id}, Name: {company.Name}, Description: {company.Descrition}");
                }
                else
                {
                    Console.WriteLine("Компания не найдена.");
                }
            }
        }
        else if (choice == "3")
        {
            Console.Write("Введите имя компании: ");
            var name = Console.ReadLine();
            Console.Write("Введите описание компании: ");
            var description = Console.ReadLine();

            var success = companyService.AddCompany(new Company { Name = name, Descrition = description });
            Console.WriteLine(success ? "Компания добавлена." : "Ошибка при добавлении.");
        }
        else if (choice == "4")
        {
            Console.Write("Введите ID компании: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                Console.Write("Введите новое имя компании: ");
                var name = Console.ReadLine();
                Console.Write("Введите новое описание компании: ");
                var description = Console.ReadLine();

                var success = companyService.UpdateCompany(new Company
                    { Id = id, Name = name, Descrition = description });
                Console.WriteLine(success ? "Компания обновлена." : "Ошибка при обновлении.");
            }
        }
        else if (choice == "5")
        {
            Console.Write("Введите ID компании: ");
            if (int.TryParse(Console.ReadLine(), out int id))
            {
                var success = companyService.DeleteCompany(id);
                Console.WriteLine(success ? "Компания удалена." : "Ошибка при удалении.");
            }
        }
        else if (choice == "0")
        {
        }
        else
        {
            Console.WriteLine("Неверный ввод. Попробуйте снова.");
        }
    }
}

// void ManageEmployees()
// {
//
//
//     while (true)
//     {
//         Console.WriteLine("\n--- Управление сотрудниками ---");
//         Console.WriteLine("1. Показать всех сотрудников");
//         Console.WriteLine("2. Найти сотрудника по ID");
//         Console.WriteLine("3. Добавить нового сотрудника");
//         Console.WriteLine("4. Обновить данные сотрудника");
//         Console.WriteLine("5. Удалить сотрудника");
//         Console.WriteLine("0. Назад");
//
//         var choice = Console.ReadLine();
//
//         if (choice == "1")
//         {
//             var employees = EmployeeService.GetAllEmployees();
//             foreach (var employee in employees)
//             {
//                 Console.WriteLine(
//                     $"ID: {employee.Id}, Name: {employee.FullName}, Email: {employee.Email}, DepartmentID: {employee.DepartmentId}, BranchID: {employee.BranchId}");
//             }
//         }
//         else if (choice == "2")
//         {
//             Console.Write("Введите ID сотрудника: ");
//             if (int.TryParse(Console.ReadLine(), out int id))
//             {
//                 var employee = EmployeeService.GetEmployeeById(id);
//                 if (employee != null)
//                 {
//                     Console.WriteLine(
//                         $"ID: {employee.Id}, Name: {employee.FullName}, Email: {employee.Email}, DepartmentID: {employee.DepartmentId}, BranchID: {employee.BranchId}");
//                 }
//                 else
//                 {
//                     Console.WriteLine("Сотрудник не найден.");
//                 }
//             }
//         }
//         else if (choice == "3")
//         {
//             Console.Write("Введите имя сотрудника: ");
//             var fullName = Console.ReadLine();
//             Console.Write("Введите email сотрудника: ");
//             var email = Console.ReadLine();
//             Console.Write("Введите ID отдела: ");
//             if (int.TryParse(Console.ReadLine(), out int departmentId))
//             {
//                 Console.Write("Введите ID филиала: ");
//                 if (int.TryParse(Console.ReadLine(), out int branchId))
//                 {
//                     var success = EmployeeService.AddEmployee(new Employee
//                         { FullName = fullName, Email = email, DepartmentId = departmentId, BranchId = branchId });
//                     Console.WriteLine(success ? "Сотрудник добавлен." : "Ошибка при добавлении.");
//                 }
//             }
//         }
//         else if (choice == "4")
//         {
//             Console.Write("Введите ID сотрудника: ");
//             if (int.TryParse(Console.ReadLine(), out int id))
//             {
//                 Console.Write("Введите новое имя сотрудника: ");
//                 var fullName = Console.ReadLine();
//                 Console.Write("Введите новый email сотрудника: ");
//                 var email = Console.ReadLine();
//                 Console.Write("Введите новый ID отдела: ");
//                 if (int.TryParse(Console.ReadLine(), out int departmentId))
//                 {
//                     Console.Write("Введите новый ID филиала: ");
//                     if (int.TryParse(Console.ReadLine(), out int branchId))
//                     {
//                         var success = EmployeeService.UpdateEmployee(new Employee
//                         {
//                             Id = id, FullName = fullName, Email = email, DepartmentId = departmentId,
//                             BranchId = branchId
//                         });
//                         Console.WriteLine(success ? "Данные сотрудника обновлены." : "Ошибка при обновлении.");
//                     }
//                 }
//             }
//         }
//         else if (choice == "5")
//         {
//             Console.Write("Введите ID сотрудника: ");
//             if (int.TryParse(Console.ReadLine(), out int id))
//             {
//                 var success = EmployeeService.DeleteEmployee(id);
//                 Console.WriteLine(success ? "Сотрудник удален." : "Ошибка при удалении.");
//             }
//         }
//         else if (choice == "0")
//         {
//             break;
//         }
//         else
//         {
//             Console.WriteLine("Неверный ввод. Попробуйте снова.");
//         }
//     }
// }