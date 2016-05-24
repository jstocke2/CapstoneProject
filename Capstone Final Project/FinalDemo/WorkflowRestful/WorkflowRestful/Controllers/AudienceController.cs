//Controller for the Audience model
//Only has a post method to create new audience
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using workflowRestful.Models;

namespace WorkflowRestful.Models
{
    [RoutePrefix("api/audience")]
    // allows generation of a unique audience id if front-end hits endpoint
    public class AudienceController : ApiController
    {
        //Post method to create new audience members
        //Route: api/audience
        [Route("")]
        public IHttpActionResult Post(AudienceModel audienceModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Audience newAudience = AudiencesStore.AddAudience(audienceModel.Name);

            return Ok<Audience>(newAudience);

        }
    }
}
