namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CreateTableCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.categories",
                c => new
                    {
                        Id = c.Byte(nullable: false),
                        Name = c.String(maxLength: 255),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        LectuieiId = c.String(),
                        Place = c.String(nullable: false),
                        DateTime = c.DateTime(nullable: false),
                        categoryId = c.Byte(nullable: false),
                        Lecture_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.categories", t => t.categoryId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.Lecture_Id)
                .Index(t => t.categoryId)
                .Index(t => t.Lecture_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "Lecture_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Courses", "categoryId", "dbo.categories");
            DropIndex("dbo.Courses", new[] { "Lecture_Id" });
            DropIndex("dbo.Courses", new[] { "categoryId" });
            DropTable("dbo.Courses");
            DropTable("dbo.categories");
        }
    }
}
