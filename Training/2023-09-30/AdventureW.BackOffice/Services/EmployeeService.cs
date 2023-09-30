using AdventureW.BackOffice.Model;

using AdventureWork.Models;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AdventureW.BackOffice.Services
{
    public class EmployeeService
    {
        private readonly AdventureWorksDW2017Context _context;

        public EmployeeService(AdventureWorksDW2017Context context)
        {
            _context = context;
        }

        public async Task<IEnumerable<EmployeeSummaryInfo>> GetEmployeeListAsync(int page = 1, int pageSize = 10)
        {
            var employeeList = await _context.DimEmployees
                .Skip((page-1)*pageSize)
                .Take(pageSize)
                .Select(emp=> new
                {
                    Id = emp.EmployeeKey,
                    FullName = emp.FirstName + " "+emp.MiddleName + " "+emp.LastName,
                    emp.Title,
                    emp.BirthDate,
                    emp.HireDate,
                    emp.EmployeePhoto,
                    SuperVisor = emp.ParentEmployeeKey == null ? string.Empty : emp.ParentEmployeeKeyNavigation.FirstName + " "+ emp.ParentEmployeeKeyNavigation.MiddleName + " "+ emp.ParentEmployeeKeyNavigation.LastName
                }).ToListAsync();

            var employeeSummaries = employeeList.Select(emp => new EmployeeSummaryInfo
            {
                BirthDate = emp.BirthDate.Value,
                HireDate = emp.HireDate.Value,
                FullName = emp.FullName,
                Id = emp.Id,
                SuperVisor = emp.SuperVisor,
                Title = emp.Title,
                Photo = Convert.ToBase64String(emp.EmployeePhoto)
                
            });

            return employeeSummaries;
        }

        public async Task<EmployeeEditModel> GetEmployeeAsync(int id)
        {
            var employeeEdit = await _context.DimEmployees.Select(e => new EmployeeEditModel
            {
                BirthDate=e.BirthDate.Value,
                FirstName = e.FirstName,
                HireDate=e.HireDate.Value,
                Id = e.EmployeeKey,
                LastName = e.LastName,
                MiddleName = e.MiddleName,
                SuperVisorId = e.ParentEmployeeKey,
                Title = e.Title
            })
            .SingleOrDefaultAsync(e=> e.Id == id);

            return employeeEdit;

        }

        public async Task<IEnumerable<SelectListItem>> GetEmployeeSelectList()
        {
            var employeeSelectList = await _context.DimEmployees
                .Select(e => new SelectListItem
                {
                    Text = e.FirstName + " "+e.MiddleName + " "+e.LastName,
                    Value = e.EmployeeKey.ToString()
                }).ToListAsync();

            employeeSelectList.Insert(0,new SelectListItem { Text = "No Super Visor",Value= "-1" });

            return employeeSelectList;
        }

        public async Task<bool> UpdateEmployee(EmployeeEditModel editEmployee)
        {
            var employee = await _context.DimEmployees.SingleOrDefaultAsync(e=> e.EmployeeKey == editEmployee.Id);

            employee.FirstName = editEmployee.FirstName;
            employee.LastName = editEmployee.LastName;
            employee.MiddleName = editEmployee.MiddleName;
            employee.Title = editEmployee.Title;
            employee.HireDate = editEmployee.HireDate;
            employee.BirthDate = editEmployee.BirthDate;
            employee.ParentEmployeeKey = editEmployee.SuperVisorId == null || editEmployee.SuperVisorId == -1 ? null : editEmployee.SuperVisorId;

            return await _context.SaveChangesAsync() > 0;
        }
    }
}
