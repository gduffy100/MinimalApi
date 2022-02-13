﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Domain
using Domain.Entities;

namespace Infrastructure.Persistence
{
    public class ApplicationDbContext
    {
        public DbSet<Car> Cars { get; set; }
    }
}
