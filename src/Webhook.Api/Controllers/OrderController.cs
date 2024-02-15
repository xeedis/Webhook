using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Webhook.Application.Commands;
using Webhook.Application.Commands.CreatePaymentLink;
using Webhook.Application.DTO;
using Webhook.Infrastructure;

namespace Webhook.Api.Controllers;

[ApiController]
[Route("orders")]
public class OrderController : ControllerBase
{
    private readonly ISender _mediatR;
    public OrderController(ISender mediatR)
    {
        _mediatR = mediatR;
    }
    [HttpPost]
    public async Task<ActionResult> CreateOrder(CreatePaymentLinkCommand command)
    {
        var response = await _mediatR.Send(command);
        if (string.IsNullOrEmpty(response))
        {
            return BadRequest();
        }

        return Ok(response);
    }
}