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

public class ContacttypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContacttypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContacttypeDto>>> Get()
    {
        var contacttypes = await _unitOfWork.Contacttypes.GetAllAsync();
        /* return Ok(contacttypes); */
        return _mapper.Map<List<ContacttypeDto>>(contacttypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContacttypeDto>> Get(int id)
    {
        var contacttype = await _unitOfWork.Contacttypes.GetByIdAsync(id);
        if (contacttype == null)
        {
            return NotFound();
        }
        return _mapper.Map<ContacttypeDto>(contacttype);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contacttype>> Post(ContacttypeDto contacttypeDto)
    {
        var contacttype = _mapper.Map<Contacttype>(contacttypeDto);

        this._unitOfWork.Contacttypes.Add(contacttype);
        await _unitOfWork.SaveAsync();
        if (contacttype == null)
        {
            return BadRequest();
        }
        contacttypeDto.Id = contacttype.Id;
        return CreatedAtAction(nameof(Post), new { id = contacttypeDto.Id }, contacttypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContacttypeDto>> Put(int id, [FromBody] ContacttypeDto contacttypeDto)
    {
        var contacttype = _mapper.Map<Contacttype>(contacttypeDto);
        if (contacttype.Id == 0)
        {
            contacttype.Id = id;
        }
        if (contacttype.Id != id)
        {
            return BadRequest();
        }
        if (contacttype == null)
        {
            return NotFound();
        }

        contacttypeDto.Id = contacttype.Id;
        _unitOfWork.Contacttypes.Update(contacttype);
        await _unitOfWork.SaveAsync();
        return contacttypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var contacttype = await _unitOfWork.Contacttypes.GetByIdAsync(id);
        if (contacttype == null)
        {
            return NotFound();
        }
        _unitOfWork.Contacttypes.Remove(contacttype);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}