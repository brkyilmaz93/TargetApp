using System;
using System.Linq.Expressions;
using TargetApp.Entities.General;

namespace TargetApp.API.Data
{
    public interface IEntityRepository<T> 
        where T : class, new()
    {

        Messages<T> Insert(T ent, int? userID);
        Messages<T> Update(T ent, int? userID);
        Messages<T> Delete(T ent, int? userID);
        Messages<T> List(T ent, int? userID);
        Messages<T> GetById(int? userID,Expression<Func<T, bool>> filtre = null);


    }
}
