using Microsoft.EntityFrameworkCore;
using MultiBooks_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiBooks_DataAccess.Data
{
  public static class ModelBuilderDataGenerator
  {
    public static void GenerateData(this ModelBuilder builder)
    {
      #region Données pour Subject
      builder.Entity<Subject>().HasData(new Subject() { Id = 1, Name = "Romance"});
      builder.Entity<Subject>().HasData(new Subject() { Id = 2, Name = "Ressources humaines" });
      builder.Entity<Subject>().HasData(new Subject() { Id = 3, Name = "Mystère" });
      builder.Entity<Subject>().HasData(new Subject() { Id = 4, Name = "Aventure" });
      #endregion

      #region Données pour Publisher
      builder.Entity<Publisher>().HasData(new Publisher() { Id = 1, Name = @"J'ai lu",Speciality = "Romance, Policier", PublisherSite = @"" });
      builder.Entity<Publisher>().HasData(new Publisher() { Id = 2, Name = @"Chenelière", Speciality = "Collégial et universitaire", PublisherSite = @"" });
      builder.Entity<Publisher>().HasData(new Publisher() { Id = 3, Name = @"Éditions ADA", Speciality = "jeunesse, mystère", PublisherSite = @"www.ada-inc.com/" });
      #endregion

      #region Données pour Book
      builder.Entity<Book>().HasData(new Book() { Id = 1, Title = @"De la supervision à la gestion", ISBN = "9782765053200", Price = 22.95, PublishedDate = new DateTime(2015, 10, 04, 13, 12, 00), Available = true, Resume= "La quatrième édition de cet ouvrage de référence propose un éclairage nouveau sur la gestion des ressources humaines en présentant l’une de ses variantes aujourd’hui incontournable : la gestion des talents. Vous y retrouverez les grands thèmes de la GRH, étudiés à travers les stratégies à appliquer dans le contexte actuel de nombreuses entreprises.", Publisher_Id = 2, Subject_Id = 2 });
      builder.Entity<Book>().HasData(new Book() { Id = 2, Title = @"Amos Daragon LA COLERE D’ENKI", ISBN = "9782898083662", Price = 16.95, PublishedDate = new DateTime(2019, 11, 06, 13, 12, 00), Available = true, Resume = "", Publisher_Id = 3, Subject_Id = 4 });
      builder.Entity<Book>().HasData(new Book() { Id = 3, Title = @"Amos Daragon LA TOUR D’EL-BAB", ISBN = "9782898083693", Price = 16.95, PublishedDate = new DateTime(2020, 11, 06, 13, 12, 00), Available = true, Resume = "", Publisher_Id = 3, Subject_Id = 4 });

      //builder.Entity<Book>().HasData(new Book() { Id = 1, Title = @"", ISBN = "", Price = 95.25, PublishedDate = new DateTime(2015, 10, 04, 13, 12, 00), Available = true, Resume = "", Publisher_Id = 1, Subject_Id = 1 });
      //builder.Entity<Book>().HasData(new Book() { Id = 1, Title = @"", ISBN = "", Price = 95.25, PublishedDate = new DateTime(2015, 10, 04, 13, 12, 00), Available = true, Resume = "", Publisher_Id = 1, Subject_Id = 1 });
      #endregion
    }
  }
}
