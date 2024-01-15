﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using lab2.Models;

namespace lab2.Data
{
    public class lab2Context : DbContext
    {
        public lab2Context (DbContextOptions<lab2Context> options)
            : base(options)
        {
        }

        public DbSet<lab2.Models.Book> Book { get; set; } = default!;
        public DbSet<lab2.Models.Publisher> Publisher { get; set; } = default!;
    }
}
