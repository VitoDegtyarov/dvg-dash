using Serilog;

namespace dvg.Tests
{
    public class DesignerServicesTests
    {
        private readonly ILogger _logger;
        private readonly IMapper _mapper;
        private readonly DesignerServices _designerService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public DesignerServicesTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppMappingProfile>();
            });

            _logger = new LoggerConfiguration()
                .CreateLogger();

            _mapper = mapperConfig.CreateMapper();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _designerService = new DesignerServices(_unitOfWorkMock.Object, _mapper, _logger);

        }

        [Fact]
        public async Task GetAllDesigner()
        {
            _unitOfWorkMock.Setup(repo => repo.DesignerRepository.GetAllAsync())
                                    .ReturnsAsync(new List<Designer>()
                                    {
                                        new Designer { FirstName = "John", LastName = "Silverhand"},
                                        new Designer { FirstName = "Boby", LastName = "Sinclar"}
                                    });

            List<DesignerDto> result = await _designerService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].FirstName);
        }

        [Fact]
        public async Task GetDesignerByID()
        {
            Designer testData = new Designer
            {
                FirstName = "Alice",
                LastName = "Kotik",
                Id = new Guid()
            };

            _unitOfWorkMock.Setup(repo => repo.DesignerRepository.GetByIdAsync(testData.Id))
                                    .ReturnsAsync(testData);

            var result = await _designerService.GetByIdAsync(testData.Id);

            Assert.Equal(testData.FirstName, result.FirstName);
        }

        [Fact]
        public async Task GetDesignerByID_WithNullValue()
        {
            Guid id = Guid.Empty;

            _unitOfWorkMock.Setup(repo => repo.DesignerRepository.GetByIdAsync(id))
                                    .ReturnsAsync((Designer?)null);

            var result = await _designerService.GetByIdAsync(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task InsertAsync()
        {
            _unitOfWorkMock.Setup(uow => uow.DesignerRepository.InsertAsync(It.IsAny<Designer>()))
                                    .Returns(Task.CompletedTask);

            var designerDTO = new DesignerDto
            {
                FirstName = "Kevin",
                LastName = "McCallister",
                Position = Core.Enums.DesignerPosition.Trainee,
                PhoneNumber = "+380987894512"
            };

            await _designerService.InsertAsync(designerDTO);

            _unitOfWorkMock.Verify(uow => uow.DesignerRepository.InsertAsync(It.IsAny<Designer>()), Times.Once);

        }

        [Fact]
        public async Task InsertAsync_WithNullValue()
        {
            DesignerDto? designerDTO = null;

            _unitOfWorkMock.Setup(uow => uow.DesignerRepository.InsertAsync(It.IsNotNull<Designer>()))
                                   .Throws<InvalidOperationException>();

            await _designerService.InsertAsync(designerDTO);

            _unitOfWorkMock.Verify(uow => uow.DesignerRepository.InsertAsync(It.IsNotNull<Designer>()), Times.Never());
        }

        [Fact]
        public async Task DeleteDesignerAsync()
        {
            var designerDTO = new DesignerDto { FirstName = "John", LastName = "Doe" };

            _unitOfWorkMock.SetupGet(uow => uow.DesignerRepository).Returns(Mock.Of<IDesignerRepository>());

            await _designerService.DeleteDesignerAsync(designerDTO);

            _unitOfWorkMock.Verify(uow => uow.DesignerRepository.Delete(It.IsAny<Designer>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(), Times.Once);
        }

    }

}