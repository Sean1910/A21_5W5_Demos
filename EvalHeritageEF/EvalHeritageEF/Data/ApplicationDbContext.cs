using EvalHeritageEF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EvalHeritageEF.Models.Data
{
  public class ApplicationDbContext: DbContext
  {
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
      
    }
    #region Implémentation A: deux tables, propriétés du parent répétées
      public DbSet<VoitureA> VoitureA { get; set; }
      public DbSet<BateauA> BateauA { get; set; }
    #endregion

    #region Implémentation B: Une seule table, propriétés fusionnées avec Discriminator
      public DbSet<VehiculeB> VehiculeB { get; set; }
      public DbSet<VoitureB> VoitureB { get; set; }
      public DbSet<BateauB> BateauB { get; set; }
    #endregion

    #region Implémentation C: Trois tables
    public DbSet<VehiculeC> VehiculeC { get; set; }
    public DbSet<VoitureC> VoitureC { get; set; }
    public DbSet<BateauC> BateauC { get; set; }
    #endregion

    #region Implémentation D: Trois tables parent abstract
    public DbSet<VehiculeD> VehiculeD { get; set; }
    public DbSet<VoitureD> VoitureD { get; set; }
    public DbSet<BateauD> BateauD { get; set; }
    #endregion

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
      //Exemple B: Configuration fluent API pour le Discriminator
      modelBuilder.Entity<VehiculeB>()
     .HasDiscriminator<string>("Vehicule_type")
     .HasValue<VehiculeB>("Vehicule_base")
     .HasValue<BateauB>("Bateau_spec")
     .HasValue<VoitureB>("Voiture_spec");

      //Exemple C: Forcer la création de 3 tables avec liaisons
      modelBuilder.Entity<VehiculeC>().ToTable("VehiculeC");
      modelBuilder.Entity<VoitureC>().ToTable("VoitureC");
      modelBuilder.Entity<BateauC>().ToTable("BateauC");

      //Exemple D: Forcer la création de 3 tables avec liaisons
      // Avec une classe parent est abstract À ÉVITER ou ajouter des triggers
      modelBuilder.Entity<VehiculeD>().ToTable("VehiculeD");
      modelBuilder.Entity<VoitureD>().ToTable("VoitureD");
      modelBuilder.Entity<BateauD>().ToTable("BateauD");

    }
  }
}
