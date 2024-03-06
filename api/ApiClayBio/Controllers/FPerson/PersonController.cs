using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Get.FPerson;
using ApiClayBio.Dtos.Post.FPerson;
using AutoMapper;
using Domain.Entities.FPerson;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBio.Controllers.FPerson;

public class PersonController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersonController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersonDto>>> Get()
    {
        var people = await _unitOfWork.People.GetAllAsync();
        /* return Ok(people); */
        return _mapper.Map<List<PersonDto>>(people);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersonDto>> Get(int id)
    {
        var person = await _unitOfWork.People.GetByIdAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersonDto>(person);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Person>> Post(PersonPDto personPDto)
    {
        var person = _mapper.Map<Person>(personPDto);

        this._unitOfWork.People.Add(person);
        await _unitOfWork.SaveAsync();
        if (person == null)
        {
            return BadRequest();
        }
        personPDto.Id = person.Id;
        return CreatedAtAction(nameof(Post), new { id = personPDto.Id }, personPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersonPDto>> Put(int id, [FromBody] PersonPDto personPDto)
    {
        var person = _mapper.Map<Person>(personPDto);
        if (person.Id == 0)
        {
            person.Id = id;
        }
        if (person.Id != id)
        {
            return BadRequest();
        }
        if (person == null)
        {
            return NotFound();
        }

        personPDto.Id = person.Id;
        _unitOfWork.People.Update(person);
        await _unitOfWork.SaveAsync();
        return personPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var person = await _unitOfWork.People.GetByIdAsync(id);
        if (person == null)
        {
            return NotFound();
        }
        _unitOfWork.People.Remove(person);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}