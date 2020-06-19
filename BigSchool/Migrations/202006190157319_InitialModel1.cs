namespace BigSchool.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel1 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Courses", new[] { "categoryId" });
            RenameColumn(table: "dbo.Courses", name: "Lecture_Id", newName: "LecturerId");
            RenameIndex(table: "dbo.Courses", name: "IX_Lecture_Id", newName: "IX_LecturerId");
            AlterColumn("dbo.Courses", "Place", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Courses", "CategoryId");
            DropColumn("dbo.Courses", "LectuieiId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Courses", "LectuieiId", c => c.String());
            DropIndex("dbo.Courses", new[] { "CategoryId" });
            AlterColumn("dbo.Courses", "Place", c => c.String(nullable: false));
            RenameIndex(table: "dbo.Courses", name: "IX_LecturerId", newName: "IX_Lecture_Id");
            RenameColumn(table: "dbo.Courses", name: "LecturerId", newName: "Lecture_Id");
            CreateIndex("dbo.Courses", "categoryId");
        }
    }
}
