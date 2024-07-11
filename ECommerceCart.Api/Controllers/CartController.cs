using ECommerceCart.Application.CartCommandQuery.Command.AddToCart;
using ECommerceCart.Application.CartCommandQuery.Command.CreateCart;
using ECommerceCart.Application.CartCommandQuery.Command.Delete;
using ECommerceCart.Application.CartCommandQuery.Common;
using ECommerceCart.Application.CartCommandQuery.Query.GetAllCartItems;
using ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByFilters;
using ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByItemId;
using ECommerceCart.Contracts.DTOs.CartTO;
using ECommerceCart.Contracts.DTOs.CartTO.Response;
using ErrorOr;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace ECommerceCart.Api.Controllers;

[Route("cart")]

public class CartController : ApiController
{
    private readonly ISender _mediator;
    private readonly IMapper _mapper;

    public CartController(ISender mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost("CreateNewCartItem")]
    public async Task<IActionResult> CreateNewCartItem(CreateCartRequestDTO request)
    {
        var command = _mapper.Map<CreateCartCommand>(request);
        ErrorOr<CartResult> cartItemResult = await _mediator.Send(command);

        return cartItemResult.Match(
            cartItemResult => Ok(_mapper.Map<CartResponseDTO>(cartItemResult)),
            errors => Problem(errors));
    }

    [HttpPost("AddToExistingCartItem")]
    public async Task<IActionResult> AddToExistingCartItem(AddToCartRequestDTO request)
    {
        var command = _mapper.Map<AddToCartCommand>(request);
        ErrorOr<CartResult> cartItemResult = await _mediator.Send(command);

        return cartItemResult.Match(
            cartItemResult => Ok(_mapper.Map<CartResponseDTO>(cartItemResult)),
            errors => Problem(errors));
    }

    [HttpGet("cartItems")]
    public async Task<IActionResult> GetAllCartItems()
    {
        var query = new GetAllCartItemsQuery();
        ErrorOr<IEnumerable<CartResult>> allCartItemsResult = await _mediator.Send(query);

        return allCartItemsResult.Match(
            allCartItems =>
            {
                if (!allCartItems.Any())
                {
                    return Ok(new List<CartResponseDTO>());
                }
                return Ok(_mapper.Map<IEnumerable<CartResponseDTO>>(allCartItems));
            },
            errors => Problem(errors));
    }

    [HttpGet("cartItems/filter")]
    public async Task<IActionResult> GetCartItemsFilters(
        [FromQuery] string phoneNumber,
        [FromQuery] DateTime startTime,
        [FromQuery] DateTime endTime,
        [FromQuery] int minQuantity,
        [FromQuery] Guid itemId)
    {
        var query = new GetCartItemsByFiltersQuery(phoneNumber, startTime, endTime, minQuantity, itemId);
        ErrorOr<IEnumerable<CartResult>> result =  await _mediator.Send(query);

        return result.Match(
            result =>
            {
                if (!result.Any())
                {
                    return Ok(new List<CartResponseDTO>());
                }
                return Ok(_mapper.Map<IEnumerable<CartResponseDTO>>(result));
            },
            errors => Problem(errors));
    }

    [HttpGet("cartItems/{itemId}")]
    public async Task<IActionResult> GetCartItemsByPhoneNumber(Guid itemId)
    {
        var query = new GetCartItemsByItemIdQuery(itemId);
        ErrorOr<CartResult> result =  await _mediator.Send(query);

        return result.Match(
            result => Ok(_mapper.Map<CartResponseDTO>(result)),
            errors => Problem(errors)); 
    }
    
    

    [HttpDelete("cartItem/{cartItemId}")]
    public async Task<IActionResult> DeleteCartItem(Guid cartItemId)
    {
        var query = new DeleteCartItemCommand(cartItemId);
        ErrorOr<bool> cartItemResult = await _mediator.Send(query);

        return cartItemResult.Match(
            cartItemResult => NoContent(),
            errors => Problem(errors));
    }

}