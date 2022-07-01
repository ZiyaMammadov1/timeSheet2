using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using TimeSheet.DatabaseContext;
using TimeSheet.Entities;

namespace TimeSheet.Helper
{
    public class CheckDatabase<T> where T : class
    {
        private readonly DataContext _context;
        Answer<T> getFinishObject;

        public CheckDatabase(DataContext context)
        {
            _context = context;
        }

        public Answer<T> Exist(Expression<Func<T, bool>> predicate)
        {
            var exist = _context.Set<T>().FirstOrDefault(predicate);

            if (exist == null)
            {
                return getFinishObject = new Answer<T>(400, "Not Found", null);
            }
            return getFinishObject = new Answer<T>(200, "Founded", new List<T> { exist });
        }

    }
}
