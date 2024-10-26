using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Escolar_net.Models;

namespace Escolar_net.Models;

    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        
        public DbSet<AñoEscolar> AñoEscolars { get; set; }

        public DbSet<Aula> Aulas { get; set; }
        public DbSet<BoletinDeCalificacion> BoletinDeCalificacions { get; set; }

        public DbSet<Clase> Clases { get; set; }

        public DbSet<Estudiante> Estudiantes { get; set; }
        public DbSet<Factura> Facturas { get; set; }

        public DbSet<Grado> Grados { get; set; }
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Matricula> Matriculas { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<Periodo> Periodos { get; set; }
        public DbSet<Profesor> Profesors { get; set; }
        public DbSet<Tutor> Tutores { get; set; }

         public DbSet<Test> Tests { get; set; }
           protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración para eliminar en cascada cuando se elimine un BoletinDeCalificacion
            modelBuilder.Entity<Nota>()
                .HasOne(n => n.BoletinDeCalificacion)
                .WithMany(b => b.Notas)
                .HasForeignKey(n => n.BoletinDeCalificacionId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

    }


            //public DbSet<FaltaDisciplinaria> FaltaDisciplinarias { get; set; }
       // public DbSet<ConceptoDePago> ConceptoDePagos { get; set; }
              // public DbSet<Calificacion> Calificacions { get; set; }
       // public DbSet<Asistencia> Asistencias { get; set; }
