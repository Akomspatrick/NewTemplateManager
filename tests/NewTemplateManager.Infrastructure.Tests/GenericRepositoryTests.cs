namespace NewTemplateManager.Infrastructure.Tests.Persistence
{
    public class GenericRepositoryTests
    {
        [Fact]
        public async Task AddAsync_ShouldReturnSuccess_WhenEntityAddedSuccessfully()
        {


            //var _configuration = Substitute.For<IConfiguration>();
            //var options = new DbContextOptionsBuilder<NewTemplateManagerContext>()
            //    .UseInMemoryDatabase(databaseName: "AddAsync_ShouldReturnSuccess_WhenEntityAddedSuccessfully")
            //    .Options;
            //var mockedDbContext = new NewTemplateManagerContext(options, _configuration);
            //var entity = Domain.Entities.TestingModeGroup.Create("", "", "", Guid.NewGuid());
            //var cancellationToken = CancellationToken.None;


            //mockedDbContext.AddAsync(Arg.Any<BaseEntity>(), Arg.Any<CancellationToken>())
            //.Returns(callInfo => mockedDbContext.AddAsync(callInfo.Arg<BaseEntity>(), callInfo.Arg<CancellationToken>()));
            //mockedDbContext.SaveChangesAsync(cancellationToken).Returns(1);
            //// Arrange

            //// var ctx = Substitute.For<NewTemplateManagerContext>();
            //// var mockedDbContext = Create.MockedDbContextFor<NewTemplateManagerContext>();
            //var unitt = new UnitOfWork(mockedDbContext);
            //// unitt._testingModeGroupRepository = new TestingModeGroupRepository(mockedDbContext);
            //var result2 = await unitt.TestingModeGroupRepository.AddAsync(entity, cancellationToken);
            //var repository = new GenericRepository<Domain.Entities.TestingModeGroup>(mockedDbContext);
            //// unitt._testingModeGroupRepository.Returns(repository);
            //var repository = Substitute.For<IGenericRepository<Domain.Entities.TestingModeGroup>>(mockedDbContext);


            // Act
            // var result = await repository.(entity, cancellationToken);

            // Assert
            //Assert.True(result.IsRight);

        }

        //[Fact]
        //public async Task AddAsync_ShouldReturnFailure_WhenDbUpdateExceptionOccurs()
        //{
        //    // Arrange
        //    var entity = new BaseEntity();
        //    var cancellationToken = CancellationToken.None;
        //    var ctx = Substitute.For<NewTemplateManagerContext>();
        //    var repository = new GenericRepository<BaseEntity>(ctx);

        //    ctx.AddAsync(entity, cancellationToken).Returns(Task.CompletedTask);
        //    ctx.SaveChangesAsync(cancellationToken).Throws(new DbUpdateException());

        //    // Act
        //    var result = await repository.AddAsync(entity, cancellationToken);

        //    // Assert
        //    Assert.True(result.IsLeft);
        //    Assert.Equal("GenericRepository-AddAsync", result.Left.FailureCode);
        //    Assert.Equal("Problem Adding Entity with Guid" + entity.GuidId, result.Left.FailureMessage);
        //}

        //[Fact]
        //public async Task AddAsync_ShouldReturnFailure_WhenExceptionOccurs()
        //{
        //    // Arrange
        //    var entity = new BaseEntity();
        //    var cancellationToken = CancellationToken.None;
        //    var ctx = Substitute.For<NewTemplateManagerContext>();
        //    var repository = new GenericRepository<BaseEntity>(ctx);

        //    ctx.AddAsync(entity, cancellationToken).Returns(Task.CompletedTask);
        //    ctx.SaveChangesAsync(cancellationToken).Throws(new Exception());

        //    // Act
        //    var result = await repository.AddAsync(entity, cancellationToken);

        //    // Assert
        //    Assert.True(result.IsLeft);
        //    Assert.Equal("ProblemAddingEntityIntoDbContext", result.Left.FailureCode);
        //    Assert.Equal(entity.GuidId.ToString(), result.Left.FailureMessage);
        //}
    }
}
