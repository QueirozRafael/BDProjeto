using BDProjeto.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BDProjeto.RepositorioEF
{
    public class BD : DbContext
    {
        public DbSet<Usuario> usuario { get; set; }

        public BD() : base("conectionBD")
        {
            
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //remove pluralização dos nomes das tabelas ex: Usuarios, Produtos
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //criando a tabela
            modelBuilder.Entity<Usuario>().Property(x => x.nome).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuario>().Property(x => x.cargo).IsRequired().HasColumnType("varchar").HasMaxLength(75);
            modelBuilder.Entity<Usuario>().Property(x => x.data).IsRequired().HasColumnType("date");
        }
    }
}

