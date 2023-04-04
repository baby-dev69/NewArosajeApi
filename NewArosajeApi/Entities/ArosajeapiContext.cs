using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace NewArosajeApi.Entities;

public partial class ArosajeapiContext : DbContext
{
    public ArosajeapiContext()
    {
    }

    public ArosajeapiContext(DbContextOptions<ArosajeapiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<City> Cities { get; set; }

    public virtual DbSet<Concern> Concerns { get; set; }

    public virtual DbSet<Messagehistory> Messagehistories { get; set; }

    public virtual DbSet<Plant> Plants { get; set; }

    public virtual DbSet<Plantimage> Plantimages { get; set; }

    public virtual DbSet<Tip> Tips { get; set; }

    public virtual DbSet<Userdatum> Userdata { get; set; }

    public virtual DbSet<Usertype> Usertypes { get; set; }

    public virtual DbSet<Vue> Vues { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>(entity =>
        {
            entity.HasKey(e => e.CityId).HasName("PRIMARY");

            entity.ToTable("city");

            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.CityName)
                .HasMaxLength(50)
                .HasColumnName("cityName");
        });

        modelBuilder.Entity<Concern>(entity =>
        {
            entity.HasKey(e => new { e.PlantId, e.TipId }).HasName("PRIMARY");

            entity.ToTable("concern");

            entity.HasIndex(e => e.TipId, "tipId");

            entity.Property(e => e.PlantId).HasColumnName("plantId");
            entity.Property(e => e.TipId).HasColumnName("tipId");
        });

        modelBuilder.Entity<Messagehistory>(entity =>
        {
            entity.HasKey(e => e.MessageId).HasName("PRIMARY");

            entity.ToTable("messagehistory");

            entity.Property(e => e.MessageId).HasColumnName("messageId");
            entity.Property(e => e.Content)
                .HasMaxLength(250)
                .HasColumnName("content");
            entity.Property(e => e.SendDate)
                .HasColumnType("datetime")
                .HasColumnName("sendDate");
        });

        modelBuilder.Entity<Plant>(entity =>
        {
            entity.HasKey(e => e.PlantId).HasName("PRIMARY");

            entity.ToTable("plant");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.PlantId).HasColumnName("plantId");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.PlantAddress)
                .HasMaxLength(50)
                .HasColumnName("plantAddress");
            entity.Property(e => e.PlantDescription)
                .HasMaxLength(250)
                .HasColumnName("plantDescription");
            entity.Property(e => e.Species)
                .HasMaxLength(100)
                .HasColumnName("species");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Plantimage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PRIMARY");

            entity.ToTable("plantimages");

            entity.HasIndex(e => e.PlantId, "plantId");

            entity.Property(e => e.ImageId).HasColumnName("imageId");
            entity.Property(e => e.Image)
                .HasMaxLength(50)
                .HasColumnName("image");
            entity.Property(e => e.ImageDate)
                .HasColumnType("datetime")
                .HasColumnName("imageDate");
            entity.Property(e => e.PlantId).HasColumnName("plantId");
        });

        modelBuilder.Entity<Tip>(entity =>
        {
            entity.HasKey(e => e.TipId).HasName("PRIMARY");

            entity.ToTable("tip");

            entity.HasIndex(e => e.UserId, "userId");

            entity.Property(e => e.TipId).HasColumnName("tipId");
            entity.Property(e => e.TipDescription)
                .HasMaxLength(250)
                .HasColumnName("tipDescription");
            entity.Property(e => e.UserId).HasColumnName("userId");
        });

        modelBuilder.Entity<Userdatum>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("userdata");

            entity.HasIndex(e => e.CityId, "cityId");

            entity.HasIndex(e => e.TypeId, "typeId");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.Age).HasColumnName("age");
            entity.Property(e => e.CityId).HasColumnName("cityId");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.FirstName)
                .HasMaxLength(250)
                .HasColumnName("firstName");
            entity.Property(e => e.LastName)
                .HasMaxLength(250)
                .HasColumnName("lastName");
            entity.Property(e => e.Password)
                .HasMaxLength(250)
                .HasColumnName("password");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.Status).HasColumnName("status");
            entity.Property(e => e.TypeId).HasColumnName("typeId");
            entity.Property(e => e.UserAddress)
                .HasMaxLength(250)
                .HasColumnName("userAddress");
            entity.Property(e => e.Username)
                .HasMaxLength(250)
                .HasColumnName("username");
        });

        modelBuilder.Entity<Usertype>(entity =>
        {
            entity.HasKey(e => e.TypeId).HasName("PRIMARY");

            entity.ToTable("usertype");

            entity.Property(e => e.TypeId).HasColumnName("typeId");
            entity.Property(e => e.Label)
                .HasMaxLength(50)
                .HasColumnName("label");
        });

        modelBuilder.Entity<Vue>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.MessageId }).HasName("PRIMARY");

            entity.ToTable("vue");

            entity.HasIndex(e => e.MessageId, "messageId");

            entity.Property(e => e.UserId).HasColumnName("userId");
            entity.Property(e => e.MessageId).HasColumnName("messageId");
            entity.Property(e => e.MessageDate)
                .HasColumnType("datetime")
                .HasColumnName("messageDate");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
