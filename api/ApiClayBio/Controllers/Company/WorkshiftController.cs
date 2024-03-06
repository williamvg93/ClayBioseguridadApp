using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Get.Company;
using AutoMapper;
using Domain.Entities.Company;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBio.Controllers.Company;

public class WorkshiftController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public WorkshiftController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<WorkshiftDto>>> Get()
    {
        var workshifts = await _unitOfWork.Workshifts.GetAllAsync();
        /* return Ok(workshifts); */
        return _mapper.Map<List<WorkshiftDto>>(workshifts);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WorkshiftDto>> Get(int id)
    {
        var workshift = await _unitOfWork.Workshifts.GetByIdAsync(id);
        if (workshift == null)
        {
            return NotFound();
        }
        return _mapper.Map<WorkshiftDto>(workshift);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Workshift>> Post(WorkshiftDto workshiftDto)
    {
        var workshift = _mapper.Map<Workshift>(workshiftDto);

        this._unitOfWork.Workshifts.Add(workshift);
        await _unitOfWork.SaveAsync();
        if (workshift == null)
        {
            return BadRequest();
        }
        workshiftDto.Id = workshift.Id;
        return CreatedAtAction(nameof(Post), new { id = workshiftDto.Id }, workshiftDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<WorkshiftDto>> Put(int id, [FromBody] WorkshiftDto workshiftDto)
    {
        var workshift = _mapper.Map<Workshift>(workshiftDto);
        if (workshift.Id == 0)
        {
            workshift.Id = id;
        }
        if (workshift.Id != id)
        {
            return BadRequest();
        }
        if (workshift == null)
        {
            return NotFound();
        }

        workshiftDto.Id = workshift.Id;
        _unitOfWork.Workshifts.Update(workshift);
        await _unitOfWork.SaveAsync();
        return workshiftDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var workshift = await _unitOfWork.Workshifts.GetByIdAsync(id);
        if (workshift == null)
        {
            return NotFound();
        }
        _unitOfWork.Workshifts.Remove(workshift);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}