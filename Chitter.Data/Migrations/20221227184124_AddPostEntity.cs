using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Chitter.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddPostEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comments", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Likes",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OwnerID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Likes", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Posts",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Content = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OwnerID = table.Column<int>(type: "int", nullable: false),
                    CreatedUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ModifiedUtc = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Posts", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Replies",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AuthorID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Replies", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "CommentEntityPostEntity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PostsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEntityPostEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentEntityPostEntity_Comments_ID",
                        column: x => x.ID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentEntityPostEntity_Posts_PostsID",
                        column: x => x.PostsID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LikeEntityPostEntity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    PostsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LikeEntityPostEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LikeEntityPostEntity_Likes_ID",
                        column: x => x.ID,
                        principalTable: "Likes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LikeEntityPostEntity_Posts_PostsID",
                        column: x => x.PostsID,
                        principalTable: "Posts",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CommentEntityReplyEntity",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false),
                    CommentsID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommentEntityReplyEntity", x => x.ID);
                    table.ForeignKey(
                        name: "FK_CommentEntityReplyEntity_Comments_CommentsID",
                        column: x => x.CommentsID,
                        principalTable: "Comments",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CommentEntityReplyEntity_Replies_ID",
                        column: x => x.ID,
                        principalTable: "Replies",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CommentEntityPostEntity_PostsID",
                table: "CommentEntityPostEntity",
                column: "PostsID");

            migrationBuilder.CreateIndex(
                name: "IX_CommentEntityReplyEntity_CommentsID",
                table: "CommentEntityReplyEntity",
                column: "CommentsID");

            migrationBuilder.CreateIndex(
                name: "IX_LikeEntityPostEntity_PostsID",
                table: "LikeEntityPostEntity",
                column: "PostsID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommentEntityPostEntity");

            migrationBuilder.DropTable(
                name: "CommentEntityReplyEntity");

            migrationBuilder.DropTable(
                name: "LikeEntityPostEntity");

            migrationBuilder.DropTable(
                name: "Comments");

            migrationBuilder.DropTable(
                name: "Replies");

            migrationBuilder.DropTable(
                name: "Likes");

            migrationBuilder.DropTable(
                name: "Posts");
        }
    }
}
