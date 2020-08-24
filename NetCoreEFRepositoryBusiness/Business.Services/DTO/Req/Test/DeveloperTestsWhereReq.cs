using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Business.Services.DTO.Req
{
    public class DeveloperTestsWhereReq
    {
        public List<string> ListName { get; set; }

        public List<int> ListId { get; set; }
    }
}
