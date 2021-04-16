using FluentMigrator;

namespace ClientManager.Integration.Sql.Migrations
{
    [Migration(202104141511)]
    public class M05_InsertAddressTypes : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            Insert.IntoTable("AddressType")
                .Row(new { Id = 0, Type = "Residential" })
                .Row(new { Id = 1, Type = "Work" })
                .Row(new { Id = 2, Type = "Postal" });
        }
    }
}
