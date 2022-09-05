using FluentValidation;
using PlanetService.Grpc.Validators.ValidationRules;

namespace PlanetService.Grpc.Validators
{
    /// <summary>Validator for GetConstructionsRequest</summary>
    public class GetConstructionRequestValidator : AbstractValidator<GetConstructionsRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetConstructionRequestValidator"/> class.
        /// </summary>
        public GetConstructionRequestValidator()
        {
            RuleFor(e => e.PlanetId)
                .MustBeValidGuid();
        }
    }
}
