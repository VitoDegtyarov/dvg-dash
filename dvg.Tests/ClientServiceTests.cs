using Serilog;

namespace dvg.Tests
{
    public class ClientServiceTests
    {
        private readonly ClientService _clientService;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;

        public ClientServiceTests()
        {
            var mapperConfig = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AppMappingProfile>();
            });

            ILogger logger = new LoggerConfiguration()
                .CreateLogger();

            var mapper = mapperConfig.CreateMapper();

            _unitOfWorkMock = new Mock<IUnitOfWork>();

            _clientService = new ClientService(_unitOfWorkMock.Object, mapper, logger);
        }

        [Fact]
        public async Task GetAllClientAsync()
        {
            _unitOfWorkMock.Setup(repo => repo.ClientRepository.GetAllAsync())
                                    .ReturnsAsync(new List<Client>()
                                    {
                                        new Client { FirstName = "Victor" , LastName = "Dino" },
                                        new Client { FirstName = "Eric", LastName = "Volcanically"}
                                    });

            var result = await _clientService.GetAllAsync();

            Assert.Equal("Eric", result[1].FirstName);
        }

        [Fact]
        public async Task DeleteClient()
        {
            var client = new ClientDto { FirstName = "Adam", LastName = "Smasher" };

            _unitOfWorkMock.SetupGet(data => data.ClientRepository).Returns(Mock.Of<IClientRepository>());

            await _clientService.DeleteClientAsync(client);

            _unitOfWorkMock.Verify(data => data.ClientRepository.Delete(It.IsAny<Client>()), Times.Once);
            _unitOfWorkMock.Verify(uow => uow.SaveChanges(), Times.Once);

        }
    }
}
