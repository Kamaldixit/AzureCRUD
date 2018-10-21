using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Azure.model;

namespace Azure.dbconfig
{
    class MyDbContext: DbContext
    {
            public MyDbContext()
            : base(@"Data Source=.;Initial Catalog=azureData;Integrated Security=True")
        {

        }
            private DbSet<UserDetails> userDetails;

            public DbSet<UserDetails> UserDetails
            {
                get { return userDetails; }
                set { userDetails = value; }
            }
    }
}
