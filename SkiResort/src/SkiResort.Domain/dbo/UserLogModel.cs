﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkiResort.Domain.dbo;

public class UserLogModel : IKeyedEntity<int>
{
    [Key]
    public int Id { get; set; }

    public string UserName { get; set; }

    public string Page { get; set; }
}
