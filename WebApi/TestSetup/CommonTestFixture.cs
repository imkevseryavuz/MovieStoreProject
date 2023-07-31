using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MovieStore.Common;
using MovieStoreFinal.DbOperations;
using WebApi.TestSetup;
using WebApi.UnitTests.TestSetup;

namespace WebApi.UnitTests.TestsSetup
{
    public class CommonTestFixture
    {
       
            public MovieStoreDbContext Context { get; set; }
            public IMapper Mapper { get; set; }
            public CommonTestFixture()
            {
                var options = new DbContextOptionsBuilder<MovieStoreDbContext>().UseInMemoryDatabase(databaseName: "MovieStoreTestDB").Options;
                Context = new MovieStoreDbContext(options);

                Context.Database.EnsureCreated();
                Context.AddDirectors();
                Context.AddCustomers();
                Context.SaveChanges();

                Mapper = new MapperConfiguration(cfg => { cfg.AddProfile<MappingProfile>(); }).CreateMapper();

        }
    }
}
