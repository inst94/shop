﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shop.Data
{
    public class shopDbContext : DbContext
    {
        public shopDbContext(DbContextOptions<shopDbContext> options)
            : base(options) { }

    }
}
