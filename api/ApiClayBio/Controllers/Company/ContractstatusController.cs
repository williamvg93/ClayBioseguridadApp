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

public class ContractstatusController : BaseController
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public ContractstatusController(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    /* Get all Data from Table */
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<IEnumerable<ContractstatusDto>>> Get()
    {
        var contractsstatus = await _unitOfWork.Contractsstatus.GetAllAsync();
        /* return Ok(contractsstatus); */
        return _mapper.Map<List<ContractstatusDto>>(contractsstatus);
    }

    /* Get Data by ID */
    [HttpGet("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<ContractstatusDto>> Get(int id)
    {
        var contracrstatus = await _unitOfWork.Contractsstatus.GetByIdAsync(id);
        if (contracrstatus == null)
        {
            return NotFound();
        }
        return _mapper.Map<ContractstatusDto>(contracrstatus);
    }

    /* Add a new Data in the Table */
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<Contractstatus>> Post(ContractstatusDto contractstatusDto)
    {
        var contracrstatus = _mapper.Map<Contractstatus>(contractstatusDto);

        this._unitOfWork.Contractsstatus.Add(contracrstatus);
        await _unitOfWork.SaveAsync();
        if (contracrstatus == null)
        {
            return BadRequest();
        }
        contractstatusDto.Id = contracrstatus.Id;
        return CreatedAtAction(nameof(Post), new { id = contractstatusDto.Id }, contractstatusDto);
    }

    /* Update Data By ID  */
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult<ContractstatusDto>> Put(int id, [FromBody] ContractstatusDto contractstatusDto)
    {
        var contracrstatus = _mapper.Map<Contractstatus>(contractstatusDto);
        if (contracrstatus.Id == 0)
        {
            contracrstatus.Id = id;
        }
        if (contracrstatus.Id != id)
        {
            return BadRequest();
        }
        if (contracrstatus == null)
        {
            return NotFound();
        }

        contractstatusDto.Id = contracrstatus.Id;
        _unitOfWork.Contractsstatus.Update(contracrstatus);
        await _unitOfWork.SaveAsync();
        return contractstatusDto;
    }

    /* Delete Data By ID */
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<ActionResult> Delete(int id)
    {
        var contracrstatus = await _unitOfWork.Contractsstatus.GetByIdAsync(id);
        if (contracrstatus == null)
        {
            return NotFound();
        }
        _unitOfWork.Contractsstatus.Remove(contracrstatus);
        await _unitOfWork.SaveAsync();
        return NoContent();
    }
}