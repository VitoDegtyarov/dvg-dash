namespace dvg.Tests
{
    public class DesignerServicesTests
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        private readonly IMapper _mapper;
        private readonly DesignerServices _designerService;

        public DesignerServicesTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppMappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _designerService = new DesignerServices(_unitOfWorkMock.Object, _mapper);
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

            List<DesignerDTO> result = await _designerService.GetAllAsync();

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
                                    .ReturnsAsync((Designer)null);

            var result = await _designerService.GetByIdAsync(id);

            Assert.Null(result);
        }

        [Fact]
        public async Task InsertAsync()
        {
            _unitOfWorkMock.Setup(uow => uow.DesignerRepository.InsertAsync(It.IsAny<Designer>()))
                                    .Returns(Task.CompletedTask);

            var designerDTO = new DesignerDTO
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
            DesignerDTO designerDTO = null;

            _unitOfWorkMock.Setup(uow => uow.DesignerRepository.InsertAsync(It.IsNotNull<Designer>()))
                                   .Throws<InvalidOperationException>();

            await _designerService.InsertAsync(designerDTO);

            _unitOfWorkMock.Verify(uow => uow.DesignerRepository.InsertAsync(It.IsNotNull<Designer>()), Times.Never());
        }
    }
}