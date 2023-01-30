using System;
using System.Data;
using Dapper;
using RentManagementSystem.Models;

namespace RentManagementSystem
{
	public class UnitRepository:IUnitRepository
	{
        private readonly IDbConnection _conn;

		public UnitRepository(IDbConnection conn)
		{
            _conn = conn;
		}

    
        public IEnumerable<Units> GetAllUnits()
        {
            return _conn.Query<Units>("SELECT * FROM UNITS;");
        }

     

        public Units GetUnitsByTenantId(int id)
        {
            return _conn.QuerySingle<Units>("SELECT * FROM UNITS WHERE TENANT_ID = @id",

                new {id =id});
        }

       

        public void UpdateUnit(Units units)
        {
            _conn.Execute("UPDATE units SET Tenant_Name = @tenant_name, Unit = @unit, Payment = @payment WHERE Tenant_ID = @id",
                new {tenant_name = units.Tenant_Name, unit = units.Unit, payment = units.Payment, id = units.Tenant_ID });
        }
        

        public Units AssignCAtegory()
        {
           var categoryList = GetCategories();
            var unit = new Units();
            unit.Categories = categoryList;
            return unit;

        }

        public IEnumerable<Category> GetCategories()
        {
            return _conn.Query<Category>("SELECT* FROM units;");
        }

        public Units AssignCategory()
        {
            var categoryList = GetCategories();
            var unit = new Units();
            unit.Categories = categoryList;

            return unit;
        }

        public void InsertUnit(Units unitsToInsert)
        { _conn.Execute("INSERT INTO Units(TENANT_NAME,TENANT_ID,UNIT,PAYMENT) VALUES (@tenant_name,tenant_id,unit,payment);",
            new {tenant_name= unitsToInsert.Tenant_Name,unitsToInsert.Tenant_ID , unitsToInsert.Unit, unitsToInsert.Payment });
        }
    }
}

