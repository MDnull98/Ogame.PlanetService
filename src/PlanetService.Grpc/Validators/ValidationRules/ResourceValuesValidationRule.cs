using FluentValidation;
using Google.Protobuf.Collections;

namespace PlanetService.Grpc.Validators.ValidationRules
{
    /// <summary>
    /// Validation rule for resource value list
    /// </summary>
    public static class ResourceValuesValidationRule
    {
        /// <summary>
        /// Must the be valid resource values.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ruleBuilder">The rule builder.</param>
        /// <returns></returns>
        public static IRuleBuilderOptions<T, RepeatedField<ResourceValue>> MustBeValidResourceValues<T>(this IRuleBuilder<T, RepeatedField<ResourceValue>> ruleBuilder)
        {
            var builderOptions = ruleBuilder
                .NotNull()
                .NotEmpty()
                .Must(e => e.All(x => x.ResourceType != ResourceType.Unspecified))
                .WithMessage("Received resource type is unsupported")
                .Must(e => e.All(x => x.Value >= 0))
                .WithMessage("Received invalid resource value");

            return builderOptions;
        }
    }
}
