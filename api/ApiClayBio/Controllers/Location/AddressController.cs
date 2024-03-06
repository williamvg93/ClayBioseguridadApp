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

public class AddressController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public AddressController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<AddressDto>>> Get()
    {
        var addresses = await _unitOfWork.Addresses.GetAllAsync();
        /* return Ok(addresses); */
        return _mapper.Map<List<AddressDto>>(addresses);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<AddressDto>> Get(int id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        return _mapper.Map<AddressDto>(address);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Address>> Post(AddressPDto addressPDto)
    {
        var address = _mapper.Map<Address>(addressPDto);

        this._unitOfWork.Addresses.Add(address);
        await _unitOfWork.SaveAsync();
        if (address == null)
        {
            return BadRequest();
        }
        addressPDto.Id = address.Id;
        return CreatedAtAction(nameof(Post), new { id = addressPDto.Id }, addressPDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<AddressPDto>> Put(int id, [FromBody] AddressPDto addressPDto)
    {
        var address = _mapper.Map<Address>(addressPDto);
        if (address.Id == 0)
        {
            address.Id = id;
        }
        if (address.Id != id)
        {
            return BadRequest();
        }
        if (address == null)
        {
            return NotFound();
        }

        addressPDto.Id = address.Id;
        _unitOfWork.Addresses.Update(address);
        await _unitOfWork.SaveAsync();
        return addressPDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var address = await _unitOfWork.Addresses.GetByIdAsync(id);
        if (address == null)
        {
            return NotFound();
        }
        _unitOfWork.Addresses.Remove(address);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}