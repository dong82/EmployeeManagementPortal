// using System.Collections.Generic;
// using EMP.Data.Repos;
// using EMP.Data.Models;
// using EMP.Data.Models.Mapped;
// using Microsoft.AspNetCore.Mvc;
// using Microsoft.Extensions.Logging;
// using System;
// using System.Threading.Tasks;
// using EMP.Common.Tasks;
// using System.Linq;

// namespace EMP.Api.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class DeptManagerController : ControllerBase
//     {
//         private ILogger<DeptManagerController> _logger;
//         private IRepository<DeptManager> _deptManagerRepository;
//         private IRepository<Employees> _employeeRepository;
//         private IRepository<Departments> _departmentsRepository;

//         public DeptManagerController(
//             ILogger<DeptManagerController> logger,
//             IRepository<DeptManager> deptManagerRepository,
//             IRepository<Employees> employeeRepository,
//             IRepository<Departments> departmentsRepository)
//         {
//             this._logger = logger;
//             this._deptManagerRepository = deptManagerRepository;
//             this._employeeRepository = employeeRepository;
//             this._departmentsRepository = departmentsRepository;
//         }

//         [HttpGet]
//         public async Task<ActionResult<IEnumerable<DepartmentManagerDetail>>> Get()
//         {
//             await Task.Delay(0);
//             IEnumerable<DepartmentManagerDetail> departmentManagers = 
//                 from d in _departmentsRepository.GetAsync()
//                 join dm in _deptManagerRepository.GetAsync()
//                 on d.DeptNo equals dm.DeptNo
//                 join e in _employeeRepository.GetAsync()
//                 on dm.EmpNo equals e.EmpNo
//                 select new DepartmentManagerDetail {
//                     DeptNo = d.DeptNo,
//                     DeptName = d.DeptName,
//                     FromDate = dm.FromDate,
//                     ToDate = dm.ToDate,
//                     EmpNo = e.EmpNo,
//                     FirstName = e.FirstName,
//                     LastName = e.LastName,
//                 };

//             return Ok(departmentManagers);
//         }

//         [HttpGet("{id}")]
//         public async Task<ActionResult<DepartmentManagerDetail>> Get(string id)
//         {
//             await Task.Delay(0);
//             IEnumerable<DepartmentManagerDetail> departmentManagers = 
//                 from d in  _departmentsRepository.GetAsync()
//                 join dm in _deptManagerRepository.GetAsync()
//                 on d.DeptNo equals dm.DeptNo
//                 join e in _employeeRepository.GetAsync()
//                 on dm.EmpNo equals e.EmpNo
//                 where d.DeptNo == id
//                 select new DepartmentManagerDetail {
//                     DeptNo = d.DeptNo,
//                     DeptName = d.DeptName,
//                     FromDate = dm.FromDate,
//                     ToDate = dm.ToDate,
//                     EmpNo = e.EmpNo,
//                     FirstName = e.FirstName,
//                     LastName = e.LastName,
//                 };

//             return departmentManagers.FirstOrDefault();
//         }

//         [HttpPut("{id}")]
//         public async Task<ActionResult<DeptManager>> Put(string id, DeptManager deptManagerUpdateRequest)
//         {
//             ActionResult<DeptManager> result = await _deptManagerRepository.PutAsync(id, deptManagerUpdateRequest);
//             return result;
//         }

//         [HttpPost]
//         public async Task<ActionResult<DeptManager>> Post(DeptManager deptManagerCreateRequest) 
//         {
//             DeptManager result = await _deptManagerRepository.PostAsync(deptManagerCreateRequest);
//             return CreatedAtAction(
//                 nameof(Post), 
//                 nameof(DeptManagerController), 
//                 new { empNo = result.EmpNo, deptNo = result.DeptNo }, 
//                 result);
//         }
        
//         [HttpDelete("{id}")]
//         public async Task<ActionResult<DeptManager>> Delete(int id) 
//         {
//             // throw new NotImplementedException();
//             return await TaskConstants<ActionResult<DeptManager>>.NotImplemented;
//         }
//     }
// }