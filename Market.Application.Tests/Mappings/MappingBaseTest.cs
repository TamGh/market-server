using AutoMapper;
using Market.Applictaion.Mappings;
using NUnit.Framework;

namespace Market.Application.Tests.Mappings
{
    public class MappingBaseTest
    {
        protected IConfigurationProvider _configuration;
        protected IMapper _mapper;

        [SetUp]
        public void SetUp()
        {
            _configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ProductProfile>();
               
            });

            _mapper = _configuration.CreateMapper();
        }

        [Test]
        public void ShouldHaveValidConfiguration()
        {
            _configuration.AssertConfigurationIsValid();
        }
    }
}
