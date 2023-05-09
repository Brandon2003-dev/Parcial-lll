using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AppWebAppGestiónPedidosTienda.Models;

public partial class AppGestiónPedidosTiendaContext : DbContext
{
    public AppGestiónPedidosTiendaContext()
    {
    }

    public AppGestiónPedidosTiendaContext(DbContextOptions<AppGestiónPedidosTiendaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<DetalleDePedido> DetalleDePedidos { get; set; }

    public virtual DbSet<Pedido> Pedidos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-34LHMKA\\SQLEXPRESS;Database=AppGestiónPedidosTienda;Trusted_Connection=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdClientes).HasName("PK__Clientes__88A514CDDDD26022");

            entity.Property(e => e.IdClientes).HasColumnName("ID_Clientes");
            entity.Property(e => e.Contraseña)
                .HasMaxLength(12)
                .IsUnicode(false);
            entity.Property(e => e.Dirección)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.NombreUs)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DetalleDePedido>(entity =>
        {
            entity.HasKey(e => e.IdDetalleDePedidos).HasName("PK__Detalle___E15F73B0FF60805D");

            entity.ToTable("Detalle_de_Pedidos");

            entity.Property(e => e.IdDetalleDePedidos).HasColumnName("ID_Detalle_de_Pedidos");
            entity.Property(e => e.IdPedidos).HasColumnName("ID_Pedidos");
            entity.Property(e => e.IdProductos).HasColumnName("ID_Productos");

            entity.HasOne(d => d.IdPedidosNavigation).WithMany(p => p.DetalleDePedidos)
                .HasForeignKey(d => d.IdPedidos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_d__ID_Pe__5165187F");

            entity.HasOne(d => d.IdProductosNavigation).WithMany(p => p.DetalleDePedidos)
                .HasForeignKey(d => d.IdProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Detalle_d__ID_Pr__52593CB8");
        });

        modelBuilder.Entity<Pedido>(entity =>
        {
            entity.HasKey(e => e.IdPedidos).HasName("PK__Pedidos__5F47B6DF5FB2B585");

            entity.Property(e => e.IdPedidos).HasColumnName("ID_Pedidos");
            entity.Property(e => e.FechaDePedidos)
                .HasColumnType("datetime")
                .HasColumnName("Fecha_de_Pedidos");
            entity.Property(e => e.IdClientes).HasColumnName("ID_Clientes");
            entity.Property(e => e.IdProductos).HasColumnName("ID_Productos");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdClientesNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdClientes)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__ID_Clie__4D94879B");

            entity.HasOne(d => d.IdProductosNavigation).WithMany(p => p.Pedidos)
                .HasForeignKey(d => d.IdProductos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Pedidos__ID_Prod__4E88ABD4");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProductos).HasName("PK__Producto__0CBA5DE9480F6751");

            entity.Property(e => e.IdProductos).HasColumnName("ID_Productos");
            entity.Property(e => e.Descripción)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
