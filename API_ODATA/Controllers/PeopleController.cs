namespace API_ODATA.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using API_ODATA.Models;
    using Microsoft.AspNet.OData;
    using Microsoft.AspNet.OData.Routing;

    [EnableQuery]
    public class PeopleController : ODataController
    {
        private readonly ApiContext db = new ApiContext();

        public IHttpActionResult GetPeople()
        {
            return Ok(db.People.AsQueryable());
        }

        [ODataRoute("/AnotherData")]
        public IHttpActionResult GetPeopleWithOtherData()
        {
            return Ok(db.People.AsQueryable());
        }

        public IHttpActionResult Post([FromBody]People entity)
        {
            db.People.Add(entity);
            db.SaveChanges();

            return Created(entity);
        }

        public IHttpActionResult Put([FromODataUri]int key, [FromBody]People entity)
        {
            var person = db.People.FirstOrDefault(x => x.Id == key);

            if (person == null)
            {
                return NotFound();
            }

            person.Names = entity.Names;
            person.LastNames = entity.LastNames;
            person.Email = entity.Email;
            person.Age = entity.Age;

            db.Entry(person).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();

            return Ok();
        }

        public IHttpActionResult Delete([FromODataUri]int key)
        {
            var person = db.People.FirstOrDefault(x => x.Id == key);

            if (person == null)
            {
                return NotFound();
            }

            db.Entry(person).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}