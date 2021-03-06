﻿using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using Nexchar.Documents;
using NexChar.Services;
using NexCharCore;

namespace NexChar.APIControllers
{
    public class SkillsController : ApiController
    {
                private readonly SkillService _fullService;

                public SkillsController(IContextManager contextManager)
        {
            _fullService = new SkillService(contextManager);
        }

        public IEnumerable<SkillDocument> GetFilteredList()
        {
            return _fullService.GetFiltered((IReadOnlyCollection<KeyValuePair<string, string>>)Request.GetQueryNameValuePairs());
        }

        public IHttpActionResult GetById(string id = null)
        {

            var unit = _fullService.Get(id);
            if (unit == null)
            {
                throw new Exception("Not Found");
            }
            return Ok(unit);
        }

        [ActionName("createorupdate")]
        public IHttpActionResult PostCreateorUpdate([FromBody] SkillDocument doc)
        {
            var returnDoc = _fullService.CreateOrUpdate(doc);
            if (returnDoc == null)
            {
                throw new Exception("Not Found");
            }
            return Ok(returnDoc);
        }
    }
}
