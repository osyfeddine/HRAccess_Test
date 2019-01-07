using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

using System.Data.Entity;

namespace DAO.Common
{
    public static class LinqExtensions
    {
        /// <summary>
        /// Acts similar of .Include() LINQ method, but allows to include several object properties at once.
        /// </summary>
        public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params Expression<Func<T, object>>[] paths)
            where T : class
        {
            foreach (var path in paths)
                query = query.Include(path);

            return query;
        }
    }
}
