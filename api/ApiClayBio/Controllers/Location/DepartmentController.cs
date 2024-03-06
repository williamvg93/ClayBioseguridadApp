using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Get.Location;
using ApiClayBio.Dtos.Post.Location;
using AutoMapper;
using Domain.Entities.Location;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBio.Controllers.Location;

public class DepartmentController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public DepartmentController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<DepartmentDto>>> Get()
    {
        var departments = await _unitOfWork.Departments.GetAllAsync();
        /* return Ok(departments); */
        return _mapper.Map<List<DepartmentDto>>(departments);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<DepartmentDto>> Get(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        return _mapper.Map<DepartmentDto>(department);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Department>> Post(DepartmentPDto departmentPDto)
    {
        var department = _mapper.Map<Department>(departmentPDto);

        this._unitOfWork.Departments.Add(department);
        await _unitOfWork.SaveAsync();
        if (department == null)
        {
            return BadRequest();
        }
        departmentPDto.Id = department.Id;
        return CreatedAtAction(nameof(Post), new { id = departmentPDto.Id }, departmentPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<DepartmentPDto>> Put(int id, [FromBody] DepartmentPDto departmentPDto)
    {
        var department = _mapper.Map<Department>(departmentPDto);
        if (department.Id == 0)
        {
            department.Id = id;
        }
        if (department.Id != id)
        {
            return BadRequest();
        }
        if (department == null)
        {
            return NotFound();
        }

        departmentPDto.Id = department.Id;
        _unitOfWork.Departments.Update(department);
        await _unitOfWork.SaveAsync();
        return departmentPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var department = await _unitOfWork.Departments.GetByIdAsync(id);
        if (department == null)
        {
            return NotFound();
        }
        _unitOfWork.Departments.Remove(department);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}