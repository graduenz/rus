using Advertiser.Application;
using Advertiser.Application.Advertiser;
using Advertiser.Infrastructure;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Rus.Base.Api;

namespace Rus.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AdvertisersController : BaseCrudController<AdvertiserDto, Advertiser.Domain.Advertiser,
    CreateAdvertiserCommand, UpdateAdvertiserCommand, DeleteAdvertiserCommand, GetAdvertiserByIdQuery,
    GetAdvertiserListQuery, AdvertiserSearch>
{
    public AdvertisersController(IMediator mediator, IValidator<AdvertiserDto> validator) : base(mediator, validator)
    {
    }

    [HttpGet("{id:guid}")]
    public Task<IActionResult> GetByIdAsync([FromRoute] Guid id) =>
        GetByIdInternalAsync(id);

    [HttpGet]
    public virtual Task<IActionResult> GetPaginatedListAsync([FromQuery] AdvertiserSearch request) =>
        GetPaginatedListInternalAsync(request);

    [HttpPost]
    public virtual Task<IActionResult> PostAsync([FromBody] AdvertiserDto model) =>
        PostInternalAsync(model);

    [HttpPut("{id:guid}")]
    public virtual Task<IActionResult> PutAsync([FromRoute] Guid id,
        [FromBody] AdvertiserDto model) =>
        PutInternalAsync(id, model);

    [HttpDelete("{id:guid}")]
    public virtual Task<IActionResult> DeleteAsync([FromRoute] Guid id) =>
        DeleteInternalAsync(id);
}