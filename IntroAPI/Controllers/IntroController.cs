using IntroAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace IntroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IntroController : ControllerBase
    {
        List<Person> persons = new List<Person>();
        public IntroController()
        {
            persons.Add(new Person()
            {
                Id = 1,
                Name = "Sigurd Bjørnetime",
                Address = "Ramasjang 9210",
                Phone = "12345678",
                City = "Findlandz"
            });
            persons.Add(new Person()
            {
                Id = 2,
                Name = "Anders And",
                Address = "Andevej 1, 4121",
                Phone = "87654321",
                City = "Andeby"
            });
            persons.Add(new Person()
            {
                Id = 3,
                Name = "Peter Parker",
                Address = "New York City Road?",
                Phone = "CALLSPIDER-800",
                City = "New York City"
            });
            persons.Add(new Person()
            {
                Id = 4,
                Name = "Doc Ock",
                Address = "Sewers",
                Phone = "DOCOCISBEST-1221",
                City = "New York City Sewers"
            });
        }

        [HttpGet]
        public ActionResult<Person> Get()
        {
            Person person = new Person();
            person.Id = 1;
            person.Name = "Sigurd Bjørnetime";
            person.Address = "Ramasjang 9210";
            person.Phone = "+45 505 44 32";
            person.City = "Findland";
            return Ok(person);
        }

        [HttpGet]
        [Route("GetAll")]
        public ActionResult<List<Person>> GetAll()
        {
            return Ok(persons);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Person> Get(int id)
        {
            var person = persons.SingleOrDefault(p => p.Id == id);
            return Ok(person);
        }

        [HttpPost]
        public ActionResult<string> Post(Person person)
        {
            //Person anders = new Person();
            //anders.Name = "Anders Andersen";

            //Person peter = new Person();
            //peter.Name = "Peter Petersen";
            return Ok("Person Added");
        }
    }
}
