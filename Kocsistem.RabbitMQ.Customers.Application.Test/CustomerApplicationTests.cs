using Kocsistem.RabbitMQ.Customers.Application.Models;
using Kocsistem.RabbitMQ.Customers.Application.Services;
using Kocsistem.RabbitMQ.Customers.Data.Contexts;
using Kocsistem.RabbitMQ.Customers.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Kocsistem.RabbitMQ.Customers.Application.Test
{
    public class CustomerApplicationTests
    {
        private readonly DbContextOptions<CustomerDbContext> _dbOptions;
        private readonly CustomerDbContext _dbContext;
        private Mock<CustomersRepository> _mockRepository;
        private Mock<CustomerService> _mockCustomerService;
        public CustomerApplicationTests()
        {
            _dbOptions = new DbContextOptionsBuilder<CustomerDbContext>()
                .UseInMemoryDatabase(databaseName: "costumer")
                .Options;
            using (_dbContext = new CustomerDbContext(_dbOptions))
            {
                _dbContext.CustomersTable.RemoveRange(_dbContext.CustomersTable);
                _dbContext.CustomersTable.AddRange(HelperForMock.GetMockDatas());
                _dbContext.SaveChanges();
            }
        }
        [Fact]
        public async Task Get_Customer_By_Id()
        {
            using (var _context = new CustomerDbContext(_dbOptions))
            {
                _mockRepository = new Mock<CustomersRepository>(_context);
                _mockCustomerService = new Mock<CustomerService>(_mockRepository.Object);
                var customer = await _mockCustomerService.Object.GetCustomerById(Guid.Parse("6449145e-d9a4-4309-8775-984933824bbc"));
                Assert.NotNull(customer);

            }
        }
        [Fact]
        public void Get_All_Customers()
        {
            using (var _context = new CustomerDbContext(_dbOptions))
            {
                _mockRepository = new Mock<CustomersRepository>(_context);
                _mockCustomerService = new Mock<CustomerService>(_mockRepository.Object);
                var customers = _mockCustomerService.Object.GetAllCustomers();
                Assert.Equal(2,customers.Count());

            }
        }
        [Fact]
        public async Task Add_Customer()
        {
            using (var _context = new CustomerDbContext(_dbOptions))
            {
                _mockRepository = new Mock<CustomersRepository>(_context);
                _mockCustomerService = new Mock<CustomerService>(_mockRepository.Object);
                CustomersTableModel model = new CustomersTableModel
                {
                    Email ="deneme@deneme.com",
                    FullName ="Deneme",
                    Id = Guid.NewGuid()
                };
                var isAdd = await _mockCustomerService.Object.AddCustomer(model);
                if (isAdd)
                {
                    var customers = _mockCustomerService.Object.GetAllCustomers();
                    var addedData = customers.FirstOrDefault(x => x.Email.Equals(model.Email));
                    Assert.Equal(model.Id, addedData.Id);
                }
                else
                {
                    Assert.True(false);
                }
            }
        }

        [Fact]
        public async Task Delete_Customer()
        {
            using (var _context = new CustomerDbContext(_dbOptions))
            {
                _mockRepository = new Mock<CustomersRepository>(_context);
                _mockCustomerService = new Mock<CustomerService>(_mockRepository.Object);
                
                var customer = _mockCustomerService.Object.GetAllCustomers().First();
                await _mockCustomerService.Object.DeleteCustomer(customer.Id);

                var isCustomerDeleted = !_mockCustomerService.Object.GetAllCustomers().Any(x=>x.Id == customer.Id);

                Assert.True(isCustomerDeleted);

            }
        }

        [Fact]
        public void Update_Customer()
        {
            using (var _context = new CustomerDbContext(_dbOptions))
            {
                _mockRepository = new Mock<CustomersRepository>(_context);
                _mockCustomerService = new Mock<CustomerService>(_mockRepository.Object);

                var customer = _mockCustomerService.Object.GetAllCustomers().First();
                var model = new CustomersTableModel
                {
                    Id = customer.Id,
                    Email = "updated@updated.com",
                    FullName = customer.FullName
                };
                Assert.True(_mockCustomerService.Object.UpdateCustomer(model));
            }
        }
    }
}
