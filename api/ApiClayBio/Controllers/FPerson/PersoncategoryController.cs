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

public class PersoncategoryController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public PersoncategoryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<PersoncategoryDto>>> Get()
    {
        var peoplecategoy = await _unitOfWork.Personcategories.GetAllAsync();
        /* return Ok(peoplecategoy); */
        return _mapper.Map<List<PersoncategoryDto>>(peoplecategoy);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<PersoncategoryDto>> Get(int id)
    {
        var personcategory = await _unitOfWork.Personcategories.GetByIdAsync(id);
        if (personcategory == null)
        {
            return NotFound();
        }
        return _mapper.Map<PersoncategoryDto>(personcategory);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Personcategory>> Post(PersoncategoryDto personcategoryDto)
    {
        var personcategory = _mapper.Map<Personcategory>(personcategoryDto);

        this._unitOfWork.Personcategories.Add(personcategory);
        await _unitOfWork.SaveAsync();
        if (personcategory == null)
        {
            return BadRequest();
        }
        personcategoryDto.Id = personcategory.Id;
        return CreatedAtAction(nameof(Post), new { id = personcategoryDto.Id }, personcategoryDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<PersoncategoryDto>> Put(int id, [FromBody] PersoncategoryDto personcategoryDto)
    {
        var personcategory = _mapper.Map<Personcategory>(personcategoryDto);
        if (personcategory.Id == 0)
        {
            personcategory.Id = id;
        }
        if (personcategory.Id != id)
        {
            return BadRequest();
        }
        if (personcategory == null)
        {
            return NotFound();
        }

        personcategoryDto.Id = personcategory.Id;
        _unitOfWork.Personcategories.Update(personcategory);
        await _unitOfWork.SaveAsync();
        return personcategoryDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var personcategory = await _unitOfWork.Personcategories.GetByIdAsync(id);
        if (personcategory == null)
        {
            return NotFound();
        }
        _unitOfWork.Personcategories.Remove(personcategory);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}