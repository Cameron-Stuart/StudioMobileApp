using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace U4A3.Model
{
    public class HomeContent
    {
		[PrimaryKey, AutoIncrement]
		public int ID { get; set; }
		public string Title { get; set; }
		public string Content { get; set; }
	}
}
