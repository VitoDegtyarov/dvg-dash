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
        public async void GetAllDesigner()
        {
            _unitOfWorkMock.Setup(repo => repo.DesignerRepository.GetAllAsync())
                                    .ReturnsAsync(new List<Designer>()
                                    {
                                        new Designer { FirstName = "John", LastName = "Silverhand"},
                                        new Designer { FirstName = "Boby", LastName = "Sinclar"}
                                    });

            //Act
            List<DesignerDTO> result = await _designerService.GetAllAsync();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count);
            Assert.Equal("John", result[0].FirstName);
        }

        [Fact]
        public async Task InsertAsync_DesignerDTO()
        {
            var designerDTO = new DesignerDTO { 
                FirstName = "Kevin", 
                LastName = "McCallister" , 
                Position = Core.Enums.DesignerPosition.Trainee, 
                PhoneNumber = "+380987894512"
            };

            //Act
             await _designerService.InsertAsync(designerDTO);

            //Assert
            Assert.NotNull(designerDTO);
        }
    }
}