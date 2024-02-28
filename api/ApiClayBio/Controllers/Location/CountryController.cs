using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiClayBio.Dtos.Get.Location;
using AutoMapper;
using Domain.Entities.Location;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ApiClayBio.Controllers.Location;

public class CountryController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public CountryController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<CountryDto>>> Get()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        /* return Ok(countries); */
        return _mapper.Map<List<CountryDto>>(countries);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<CountryDto>> Get(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        /* return Ok(country); */
        return _mapper.Map<CountryDto>(country);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Country>> Post(CountryDto countryDto)
    {
        var country = _mapper.Map<Country>(countryDto);

        this._unitOfWork.Countries.Add(country);
        await _unitOfWork.SaveAsync();
        if (country == null)
        {
            return BadRequest();
        }
        countryDto.Id = country.Id;
        return CreatedAtAction(nameof(Post), new { id = countryDto.Id }, countryDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<CountryDto>> Put(int id, [FromBody] CountryDto countryDto)
    {
        var country = _mapper.Map<Country>(countryDto);
        if (country.Id == 0)
        {
            country.Id = id;
        }
        if (country.Id != id)
        {
            return BadRequest();
        }
        if (country == null)
        {
            return NotFound();
        }

        countryDto.Id = country.Id;
        _unitOfWork.Countries.Update(country);
        await _unitOfWork.SaveAsync();
        return countryDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var country = await _unitOfWork.Countries.GetByIdAsync(id);
        if (country == null)
        {
            return NotFound();
        }
        _unitOfWork.Countries.Remove(country);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}