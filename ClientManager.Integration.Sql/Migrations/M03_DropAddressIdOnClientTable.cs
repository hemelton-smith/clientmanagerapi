using FluentMigrator;

namespace ClientManager.Integration.Sql.Migrations
{
    [Migration(202104141423)]
    public class M03_DropAddressIdOnClientTable : Migration
    {
        public override void Down()
        {
            
        }

        public override void Up()
        {
            Execute.Sql("ALTER TABLE Client DROP COLUMN AddressId");
        }
    }
}
