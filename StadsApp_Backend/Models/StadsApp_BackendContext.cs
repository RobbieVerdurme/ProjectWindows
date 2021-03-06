﻿using StadsApp_Backend.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StadsApp_Backend.Models
{
	public class StadsApp_BackendContext : DbContext
	{
		// You can add custom code to this file. Changes will not be overwritten.
		// 
		// If you want Entity Framework to drop and regenerate your database
		// automatically whenever you change your model schema, please use data migrations.
		// For more information refer to the documentation:
		// http://msdn.microsoft.com/en-us/data/jj591621.aspx

		public StadsApp_BackendContext() : base("name=StadsApp_BackendContext")
		{
		}

		public System.Data.Entity.DbSet<Onderneming> Ondernemings { get; set; }

		public System.Data.Entity.DbSet<Vestiging> Vestigings { get; set; }

        public System.Data.Entity.DbSet<Event> Events { get; set; }

        public System.Data.Entity.DbSet<Promotie> Promoties { get; set; }

        public System.Data.Entity.DbSet<SoortOnderneming> SoortOndernemings { get; set; }
    }
}