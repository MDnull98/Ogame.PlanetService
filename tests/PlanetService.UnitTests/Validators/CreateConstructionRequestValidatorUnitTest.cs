using FluentAssertions;
using FluentValidation;
using PlanetService.Grpc;
using PlanetService.Grpc.Validators;

namespace PlanetService.UnitTests.Validators
{
    public class CreateConstructionRequestValidatorUnitTest
    {
        private readonly IValidator<CreateConstructionRequest> _validator;

        public CreateConstructionRequestValidatorUnitTest()
        {
            _validator = new CreateConstructionRequestValidator();
        }

        [Fact]
        public async Task CreateConstructionRequestValidator_Should_SucceedValidation()
        {
            //Arrange
            var model = new CreateConstructionRequest
            {
                ConstructionType = Construction.Types.ConstructionType.AllianceWarehouseFactory,
                PlanetId = Guid.NewGuid().ToString()
            };

            //Act
            var result = await _validator.ValidateAsync(model);

            //Assert
            result.IsValid
                .Should()
                .Be(true);
        }

        [Fact]
        public async Task CreateConstructionRequestValidator_Should_CreateErrorDueToInvalidPlanetId()
        {
            //Arrange
            var model = new CreateConstructionRequest
            {
                ConstructionType = Construction.Types.ConstructionType.AllianceWarehouseFactory,
                PlanetId = "InvalidGuid"
            };

            //Act
            var result = await _validator.ValidateAsync(model);

            //Assert
            result.IsValid
                .Should()
                .Be(false);
        }

        [Fact]
        public async Task CreateConstructionRequestValidator_Should_CreateErrorDueToInvalidConstructionType()
        {
            //Arrange
            var model = new CreateConstructionRequest
            {
                ConstructionType = Construction.Types.ConstructionType.Unspecified,
                PlanetId = Guid.NewGuid().ToString()
            };

            //Act
            var result = await _validator.ValidateAsync(model);

            //Assert
            result.IsValid
                .Should()
                .Be(false);
        }
    }
}
