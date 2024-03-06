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

public class TownController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public TownController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<TownDto>>> Get()
    {
        var towns = await _unitOfWork.Towns.GetAllAsync();
        /* return Ok(towns); */
        return _mapper.Map<List<TownDto>>(towns);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<TownDto>> Get(int id)
    {
        var town = await _unitOfWork.Towns.GetByIdAsync(id);
        if (town == null)
        {
            return NotFound();
        }
        return _mapper.Map<TownDto>(town);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Town>> Post(TownPDto townPDto)
    {
        var town = _mapper.Map<Town>(townPDto);

        this._unitOfWork.Towns.Add(town);
        await _unitOfWork.SaveAsync();
        if (town == null)
        {
            return BadRequest();
        }
        townPDto.Id = town.Id;
        return CreatedAtAction(nameof(Post), new { id = townPDto.Id }, townPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<TownPDto>> Put(int id, [FromBody] TownPDto townPDto)
    {
        var town = _mapper.Map<Town>(townPDto);
        if (town.Id == 0)
        {
            town.Id = id;
        }
        if (town.Id != id)
        {
            return BadRequest();
        }
        if (town == null)
        {
            return NotFound();
        }

        townPDto.Id = town.Id;
        _unitOfWork.Towns.Update(town);
        await _unitOfWork.SaveAsync();
        return townPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var town = await _unitOfWork.Towns.GetByIdAsync(id);
        if (town == null)
        {
            return NotFound();
        }
        _unitOfWork.Towns.Remove(town);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}