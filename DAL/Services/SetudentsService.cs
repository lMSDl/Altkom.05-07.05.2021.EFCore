﻿using Microsoft.EntityFrameworkCore;
using Models;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Services
{
    public class StudentsService : Service<Student>
    {
        public StudentsService(DbContext context) : base(context)
        {
        }

        public override async Task<Student> ReadAsync(int id)
        {
            return await _context.Set<Student>().Include(x => x.Address).Include(x => x.Company).SingleOrDefaultAsync(x => x.Id == id);
        }

        public override async Task<IEnumerable<Student>> ReadAsync()
        {
            await _context.Set<Address>().LoadAsync();

            return await _context.Set<Student>().ToListAsync();
        }
    }
}
