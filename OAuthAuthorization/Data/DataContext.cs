using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using OAuthAuthorization.Models;
using System.Web;

namespace OAuthAuthorization.Data
{

    public class DataContext : DbContext
    {

        public DataContext()
            : base("ReemindMeConnectionString2")
        {

        }

        public DbSet<User> Users { get; set; }

    }

}