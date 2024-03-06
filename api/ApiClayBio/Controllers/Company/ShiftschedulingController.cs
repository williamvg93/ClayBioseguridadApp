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

public class ShiftschedulingController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ShiftschedulingController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ShiftschedulingDto>>> Get()
    {
        var shiftshedulings = await _unitOfWork.Shiftschedulings.GetAllAsync();
        /* return Ok(shiftshedulings); */
        return _mapper.Map<List<ShiftschedulingDto>>(shiftshedulings);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ShiftschedulingDto>> Get(int id)
    {
        var shiftsheduling = await _unitOfWork.Shiftschedulings.GetByIdAsync(id);
        if (shiftsheduling == null)
        {
            return NotFound();
        }
        return _mapper.Map<ShiftschedulingDto>(shiftsheduling);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Shiftscheduling>> Post(ShiftschedulingDto shiftschedulingDto)
    {
        var shiftsheduling = _mapper.Map<Shiftscheduling>(shiftschedulingDto);

        this._unitOfWork.Shiftschedulings.Add(shiftsheduling);
        await _unitOfWork.SaveAsync();
        if (shiftsheduling == null)
        {
            return BadRequest();
        }
        shiftschedulingDto.Id = shiftsheduling.Id;
        return CreatedAtAction(nameof(Post), new { id = shiftschedulingDto.Id }, shiftschedulingDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ShiftschedulingDto>> Put(int id, [FromBody] ShiftschedulingDto shiftschedulingDto)
    {
        var shiftsheduling = _mapper.Map<Shiftscheduling>(shiftschedulingDto);
        if (shiftsheduling.Id == 0)
        {
            shiftsheduling.Id = id;
        }
        if (shiftsheduling.Id != id)
        {
            return BadRequest();
        }
        if (shiftsheduling == null)
        {
            return NotFound();
        }

        shiftschedulingDto.Id = shiftsheduling.Id;
        _unitOfWork.Shiftschedulings.Update(shiftsheduling);
        await _unitOfWork.SaveAsync();
        return shiftschedulingDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var shiftsheduling = await _unitOfWork.Shiftschedulings.GetByIdAsync(id);
        if (shiftsheduling == null)
        {
            return NotFound();
        }
        _unitOfWork.Shiftschedulings.Remove(shiftsheduling);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}