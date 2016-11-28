using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using KennelUnion.Data;

namespace KennelUnion.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20161128181851_InitialMigration")]
    partial class InitialMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.1.0-rtm-22752")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KennelUnion.Data.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<int?>("NewsId");

                    b.HasKey("Id");

                    b.HasIndex("NewsId");

                    b.ToTable("Comments");
                });

            modelBuilder.Entity("KennelUnion.Data.Entities.News", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Body");

                    b.Property<DateTime>("CreatedOn");

                    b.Property<string>("Title");

                    b.Property<DateTime>("UpdatedOn");

                    b.HasKey("Id");

                    b.ToTable("NewsSet");
                });

            modelBuilder.Entity("KennelUnion.Data.Entities.Comment", b =>
                {
                    b.HasOne("KennelUnion.Data.Entities.News")
                        .WithMany("Comments")
                        .HasForeignKey("NewsId");
                });
        }
    }
}
