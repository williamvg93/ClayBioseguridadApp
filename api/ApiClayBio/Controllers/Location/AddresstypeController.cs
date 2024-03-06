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

public class AddresstypeController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddresstypeController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AddresstypeDto>>> Get()
    {
        var addresstypes = await _unitOfWork.Addresstypes.GetAllAsync();
        /* return Ok(addresstypes); */
        return _mapper.Map<List<AddresstypeDto>>(addresstypes);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddresstypeDto>> Get(int id)
    {
        var addresstype = await _unitOfWork.Addresstypes.GetByIdAsync(id);
        if (addresstype == null)
        {
            return NotFound();
        }
        return _mapper.Map<AddresstypeDto>(addresstype);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Addresstype>> Post(AddresstypeDto addresstypeDto)
    {
        var addresstype = _mapper.Map<Addresstype>(addresstypeDto);

        this._unitOfWork.Addresstypes.Add(addresstype);
        await _unitOfWork.SaveAsync();
        if (addresstype == null)
        {
            return BadRequest();
        }
        addresstypeDto.Id = addresstype.Id;
        return CreatedAtAction(nameof(Post), new { id = addresstypeDto.Id }, addresstypeDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddresstypeDto>> Put(int id, [FromBody] AddresstypeDto addresstypeDto)
    {
        var addresstype = _mapper.Map<Addresstype>(addresstypeDto);
        if (addresstype.Id == 0)
        {
            addresstype.Id = id;
        }
        if (addresstype.Id != id)
        {
            return BadRequest();
        }
        if (addresstype == null)
        {
            return NotFound();
        }

        addresstypeDto.Id = addresstype.Id;
        _unitOfWork.Addresstypes.Update(addresstype);
        await _unitOfWork.SaveAsync();
        return addresstypeDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var addresstype = await _unitOfWork.Addresstypes.GetByIdAsync(id);
        if (addresstype == null)
        {
            return NotFound();
        }
        _unitOfWork.Addresstypes.Remove(addresstype);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}