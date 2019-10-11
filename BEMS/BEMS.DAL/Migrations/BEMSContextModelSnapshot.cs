﻿// <auto-generated />
using System;
using BEMS.DAL.EF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BEMS.DAL.Migrations
{
    [DbContext(typeof(BEMSContext))]
    partial class BEMSContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("BEMS.DAL.EF.DBModels.FlowDefine", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("CreatTime");

                    b.Property<int>("Creator");

                    b.Property<string>("FlowStepDefine");

                    b.Property<string>("FlowType");

                    b.HasKey("ID");

                    b.ToTable("FlowDefines");
                });

            modelBuilder.Entity("BEMS.DAL.EF.DBModels.FlowNewEqRequest", b =>
                {
                    b.Property<string>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Amount");

                    b.Property<string>("Assignee");

                    b.Property<int?>("CurrentFlowIndex");

                    b.Property<string>("EquipmentNO");

                    b.Property<string>("EquipmentType");

                    b.Property<short>("IsComplete")
                        .HasColumnType("bit(1)");

                    b.Property<string>("Memo");

                    b.Property<DateTime>("RequestTime");

                    b.Property<string>("Requester");

                    b.HasKey("ID");

                    b.ToTable("FlowNewEqRequest");
                });

            modelBuilder.Entity("BEMS.DAL.EF.DBModels.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Link");

                    b.Property<string>("Name");

                    b.Property<int?>("ParentID");

                    b.HasKey("ID");

                    b.HasIndex("ParentID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("BEMS.DAL.EF.DBModels.Users", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("AccountName")
                        .IsRequired();

                    b.Property<string>("Address");

                    b.Property<string>("CreateBy")
                        .IsRequired();

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("DisplayName");

                    b.Property<string>("LastModifyBy");

                    b.Property<DateTime?>("LastModifyTime");

                    b.Property<string>("Memo");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<short>("State")
                        .HasColumnType("bit(1)");

                    b.HasKey("ID");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("BEMS.DAL.EF.DBModels.Menu", b =>
                {
                    b.HasOne("BEMS.DAL.EF.DBModels.Menu", "Parent")
                        .WithMany("Children")
                        .HasForeignKey("ParentID");
                });
#pragma warning restore 612, 618
        }
    }
}
