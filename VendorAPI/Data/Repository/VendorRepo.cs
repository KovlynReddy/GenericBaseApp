﻿using VendorAPI.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendorAPI.Data.Repository
{
    public class VendorRepo : IVendor
    {
        public Task<Vendor> Delete(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Vendor>> Get()
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> Get(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> Post(Vendor model)
        {
            throw new NotImplementedException();
        }

        public Task<Vendor> Put(Vendor model)
        {
            throw new NotImplementedException();
        }
    }
}
