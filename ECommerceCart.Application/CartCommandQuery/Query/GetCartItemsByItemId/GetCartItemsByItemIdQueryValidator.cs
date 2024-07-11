using FluentValidation;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByItemId;

public class GetCartItemsByPhoneNumberQueryValidator : AbstractValidator<GetCartItemsByItemIdQuery>
{
    public GetCartItemsByPhoneNumberQueryValidator()
    {
        RuleFor(x => x.itemId).NotEmpty();
    }
}
