using System;

namespace RentManagementSystem.Models
{
	public class Units
	{
		public string Tenant_Name { get; set; }
		public int Tenant_ID { get; set; }
		public int Unit { get; set; }
		public double Payment { get; set; }
        public IEnumerable<Category> Categories { get; internal set; }
    }
}

