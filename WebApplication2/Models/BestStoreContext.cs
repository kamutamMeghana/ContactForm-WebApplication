using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication2.Models;

public partial class BestStoreContext : DbContext
{
    public BestStoreContext()
    {
    }

    public BestStoreContext(DbContextOptions<BestStoreContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=BestStoreDB;Username=postgres;Password=0110");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Uniqueid).HasName("contacts_pkey");

            entity.ToTable("contacts");

            entity.Property(e => e.Uniqueid)
                .UseIdentityAlwaysColumn()
                .HasIdentityOptions(null, null, null, 2147456677L, null, null)
                .HasColumnName("uniqueid");
            entity.Property(e => e.Createddate).HasColumnName("createddate");
            entity.Property(e => e.Email)
                .HasMaxLength(200)
                .HasColumnName("email");
            entity.Property(e => e.Firstname)
                .HasMaxLength(100)
                .HasColumnName("firstname");
            entity.Property(e => e.Lastname)
                .HasMaxLength(100)
                .HasColumnName("lastname");
            entity.Property(e => e.Message)
                .HasColumnType("character varying")
                .HasColumnName("message");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
