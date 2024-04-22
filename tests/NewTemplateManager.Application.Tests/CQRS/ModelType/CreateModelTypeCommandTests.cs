using Microsoft.Extensions.Logging;
using NewTemplateManager.Application.CQRS.SampleModel.Commands;
using NewTemplateManager.Domain.Errors;
using NewTemplateManager.Domain.Interfaces;
using FluentAssertions;
using NSubstitute;
using LanguageExt;
using static LanguageExt.Prelude;
using NewTemplateManager.Contracts.RequestDTO.V1;


using AutoBogus;
using NewTemplateManager.Application.CQRS;

namespace NewTemplateManager.Application.Tests.CQRS.SampleModel
{
    public class CreateSampleModelCommandTests

    {
        private static readonly SampleModelCreateRequestDTO SampleModelCreateDTO = new(Guid.NewGuid(), "ML101");
        private static readonly SampleModelDeleteRequestDTO SampleModelDeleteRequestDTO = new(Guid.NewGuid());
        private static readonly CreateSampleModelCommand createSampleModelCommand = new(CreateSampleModelDTO: SampleModelCreateDTO);
        private static readonly DeleteSampleModelCommand deleteSampleModelCommand = new DeleteSampleModelCommand(DeleteSampleModelDTO: SampleModelDeleteRequestDTO);

        private CreateSampleModelCommandHandler createSampleModelCommandHandler;
        private DeleteSampleModelCommandHandler deleteSampleModelCommandHandler;
        private readonly IUnitOfWork _unitOfWorkMock;
        private readonly ISampleModelRepository _SampleModelRepositoryMock;
        //private readonly ILogger<CreateSampleModelCommandHandler> _loggerMock;
        private readonly ILogger<CreateSampleModelCommandHandler> _loggerMock;
        private readonly ILogger<DeleteSampleModelCommandHandler> _loggerMockD;
        public CreateSampleModelCommandTests()
        {
            _unitOfWorkMock = Substitute.For<IUnitOfWork>();
            _loggerMockD = Substitute.For<ILogger<DeleteSampleModelCommandHandler>>();
            _loggerMock = Substitute.For<ILogger<CreateSampleModelCommandHandler>>();
            _SampleModelRepositoryMock = Substitute.For<ISampleModelRepository>();
            createSampleModelCommandHandler = new CreateSampleModelCommandHandler(_unitOfWorkMock, _loggerMock, _SampleModelRepositoryMock);
        }

        [Fact]
        public async Task CreateSampleModelCommandHandler_ShouldReturnValidRight_WhenNewSampleModelIsAdded()
        {
            //Arrange
            // SampleModelCreateRequestDTO SampleModelCreateDTO = new(Guid.NewGuid(), "ML1011");
            // CreateSampleModelCommand createSampleModelCommand1 = new(CreateSampleModelDTO: SampleModelCreateDTO);
            //create a new model type
            //  var model = Domain.Entities.SampleModel.Create(SampleModelCreateDTO.SampleModelName, SampleModelCreateDTO.GuidId);
            _SampleModelRepositoryMock.AddAsync(Arg.Any<Domain.Entities.SampleModel>(), Arg.Any<CancellationToken>()).Returns(1);
            //Act
            var result = await createSampleModelCommandHandler.Handle(createSampleModelCommand, CancellationToken.None);
            //Assert

            result.IsRight.Should().BeTrue();
            result.Match(
                                        Right: r => r.Should().NotBe(Arg.Any<Guid>()),
                                         Left: l => l.Should().BeEquivalentTo(GeneralFailures.ProblemAddingEntityIntoDbContext("2a7c336a-163c-487d-88ca-c41cc129f118")));//INTERESTED ONLY IN LEFT SIDE

        }

