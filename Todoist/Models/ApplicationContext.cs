﻿using Microsoft.EntityFrameworkCore;

namespace Todoist.Models
{
	public class ApplicationContext:DbContext
	{
		public ApplicationContext(DbContextOptions<ApplicationContext> options):base(options)=>
			Database.EnsureCreated();

		public DbSet<Task> Tasks { get; set; } = null!;
	}
}

