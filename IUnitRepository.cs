using System;
using RentManagementSystem.Models;

namespace RentManagementSystem
{
	public interface IUnitRepository
	{
		public IEnumerable<Units> GetAllUnits();
		public Units GetUnitsByTenantId(int id);
		public void UpdateUnit(Units units);
		public void InsertUnit(Units unitsToInsert);
		public IEnumerable<Category> GetCategories();
		public Units AssignCategory();
	}
}

