using FluentValidation;
using PlanetService.Grpc.Validators.ValidationRules;

namespace PlanetService.Grpc.Validators
{
    /// <summary>Validator for CheckPlanetOwnerRequest</summary>
    public class CheckPlanetOwnerRequestValidator : AbstractValidator<CheckPlanetOwnerRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CheckPlanetOwnerRequestValidator"/> class.
        /// </summary>
        public CheckPlanetOwnerRequestValidator()
        {
            RuleFor(x => x.PlanetId)
                .MustBeValidGuid();
            RuleFor(x => x.UserId)
                .MustBeValidGuid();
        }
    }
}
