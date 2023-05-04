using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SelfFit.Domain.Entities
{
    public class Image : BaseEntity
    {
        public string Base64Data { get; set; }
        public virtual SportPlayground SportPlayground { get; set; }
    }
}
