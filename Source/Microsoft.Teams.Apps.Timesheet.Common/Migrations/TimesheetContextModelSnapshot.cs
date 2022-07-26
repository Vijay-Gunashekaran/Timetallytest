﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Teams.Apps.Timesheet.Common.Repositories;

namespace Microsoft.Teams.Apps.Timesheet.Common.Migrations
{
    [DbContext(typeof(TimesheetContext))]
    partial class TimesheetContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.Conversation", b =>
            {
                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("BotInstalledOn")
                    .HasColumnType("datetime");

                b.Property<string>("ConversationId")
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnType("varchar(500)");

                b.Property<string>("ServiceUrl")
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnType("varchar(500)");

                b.HasKey("UserId")
                    .HasName("PK__Conversa__1788CC4C7C76A5E6");

                b.ToTable("Conversation");
            });

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.Member", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("(newid())");

                b.Property<bool>("IsBillable")
                    .HasColumnType("bit");

                b.Property<bool>("IsRemoved")
                    .HasColumnType("bit");

                b.Property<Guid>("ProjectId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("Id");

                b.HasIndex("ProjectId");

                b.ToTable("Member");
            });

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.Project", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("(newid())");

                b.Property<int>("BillableHours")
                    .HasColumnType("int");

                b.Property<string>("ClientName")
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)");

                b.Property<Guid>("CreatedBy")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("CreatedOn")
                    .HasColumnType("datetime");

                b.Property<DateTime>("EndDate")
                    .HasColumnType("date");

                b.Property<int>("NonBillableHours")
                    .HasColumnType("int");

                b.Property<DateTime>("StartDate")
                    .HasColumnType("date");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnType("varchar(50)");

                b.HasKey("Id");

                b.ToTable("Project");
            });

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.TaskEntity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("(newid())");

                b.Property<DateTime>("EndDate")
                    .HasColumnType("datetime2");

                b.Property<bool>("IsAddedByMember")
                    .HasColumnType("bit");

                b.Property<bool>("IsRemoved")
                    .HasColumnType("bit");

                b.Property<Guid?>("MemberMappingId")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("ProjectId")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("StartDate")
                    .HasColumnType("datetime2");

                b.Property<string>("Title")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)");

                b.HasKey("Id");

                b.HasIndex("MemberMappingId");

                b.HasIndex("ProjectId");

                b.ToTable("Task");
            });

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.TimesheetEntity", b =>
            {
                b.Property<Guid>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier")
                    .HasDefaultValueSql("(newid())");

                b.Property<int>("Hours")
                    .HasColumnType("int");

                b.Property<DateTime?>("LastModifiedOn")
                    .HasColumnType("datetime");

                b.Property<string>("ManagerComments")
                    .HasMaxLength(100)
                    .HasColumnType("nvarchar(100)");

                b.Property<int>("Status")
                    .HasColumnType("int");

                b.Property<DateTime?>("SubmittedOn")
                    .HasColumnType("datetime");

                b.Property<Guid>("TaskId")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("TaskTitle")
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnType("varchar(100)");

                b.Property<DateTime>("TimesheetDate")
                    .HasColumnType("date");

                b.Property<Guid>("UserId")
                    .HasColumnType("uniqueidentifier");

                b.HasKey("Id");

                b.HasIndex("TaskId");

                b.ToTable("TimesheetEntity");
            });

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.Member", b =>
            {
                b.HasOne("Microsoft.Teams.Apps.Timesheet.Common.Models.Project", "Project")
                    .WithMany("Members")
                    .HasForeignKey("ProjectId")
                    .HasConstraintName("FK__Member__Project")
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.TaskEntity", b =>
            {
                b.HasOne("Microsoft.Teams.Apps.Timesheet.Common.Models.Member", "MemberMapping")
                    .WithMany()
                    .HasForeignKey("MemberMappingId");

                b.HasOne("Microsoft.Teams.Apps.Timesheet.Common.Models.Project", "Project")
                    .WithMany("Tasks")
                    .HasForeignKey("ProjectId")
                    .HasConstraintName("FK__Task__Project")
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.Teams.Apps.Timesheet.Common.Models.TimesheetEntity", b =>
            {
                b.HasOne("Microsoft.Teams.Apps.Timesheet.Common.Models.TaskEntity", "Task")
                    .WithMany("Timesheets")
                    .HasForeignKey("TaskId")
                    .HasConstraintName("FK__Timesheet__Task")
                    .IsRequired();
            });
        }
    }
}