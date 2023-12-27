using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Data.Migrations
{
    /// <inheritdoc />
    public partial class nombrestablas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Director_Videos_VideoId",
                table: "Director");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoActor_Actor_ActorId",
                table: "VideoActor");

            migrationBuilder.DropForeignKey(
                name: "FK_VideoActor_Videos_VideoId",
                table: "VideoActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideoActor",
                table: "VideoActor");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Director",
                table: "Director");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actor",
                table: "Actor");

            migrationBuilder.RenameTable(
                name: "VideoActor",
                newName: "VideosActores");

            migrationBuilder.RenameTable(
                name: "Director",
                newName: "Directores");

            migrationBuilder.RenameTable(
                name: "Actor",
                newName: "Actores");

            migrationBuilder.RenameIndex(
                name: "IX_VideoActor_VideoId",
                table: "VideosActores",
                newName: "IX_VideosActores_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Director_VideoId",
                table: "Directores",
                newName: "IX_Directores_VideoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideosActores",
                table: "VideosActores",
                columns: new[] { "ActorId", "VideoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Directores",
                table: "Directores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actores",
                table: "Actores",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Directores_Videos_VideoId",
                table: "Directores",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideosActores_Actores_ActorId",
                table: "VideosActores",
                column: "ActorId",
                principalTable: "Actores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideosActores_Videos_VideoId",
                table: "VideosActores",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Directores_Videos_VideoId",
                table: "Directores");

            migrationBuilder.DropForeignKey(
                name: "FK_VideosActores_Actores_ActorId",
                table: "VideosActores");

            migrationBuilder.DropForeignKey(
                name: "FK_VideosActores_Videos_VideoId",
                table: "VideosActores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_VideosActores",
                table: "VideosActores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Directores",
                table: "Directores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Actores",
                table: "Actores");

            migrationBuilder.RenameTable(
                name: "VideosActores",
                newName: "VideoActor");

            migrationBuilder.RenameTable(
                name: "Directores",
                newName: "Director");

            migrationBuilder.RenameTable(
                name: "Actores",
                newName: "Actor");

            migrationBuilder.RenameIndex(
                name: "IX_VideosActores_VideoId",
                table: "VideoActor",
                newName: "IX_VideoActor_VideoId");

            migrationBuilder.RenameIndex(
                name: "IX_Directores_VideoId",
                table: "Director",
                newName: "IX_Director_VideoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_VideoActor",
                table: "VideoActor",
                columns: new[] { "ActorId", "VideoId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Director",
                table: "Director",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Actor",
                table: "Actor",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Director_Videos_VideoId",
                table: "Director",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoActor_Actor_ActorId",
                table: "VideoActor",
                column: "ActorId",
                principalTable: "Actor",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VideoActor_Videos_VideoId",
                table: "VideoActor",
                column: "VideoId",
                principalTable: "Videos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
