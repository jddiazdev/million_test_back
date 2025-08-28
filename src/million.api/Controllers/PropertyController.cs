using Microsoft.AspNetCore.Mvc;
using million.application;
using million.application.dto;
using million.domain.entities;

namespace million.api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class PropertyController : ControllerBase
{
    private readonly PropertyService _service;

    public PropertyController(PropertyService service)
    {
        _service = service;
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var property = await _service.GetPropertyByIdAsync(id);
        if (property == null) return NotFound();
        return Ok(property);
    }


    [HttpPost]
    public async Task<IActionResult> created([FromBody] PropertyDto dto)
    {
        var property = new Property
        {
            name = dto.name,
            address = dto.address,
            price = dto.price,
            codeInternal = dto.codeInternal,
            year = dto.year,
            ownerId = dto.ownerId
        };

        await _service.AddPropertyAsync(property);
        return StatusCode(StatusCodes.Status201Created, property);
    }


    [HttpPost("createdPropertyImg")]
    public async Task<IActionResult> createdPropertyImg([FromBody] PropertyImgDto dto)
    {
        var propertyImage = new PropertyImage
        {
            propertyId = dto.propertyId,
            file = dto.file,
            enabled = true

        };

        await _service.AddPropertyImg(propertyImage);
        return StatusCode(StatusCodes.Status201Created, propertyImage);
    }



    [HttpPost("createdPropertyTrace")]
    public async Task<IActionResult> createdPropertyTrace([FromBody] PropertyTraceDto dto)
    {
        var propertyTrace = new PropertyTrace
        {
            propertyId = dto.propertyId,
            name = dto.name,
            value = dto.value,
            dateSale = dto.dateSale,
            tax = dto.tax
        };

        await _service.AddPropertyTrace(propertyTrace);
        return StatusCode(StatusCodes.Status201Created, propertyTrace);
    }

}
