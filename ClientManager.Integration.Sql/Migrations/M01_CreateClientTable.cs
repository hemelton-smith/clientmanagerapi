using FluentMigrator;

namespace ClientManager.Integration.Sql.Migrations
{
    [Migration(202104112018)]
    public class M01_CreateClientTable : Migration
    {
        public override void Down()
        {
         
        }

        public override void Up()
        {
            Create.Table("Client")
              .WithColumn("Id").AsGuid().PrimaryKey("PK_ClientId")
              .WithColumn("AddressId").AsGuid()
              .WithColumn("FirstName").AsString(50)
              .WithColumn("LastName").AsString(50)
              .WithColumn("Gender").AsString(50)
              .WithColumn("CellNumber").AsString(10)
              .WithColumn("WorkNumber").AsString(10);
        }
    }
}
