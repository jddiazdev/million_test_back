
using Microsoft.AspNetCore.Mvc;
using million.application.dto;
using million.application.services;
using million.domain.entities;

namespace million.api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OwnerController : Controller
{
  private readonly OwnerService _service;




  public OwnerController(OwnerService service)
  {
    _service = service;
  }


  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(string id)
  {
    var property = await _service.GetOwnerByIdAsync(id);
    if (property == null) return NotFound();
    return Ok(property);
  }

  [HttpPost]
  public async Task<IActionResult> create([FromBody] OwnerDto dto)
  {
    var owner = new Owner
    {
      name = dto.name,
      address = dto.address,
      birtday = dto.birtday,
      photo = dto.photo
    };

    await _service.addOwner(owner);
    return StatusCode(StatusCodes.Status201Created, owner);
  }

}
