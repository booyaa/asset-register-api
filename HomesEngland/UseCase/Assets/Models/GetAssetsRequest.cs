using System;
using System.Collections.Generic;
using System.Text;

namespace HomesEngland.UseCase.Assets.Models
{
    public class GetAssetsRequest
    {
        public IList<int> Ids { get; set; }
    }
}
