using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QAndA.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Idprop : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "7aea9063-4cc7-4db3-83c8-956d435fe7da", "AQAAAAIAAYagAAAAEOZFo1p4TZ370m2XpqSG1N/GrEDecXtdhr5q1YLjazMP7pun5GmQV0Px952DcuD4LQ==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "4848c042-f87c-47b2-b48c-40f8eb034a23", "AQAAAAIAAYagAAAAEMr2i7+s1iJDXbezyW8ubZeaUz7Lr1mlCVr3zsDBzi8eqLtwOeAPybWM0v/vJgnKng==" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8e445865-a24d-4543-a6c6-9443d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "55c1c7d8-c595-4567-a9ff-a0339d92387e", "AQAAAAIAAYagAAAAEPDRkRQLUX7xzYaDkqf3IISerNidEcVpnHhePJIxuf3z+ZnGLA5eAts2wap9W+ASoA==" });

            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "9e224968-33e4-4652-b7b7-8574d048cdb9",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "a5e37b8e-e442-4777-b3d5-373f4cbb247e", "AQAAAAIAAYagAAAAEIPQZ5YT3eGJMjIEJO1eFaVzsfTR/MzD+3pJwM9CUOpkr2NNJGjmphSed/QSxI5YTw==" });
        }
    }
}
