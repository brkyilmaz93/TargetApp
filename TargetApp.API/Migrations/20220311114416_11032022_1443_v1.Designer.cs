// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TargetApp.API.Data;

namespace TargetApp.API.Migrations
{
    [DbContext(typeof(TargetAppContext))]
    [Migration("20220311114416_11032022_1443_v1")]
    partial class _11032022_1443_v1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.15")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TargetApp.Entities.Concreate.Log", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Logs");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.MyAppHealth", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("MyAppInfoId")
                        .HasColumnType("int");

                    b.Property<string>("StatusCode")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MyAppInfoId");

                    b.ToTable("MyAppHealths");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.MyAppInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("PeriodicallyTimeForCheck")
                        .HasColumnType("int");

                    b.Property<string>("TargetName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Url")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("MyAppInfos");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Content")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Header")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<int>("MyAppHealthId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MyAppHealthId")
                        .IsUnique();

                    b.ToTable("Notification");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDelete")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Surname")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.MyAppHealth", b =>
                {
                    b.HasOne("TargetApp.Entities.Concreate.MyAppInfo", "MyAppInfo")
                        .WithMany()
                        .HasForeignKey("MyAppInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyAppInfo");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.MyAppInfo", b =>
                {
                    b.HasOne("TargetApp.Entities.Concreate.User", "User")
                        .WithMany("Apps")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.Notification", b =>
                {
                    b.HasOne("TargetApp.Entities.Concreate.MyAppHealth", "MyAppHealth")
                        .WithOne("Notification")
                        .HasForeignKey("TargetApp.Entities.Concreate.Notification", "MyAppHealthId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("MyAppHealth");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.MyAppHealth", b =>
                {
                    b.Navigation("Notification");
                });

            modelBuilder.Entity("TargetApp.Entities.Concreate.User", b =>
                {
                    b.Navigation("Apps");
                });
#pragma warning restore 612, 618
        }
    }
}
