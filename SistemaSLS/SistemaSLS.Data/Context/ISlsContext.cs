using SistemaSLS.Domain.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace SistemaSLS.Data.Context
{
    public interface ISlsContext
    {

        DbSet<TipoPersona> TipoPersona { get; set; }
        DbSet<TipoMoneda> TipoMoneda { get; set; }
        DbSet<TipoServicio> TipoServicio { get; set; }
        DbSet<Servicio> Servicio { get; set; }
        DbSet<Persona> Persona { get; set; }
        DbSet<Pais> Pais { get; set; }
        DbSet<Provincia> Provincia { get; set; }
        DbSet<Ciudad> Ciudad { get; set; }
        DbSet<Agenda> Agenda { get; set; }
        DbSet<TipoDictado> TipoDictado { get; set; }
        DbSet<Empresa> Empresa { get; set; }


        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void Dispose();


    }
}
