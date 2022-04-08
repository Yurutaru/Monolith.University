using Autofac.Features.Indexed;
using Monolith.University.Core.Contracts.Dto.People;
using Monolith.University.Core.Mappers.Interfaces;
using Monolith.University.Core.Services.Interfaces;
using Monolith.University.Core.Specifications.People;
using Monolith.University.Domain.Entities;
using Monolith.University.Domain.Enums;
using Monolith.University.Domain.Interfaces;

namespace Monolith.University.Core.Services
{
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> personRepository;
        private readonly IIndex<PersonDiscriminator, IPersonMapper> personMappers;

        public PersonService(IRepository<Person> personRepository, 
            IIndex<PersonDiscriminator, IPersonMapper> personMappers)
        {
            this.personRepository = personRepository;
            this.personMappers = personMappers;
        }
        public async Task<IEnumerable<PersonResponse>> GetAll(int skip = 0, int take = 100)
        {
            var specification = new PeopleSpecification();
            var people = await personRepository.List(specification, skip, take);
            
            var result = people.Select(t => personMappers[t.Discriminator].Map(t)).ToList();
            return result;
        }
    }
}
