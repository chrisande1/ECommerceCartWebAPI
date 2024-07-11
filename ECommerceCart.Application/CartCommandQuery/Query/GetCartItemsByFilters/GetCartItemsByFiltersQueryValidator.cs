using FluentValidation;

namespace ECommerceCart.Application.CartCommandQuery.Query.GetCartItemsByFilters;

public class GetCartItemsByFiltersQueryValidator : AbstractValidator<GetCartItemsByFiltersQuery>
{
    public GetCartItemsByFiltersQueryValidator()
    {
        RuleFor(x => x.phoneNumber).NotEmpty();
        RuleFor(x => x.startTime).NotEmpty();
        RuleFor(x => x.endTime).NotEmpty();
        RuleFor(x => x.minQuantity).NotEmpty();
        RuleFor(x => x.itemId).NotEmpty();
    }
}
