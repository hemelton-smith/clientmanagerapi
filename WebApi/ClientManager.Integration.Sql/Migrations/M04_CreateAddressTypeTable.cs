using FluentMigrator;

namespace ClientManager.Integration.Sql.Migrations
{
    [Migration(202104141505)]
    public class M04_CreateAddressTypeTable : Migration
    {
        public override void Down()
        {
            throw new System.NotImplementedException();
        }

        public override void Up()
        {
            Create.Table("AddressType")
                .WithColumn("Id").AsInt32().PrimaryKey("PK_AddressTypeId")
                .WithColumn("Type").AsString();
        }
    }
}
