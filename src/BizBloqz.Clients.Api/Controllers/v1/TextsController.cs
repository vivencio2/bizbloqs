using BizBloqz.Application.Text.Commands;
using BizBloqz.Application.Text.Models;
using BizBloqz.Application.Text.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BizBloqz.Clients.Api.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class TextsController : BaseController
    {
        [HttpGet]
        [ProducesResponseType(typeof(TextResponseModel), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public async Task<TextResponseModel> GetEverySecondRowTextsVowelCount()
        {
            return await Mediator.Send(new GetTextResponseModelQuery());
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Exception), StatusCodes.Status400BadRequest)]
        public async Task<bool> CreateTexts([FromBody]TextValue textValue)
        {
            return await Mediator.Send(new CreateTextCommand(textValue.Value));
        }
    }

    public class TextValue
    {
        public string Value { get; set; }
    }
}
