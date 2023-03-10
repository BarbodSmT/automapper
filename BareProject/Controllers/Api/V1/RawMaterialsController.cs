using AutoMapper;
using BareProject.Models;
using BareProject.Models.DTO;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Services;
using WebFramework.Api;
using WebFramwork.Api;

namespace BareProject.Controllers.Api.V1;

[ApiVersion("1.0")]
public class RawMaterialsController : BaseController
{
    private readonly IBusinessLogic _iLogic;
    private readonly IMapper _mapper;
    public RawMaterialsController(IBusinessLogic logic, IMapper map)
    {
        _iLogic = logic;
        _mapper = map;
    }
    
    [HttpGet]
    public async Task<ActionResult<ICollection<RawMaterial>>> GetRawMaterials()
    {
        var items = await _iLogic.BGetRawMaterials();
        if (!items.Any())
            return BadRequest("مواد اولیه ای وجود ندارد.");
        return Ok(items);
    }
    [HttpGet]
    public async Task<ActionResult<RawMaterial>> GetRawMaterial(int id, CancellationToken cn)
    {
        return await _iLogic.BGetRawMaterial(id, cn) == null ? BadRequest("مواد اولیه یافت نشد!") : await _iLogic.BGetRawMaterial(id, cn);
    }

    [HttpPost]
    public async Task<IActionResult> CreateRawMaterial(RawMaterialModel input, CancellationToken cn)
    {
        if (!ModelState.IsValid) return BadRequest();
        var rEntity = _mapper.Map<RawMaterial>(input);
        await _iLogic.BCreateRawMaterial(rEntity, cn);
        return Ok("مواد اولیه با موفقیت اضافه شد.");
    }

    [HttpPut]
    public async Task<IActionResult> UpdateRawMaterial(int id, RawMaterialModel input, CancellationToken cn)
    {
        if (!ModelState.IsValid) return BadRequest();
        var rawentity = await _iLogic.BGetRawMaterial(id, cn);
        if (rawentity == null) return BadRequest("آیدی مواد اولیه اشتباه است.");
        rawentity = _mapper.Map<RawMaterial>(input);
        await _iLogic.BUpdateRawMaterial(rawentity, cn);
        return Ok("عملیات با موفقیت انجام شد.");
    }

    [HttpDelete]
    public async Task<IActionResult> DeleteRawMaterial(int id, CancellationToken cn)
    {
        return await _iLogic.BDeleteRawMaterial(id, cn) == true ? Ok("مواد اولیه با موفقت حذف شد.") : BadRequest("مواد اولیه یافت نشد.");
    }
}