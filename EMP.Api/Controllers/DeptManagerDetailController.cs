using System.Collections.Generic;
using EMP.Data.Repos;
using EMP.Data.Models;
using EMP.Data.Models.Mapped;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Threading.Tasks;
using EMP.Common.Tasks;
using System.Linq;

namespace EMP.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeptManagerDetailController : ControllerBase
    {
        private ILogger<DeptManagerDetailController> _logger;
        private IDeptManagerCurrentRepository _deptManagerCurrentRepository;
        private IEmployeeRepository _employeeRepository;
        private IDeptEmpRepository _deptEmpRepository;
        private ITitleRepository _titleRepository;
        private IDepartmentsRepository _departmentsRepository;

        public DeptManagerDetailController(
            ILogger<DeptManagerDetailController> logger,
            IEmployeeRepository employeeRepository,
            IDeptEmpRepository deptEmpRepository,
            ITitleRepository titleRepository,
            IDeptManagerCurrentRepository deptManagerCurrentRepository,
            IDepartmentsRepository departmentsRepository)
        {
            this._logger = logger;
            this._employeeRepository = employeeRepository;
            this._deptEmpRepository = deptEmpRepository;
            this._titleRepository = titleRepository;
            this._deptManagerCurrentRepository = deptManagerCurrentRepository;
            this._departmentsRepository = departmentsRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DepartmentManagerDetail>>> Get()
        {
            IEnumerable<DepartmentManagerDetail> departmentManagers = 
                from d in await _departmentsRepository.GetAsync()
                join dm in await _deptManagerCurrentRepository.GetAsync()
                on d.DeptNo equals dm.DeptNo
                join e in await _employeeRepository.GetAsync()
                on dm.EmpNo equals e.EmpNo
                select new DepartmentManagerDetail {
                    DeptNo = d.DeptNo,
                    DeptName = d.DeptName,
                    FromDate = dm.FromDate,
                    ToDate = dm.ToDate,
                    EmpNo = e.EmpNo,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                };

            return Ok(departmentManagers);
        }

        [HttpGet("{id}", Name = "Get")]
        public async Task<ActionResult<DepartmentManagerDetail>> Get(string id)
        {
            IEnumerable<DepartmentManagerDetail> departmentManagers = 
                from d in await _departmentsRepository.GetAsync()
                join dm in await _deptManagerCurrentRepository.GetAsync()
                on d.DeptNo equals dm.DeptNo
                join e in await _employeeRepository.GetAsync()
                on dm.EmpNo equals e.EmpNo
                where d.DeptNo == id
                select new DepartmentManagerDetail {
                    DeptNo = d.DeptNo,
                    DeptName = d.DeptName,
                    FromDate = dm.FromDate,
                    ToDate = dm.ToDate,
                    EmpNo = e.EmpNo,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                };

            return departmentManagers.FirstOrDefault();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<DepartmentManagerDetail>> Put(string id, DepartmentManagerDetail deptManagerUpdateRequest)
        {
            VwDeptManagerCurrent vwDeptManagerCurrent = 
                new VwDeptManagerCurrent {
                    EmpNo = deptManagerUpdateRequest.EmpNo.Value,
                    DeptNo = deptManagerUpdateRequest.DeptNo,
                    FromDate = deptManagerUpdateRequest.FromDate.Value,
                    ToDate = deptManagerUpdateRequest.ToDate.Value,
                };
            VwDeptManagerCurrent result = await _deptManagerCurrentRepository.PutAsync(id, vwDeptManagerCurrent);
            Employees employee = await _employeeRepository.GetAsync(result.EmpNo);
            Departments department = await _departmentsRepository.GetAsync(result.DeptNo);

            DepartmentManagerDetail updatedDepartmentManagerDetail =    
                new DepartmentManagerDetail {
                    DeptNo = result.DeptNo,
                    DeptName = department.DeptName,
                    FromDate = result.FromDate,
                    ToDate = result.ToDate,
                    EmpNo = employee.EmpNo,
                    FirstName = employee.FirstName,
                    LastName = employee.LastName,
                };
            return updatedDepartmentManagerDetail;
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentManagerDetail>> Post(DepartmentManagerDetail deptManagerCreateRequest) 
        {
            VwDeptManagerCurrent vwDeptManagerCurrent = 
                new VwDeptManagerCurrent {
                    EmpNo = deptManagerCreateRequest.EmpNo.Value,
                    DeptNo = deptManagerCreateRequest.DeptNo,
                    FromDate = deptManagerCreateRequest.FromDate.Value,
                    ToDate = deptManagerCreateRequest.ToDate.Value,
                };
            ActionResult<VwDeptManagerCurrent> result = await _deptManagerCurrentRepository.PostAsync(vwDeptManagerCurrent);
            string newDeptNo = result.Value.DeptNo;
            
            IEnumerable<DepartmentManagerDetail> departmentManagers = 
                from d in await _departmentsRepository.GetAsync()
                join dm in await _deptManagerCurrentRepository.GetAsync()
                on d.DeptNo equals dm.DeptNo
                join e in await _employeeRepository.GetAsync()
                on dm.EmpNo equals e.EmpNo
                where d.DeptNo == newDeptNo
                select new DepartmentManagerDetail {
                    DeptNo = d.DeptNo,
                    DeptName = d.DeptName,
                    FromDate = dm.FromDate,
                    ToDate = dm.ToDate,
                    EmpNo = e.EmpNo,
                    FirstName = e.FirstName,
                    LastName = e.LastName,
                };

            return departmentManagers.FirstOrDefault();
        }
        
        // [HttpDelete("{id}")]
        // public async Task<ActionResult<DeptManager>> Delete(int id) 
        // {
        //     // throw new NotImplementedException();
        //     return await TaskConstants<ActionResult<DeptManager>>.NotImplemented;
        // }
    }
}