using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Get.FPerson;
using AutoMapper;
using Domain.Entities.FPerson;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBio.Controllers.FPerson;

public class PersontypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersontypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersontypeDto>>> Get()
    {
        var peopletypes = await _unitOfWork.Persontypes.GetAllAsync();
        /* return Ok(peopletypes); */
        return _mapper.Map<List<PersontypeDto>>(peopletypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersontypeDto>> Get(int id)
    {
        var persontype = await _unitOfWork.Persontypes.GetByIdAsync(id);
        if (persontype == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersontypeDto>(persontype);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Persontype>> Post(PersontypeDto persontypeDto)
    {
        var persontype = _mapper.Map<Persontype>(persontypeDto);

        this._unitOfWork.Persontypes.Add(persontype);
        await _unitOfWork.SaveAsync();
        if (persontype == null)
        {
            return BadRequest();
        }
        persontypeDto.Id = persontype.Id;
        return CreatedAtAction(nameof(Post), new { id = persontypeDto.Id }, persontypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersontypeDto>> Put(int id, [FromBody] PersontypeDto persontypeDto)
    {
        var persontype = _mapper.Map<Persontype>(persontypeDto);
        if (persontype.Id == 0)
        {
            persontype.Id = id;
        }
        if (persontype.Id != id)
        {
            return BadRequest();
        }
        if (persontype == null)
        {
            return NotFound();
        }

        persontypeDto.Id = persontype.Id;
        _unitOfWork.Persontypes.Update(persontype);
        await _unitOfWork.SaveAsync();
        return persontypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var persontype = await _unitOfWork.Persontypes.GetByIdAsync(id);
        if (persontype == null)
        {
            return NotFound();
        }
        _unitOfWork.Persontypes.Remove(persontype);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}