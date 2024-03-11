﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CuppaComfort.Migrations
{
    public partial class JobAppRefactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "SubmissionDate",
                table: "JobApplications",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SubmissionDate",
                table: "JobApplications");
        }
    }
}
