using System;
using System.Web;
using System.Web.Http;
using System.Web.OData;
using ReadLibrary;

namespace WebApiWithODataRead.Controllers
{
    public class TaskController : ODataController
    {
        private readonly TaskManager _db = new TaskManager();

        [EnableQuery]
        public IHttpActionResult Get()
        {
            throw new NotImplementedException();
        }

        [EnableQuery]
        public IHttpActionResult Get(int key)
        {
            throw new NotImplementedException();
        }
    }
}
