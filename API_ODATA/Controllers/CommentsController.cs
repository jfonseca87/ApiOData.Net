namespace API_ODATA.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.OData;

    [EnableQuery]
    public class CommentsController : ODataController
    {
        public IHttpActionResult GetComments()
        {
            return Ok();
        }
    }
}