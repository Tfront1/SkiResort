using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Domain;

public interface IKeyedEntity<TKey>
{
    TKey Id { get; set; }
}
