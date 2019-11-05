namespace WebDemo.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class F3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "CustomerName", c => c.String());
            AddColumn("dbo.OrderDetails", "ProductName", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.OrderDetails", "ProductName");
            DropColumn("dbo.Orders", "CustomerName");
        }
    }
}
