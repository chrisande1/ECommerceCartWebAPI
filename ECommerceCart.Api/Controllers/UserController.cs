using ECommerceCart.Application.UserCommandQuery.Command.Delete;
using ECommerceCart.Application.UserCommandQuery.Command.Register;
using ECommerceCart.Application.UserCommandQuery.Common;
using ECommerceCart.Application.UserCommandQuery.Query.GetAll;
using ECommerceCart.Application.UserCommandQuery.Query.GetById;
using ECommerceCart.Contracts.DTOs.UserDTO.Request;
using ECommerceCart.Contracts.DTOs.UserDTO.Response;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ECommerceCart.Api.Controllers;

[Route("user")]

public class UserController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public UserController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserRegisterDTO request)
    {
        var command = _mapper.Map<RegisterUserCommand>(request);
        ErrorOr<UserResult> userResult = await _mediator.Send(command);

        return userResult.Match(
            userResult => Ok(_mapper.Map<UserResponseDTO>(userResult)),
            errors => Problem(errors));

    }

    [HttpGet("users")]
    public async Task<IActionResult> GetAllUsers()
    {
        var query = new GetAllUsersQuery();
        ErrorOr<IEnumerable<UserResult>> result = await _mediator.Send(query);

        return result.Match(
            users =>
            {
                if (!users.Any())
                {
                    return Ok(new List<UserResponseDTO>());
                }
                return Ok(_mapper.Map<IEnumerable<UserResponseDTO>>(users));
            },
            errors => Problem(errors));
    
            
    }

    [HttpGet("users/{userId}")]
    public async Task<IActionResult> GetUserById(Guid userId)
    {
        var query = new GetUserByIdQuery(userId);
        ErrorOr<UserResult> result  = await _mediator.Send(query);

        return result.Match(
            userResult => Ok(_mapper.Map<UserResponseDTO>(userResult)),
            errors => Problem(errors));
    }




    [HttpDelete("users/{userId}")]
    public async Task<IActionResult> DeleteUser(Guid userId)
    {
        var command = new DeleteUserCommand(userId);
        ErrorOr<bool> result = await _mediator.Send(command);

        return result.Match(
            userResult => NoContent(),
            errors => Problem(errors));
        
    }
}