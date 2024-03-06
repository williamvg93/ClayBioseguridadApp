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

public class PersoncontactController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersoncontactController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersoncontactDto>>> Get()
    {
        var personcontacts = await _unitOfWork.Personcontacts.GetAllAsync();
        /* return Ok(personcontacts); */
        return _mapper.Map<List<PersoncontactDto>>(personcontacts);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersoncontactDto>> Get(int id)
    {
        var personcontact = await _unitOfWork.Personcontacts.GetByIdAsync(id);
        if (personcontact == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersoncontactDto>(personcontact);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Personcontact>> Post(PersoncontactPDto personcontactPDto)
    {
        var personcontact = _mapper.Map<Personcontact>(personcontactPDto);

        this._unitOfWork.Personcontacts.Add(personcontact);
        await _unitOfWork.SaveAsync();
        if (personcontact == null)
        {
            return BadRequest();
        }
        personcontactPDto.Id = personcontact.Id;
        return CreatedAtAction(nameof(Post), new { id = personcontactPDto.Id }, personcontactPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersoncontactPDto>> Put(int id, [FromBody] PersoncontactPDto personcontactPDto)
    {
        var personcontact = _mapper.Map<Personcontact>(personcontactPDto);
        if (personcontact.Id == 0)
        {
            personcontact.Id = id;
        }
        if (personcontact.Id != id)
        {
            return BadRequest();
        }
        if (personcontact == null)
        {
            return NotFound();
        }

        personcontactPDto.Id = personcontact.Id;
        _unitOfWork.Personcontacts.Update(personcontact);
        await _unitOfWork.SaveAsync();
        return personcontactPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var personcontact = await _unitOfWork.Personcontacts.GetByIdAsync(id);
        if (personcontact == null)
        {
            return NotFound();
        }
        _unitOfWork.Personcontacts.Remove(personcontact);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}