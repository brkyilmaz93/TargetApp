using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using TargetApp.Entities.General;

namespace TargetApp.API.Data
{
    public class EFEntityRepository<TEntity, TContext> : IEntityRepository<TEntity> where TEntity : class, new()
    where TContext : DbContext, new()
    {
        public Messages<TEntity> Delete(TEntity ent, int? userID)
        {
            Messages<TEntity> m = new Messages<TEntity>();
            PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");
            if (IsDelete != null)
            {
                IsDelete.SetValue(ent, true);
            }

            try
            {
                using (var cnt = new TContext())
                {
                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Modified;
                    cnt.SaveChanges();

                    m.Record = addEntity.Entity;
                    m.RecordId = GetRecordID(addEntity, ent);

                    cnt.Database.CloseConnection();
                }
                m.Status = true;
                m.Message = "Entity deleted.";

            }
            catch (Exception ex)
            {
                m.Status = false;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;

            }
            return m;
        }

        public Messages<TEntity> Insert(TEntity ent, int? userID)
        {
            Messages<TEntity> m = new Messages<TEntity>();
            PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");
            if (IsDelete != null)
            {
                IsDelete.SetValue(ent, false);
            }
            try
            {
                using (var cnt = new TContext())
                {
                    var addEntity = cnt.Entry(ent);
                    addEntity.State = EntityState.Added;
                    cnt.SaveChanges();

                    m.Record = addEntity.Entity;
                    m.RecordId = GetRecordID(addEntity, ent);

                    cnt.Database.CloseConnection();
                }
                m.Status = true;
                m.Message = "Entity addded.";
            }
            catch (System.Exception ex)
            {
                m.Status = false;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }

        public Messages<TEntity> List(TEntity Entity, int? userID)
        {
            throw new System.NotImplementedException();
        }

        public Messages<TEntity> Update(TEntity ent, int? userID)
        {
            Messages<TEntity> m = new Messages<TEntity>();
            PropertyInfo IsDelete = ent.GetType().GetProperty("IsDelete");
            if (IsDelete != null)
            {
                IsDelete.SetValue(ent, false);
            }
            try
            {
                using (var cnt = new TContext())
                {
                    EntityEntry<TEntity> entity = cnt.Entry(ent);
                    IEnumerable<PropertyEntry> lst = cnt.Entry(ent).Properties;

                    string pKey = PrimaryKeyName(entity);
                    foreach (var i in lst)
                    {
                        if (i.CurrentValue != null && i.Metadata.Name != pKey)
                        {
                            i.IsModified = true;
                        }
                    }
                    cnt.SaveChanges();
                    m.Record = entity.Entity;
                    m.RecordId = GetRecordID(entity, ent);
                    cnt.Database.CloseConnection();

                }
                m.Status = true;
                m.Message = "Object updateded";
            }
            catch (Exception ex)
            {
                m.Status = false;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;

        }

        public Messages<TEntity> GetListByRelation(int? userID = null, Expression<Func<TEntity, bool>> filtre = null)
        {
            Messages<TEntity> m = new Messages<TEntity>();
            try
            {
                using (var cnt = new TContext())
                {
                    IQueryable<TEntity> ns = cnt.Set<TEntity>();

                    Type tip = typeof(TEntity);

                    PropertyInfo[] pi = tip.GetProperties();
                    foreach(var i in pi)
                    {
                        ForeignKeyAttribute fka = i.GetCustomAttribute<ForeignKeyAttribute>();

                        if (fka != null)
                        {
                            ns = ns.Include(fka.Name);
                        }

                    }
                    m.Record = ns.SingleOrDefault(filtre);
                    cnt.GetTableName<TEntity>();

                }
                m.Status=true;
                m.Message = "Record got it";
            }
            catch (Exception ex)
            {

                m.Status = false;
                m.Message = ex.Message+Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public Messages<TEntity> GetById(int? userID = null, Expression<Func<TEntity, bool>> filtre = null)
        {
            Messages<TEntity> m = new Messages<TEntity>();

            try
            {
                using (var cnt = new TContext())
                {
                    var ns = cnt.Set<TEntity>();
                    m.Record = ns.FirstOrDefault(filtre);
                    cnt.Database.CloseConnection();
                }
                m.Status = true;
                m.Message = "Record got it.";
            }
            catch (Exception ex)
            {

                m.Status = false;
                m.Message = ex.Message + Environment.NewLine + ex.StackTrace;
            }
            return m;
        }
        public int GetRecordID(EntityEntry<TEntity> _entry, TEntity ent)
        {
            int ID = 0;
            string msj = "";

            try
            {
                var idName = _entry.Metadata.FindPrimaryKey().Properties.Select(x => x.Name).Single();
                ID = (int)ent.GetType().GetProperty(idName).GetValue(ent);
            }
            catch (Exception ex)
            {
                msj = ex.Message;
            }

            return ID;
        }






        public string PrimaryKeyName(EntityEntry<TEntity> _entry)
        {
            var idName = _entry.Metadata.FindPrimaryKey().Properties.Select(x => x.Name).Single();
            return idName;
        }



    }
}
