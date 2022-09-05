using FluentValidation;
using PlanetService.Grpc.Validators.ValidationRules;
using static PlanetService.Grpc.Construction.Types;

namespace PlanetService.Grpc.Validators
{
    /// <summary>Validator for CreateConstructionRequest</summary>
    public class CreateConstructionRequestValidator : AbstractValidator<CreateConstructionRequest>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateConstructionRequestValidator"/> class.
        /// </summary>
        public CreateConstructionRequestValidator()
        {
            RuleFor(x => x.PlanetId)
                .MustBeValidGuid();
            RuleFor(x => x.ConstructionType)
                .NotEmpty()
                .Must(x => x != ConstructionType.Unspecified);
        }
    }
}
