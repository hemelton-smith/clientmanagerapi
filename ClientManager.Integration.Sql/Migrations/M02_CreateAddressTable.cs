using FluentMigrator;

namespace ClientManager.Integration.Sql.Migrations
{
    [Migration(202104112020)]
    public class M02_CreateAddressTable : Migration
    {
        public override void Down()
        {

        }

        public override void Up()
        {
            Create.Table("Address")
       .WithColumn("Id").AsGuid().PrimaryKey("PK_AddressId")
       .WithColumn("ClientId").AsGuid().ForeignKey("Client", "Id")
       .WithColumn("Street").AsString(100)
       .WithColumn("Town").AsString(100)
       .WithColumn("Code").AsString(10)
       .WithColumn("Type").AsInt32();
        }
    }
}
