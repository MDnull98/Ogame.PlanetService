using FluentValidation;
using PlanetService.Grpc.Validators.ValidationRules;

namespace PlanetService.Grpc.Validators
{
    /// <summary>Validator for CreateConstructionRequest</summary>
    public class CreateEventBidRequestValidator : AbstractValidator<CreateEventBidRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateEventBidRequestValidator"/> class.
        /// </summary>
        public CreateEventBidRequestValidator()
        {
            RuleFor(x => x.AuctionEventId)
                .MustBeValidGuid();
            RuleFor(x => x.UserId)
                .MustBeValidGuid();
            RuleFor(x => x.PlanetId)
                .MustBeValidGuid();
            RuleFor(x => x.ResourceUsages)
                .MustBeValidResourceValues();
        }
    }
}