        [Fact(Skip = "Look into this to avoid  avoid arg error")]
        public async Task DeleteSampleModelCommandHandler_ShouldReturnValidRight_WhenNewSampleModelIsAdded()
        {
            //Arrange

            var success = Right<GeneralFailure, int>(1).AsTask();
            // _unitOfWorkMock.SampleModelRepository.AddAsync(Arg.Any<Domain.Entities.SampleModel>(), Arg.Any<CancellationToken>()).Returns(success);
            _SampleModelRepositoryMock.DeleteByGuidAsync(Arg.Any<Guid>(), Arg.Any<CancellationToken>()).Returns(success);
            //return await _unitOfWork.SampleModelRepository.DeleteByGuidAsync(request.DeleteSampleModelDTO.guid, cancellationToken);

            //Act

            var result = await deleteSampleModelCommandHandler.Handle(deleteSampleModelCommand, CancellationToken.None);
            //Assert

            result.IsRight.Should().BeTrue();
            // result.Match(
            //                             Right: r => r.Should().Be(1),
            //                              Left: l => l.Should().BeEquivalentTo(GeneralFailures.ProblemAddingEntityIntoDbContext("2a7c336a-163c-487d-88ca-c41cc129f118")));//INTERESTED ONLY IN LEFT SIDE

        }
        // implement below for exception handling
        //public async Task CreateSampleModelCommandHandler_ShouldThrowAggregateException_WhenNewSampleModelIsAdded()
        //{
        //    //Arrange
        //    _unitOfWorkMock.SampleModelRepository.AddAsync(Arg.Any<Domain.Entities.SampleModel>(), Arg.Any<CancellationToken>()).Returns(1);
        //    //Act
        //    var result = await createSampleModelCommandHandler.Handle(createSampleModelCommand, CancellationToken.None);
        //    //Assert

        //    result.IsRight.Should().BeTrue();

        //}
        [Fact(Skip = "This should be tested with integration testion to avoid arg error")]
        public async Task CreateSampleModelCommandHandler_ShouldReturnFailure()
        {
            CreateSampleModelCommand createSampleModelCommand1 = new(CreateSampleModelDTO: SampleModelCreateDTO);
            //Arrange
            _SampleModelRepositoryMock.AddAsync(Arg.Any<Domain.Entities.SampleModel>(), Arg.Any<CancellationToken>()).Returns(GeneralFailures.ProblemAddingEntityIntoDbContext("2a7c336a-163c-487d-88ca-c41cc129f118"));
            //Act
            var result = await createSampleModelCommandHandler.Handle(createSampleModelCommand1, CancellationToken.None);
            //Assert
            result.IsLeft.Should().BeTrue();
            result.Match(
                         Right: r => r.Should().Be(Arg.Any<Guid>()),
                         Left: l => l.Should().BeEquivalentTo(GeneralFailures.ProblemAddingEntityIntoDbContext("2a7c336a-163c-487d-88ca-c41cc129f118")));//INTERESTED ONLY IN LEFT SIDE

        }


        // [Fact(Skip = "I have removed logging  from this handler so test will fail for now, but its a good sample for testing logging")]
        // public async Task LogInformationShoulBeCalledWhenmethodIsInvoked()
        // {
        //     //Arrange
        //     //  _unitOfWorkMock.SampleModelsRepository.AddAsync(Arg.Any<Domain.Entities.SampleModels>(), Arg.Any<CancellationToken>()).Returns(GeneralFailure.ProblemAddingEntityIntoDbContext);
        //     //Act
        //     var _ = await createSampleModelCommandHandler.Handle(createSampleModelCommand, CancellationToken.None);
        //     //Assert
        //     _loggerMock.Received(1).LogInformation(Arg.Any<string>());
        // }
        //[Fact]
        //public async Task CreateSampleModelCommandHandler_ShouldCall_AddAsyncOnce_WhenCreateSampleModelCommandhandleIsCalled()
        //{
        //    //Arrange

        //    //Act
        //    var _ = await createSampleModelCommandHandler.Handle(createSampleModelCommand, CancellationToken.None);
        //    //Assert
        //    await _unitOfWorkMock.Received(1).SampleModelRepository.AddAsync(Arg.Any<Domain.Entities.SampleModel>(), Arg.Any<CancellationToken>());

        //}
    }

}