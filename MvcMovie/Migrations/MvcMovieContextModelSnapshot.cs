﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using MvcMovie.Models;
using System;

namespace MvcMovie.Migrations
{
    [DbContext(typeof(MvcMovieContext))]
    partial class MvcMovieContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

             modelBuilder.Entity("MvcMovie.Models.Movie", b =>
             {
                b.Property<int>("ID")
                   .ValueGeneratedOnAdd();

                b.Property<string>("Genre");

                b.Property<decimal>("Price");

               b.Property<DateTime>("releasedate");

               b.Property<string>("title");

                b.HasKey("id");

                b.ToTable("movie");
            });
#pragma warning restore 612, 618

            // Additional code for Movie selection and Customer tables not shown
            //modelBuilder.Entity("MvcMovie.Models.Movie", b =>
            //{ 
            //    b.HasOne("MvcMovie.Models.Movie", "Movie")
            //        .WithMany("Selections")
            //        .HasForeignKey("ID")
            //        .OnDelete(DeleteBehavior.Cascade);
            //    });


        }
    }
}
