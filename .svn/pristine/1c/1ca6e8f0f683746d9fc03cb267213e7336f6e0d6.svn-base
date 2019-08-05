using AIPXiaoTong.Model;
using Framework.LambdaExpression;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IBaseService<E> where E : BaseEntity
    {
        void Add(E Entiry);

        long Count();

        long Count(Expression<Func<E, bool>> expression);

        void Delete(long ID);

        void Delete(Expression<Func<E, bool>> expression);

        E Get(Expression<Func<E, bool>> expression);

        E GetLast(Expression<Func<E, bool>> expression);

        E Get(long ID);

        E Get(Expression<Func<E, bool>> expression, params IOrderByExpression<E>[] orderbys);

        E GetAsNoTracking(Expression<Func<E, bool>> expression);

        IQueryable<E> Gets();

        IQueryable<E> Gets(Expression<Func<E, bool>> expression);

        IQueryable<E> GetsNoTracking(Expression<Func<E, bool>> expression);

        IQueryable<E> Gets(Expression<Func<E, bool>> expression, params IOrderByExpression<E>[] orderbys);

        IList<E> Gets(Expression<Func<E, bool>> expression, int PageIndex, int PageSize, params IOrderByExpression<E>[] orderbys);

        IList<E> GetsNoTracking(Expression<Func<E, bool>> expression, int PageIndex, int PageSize, params IOrderByExpression<E>[] orderbys);

        IList<E> Gets(IQueryable<E> query, int PageIndex, int PageSize, params IOrderByExpression<E>[] orderByExpressions);

        IList<LM> Gets<LM>(IQueryable<E> query, Expression<Func<E, LM>> selector, int PageIndex, int PageSize, params IOrderByExpression<E>[] orderByExpressions) where LM : BaseListModel;

        IList<LM> Gets<LM>(Expression<Func<E, bool>> expression, Expression<Func<E, LM>> selector, int PageIndex, int PageSize, params IOrderByExpression<E>[] orderbys) where LM : BaseListModel;
        void Save(E e);

        void Update(E Entiry);

        void Update(IQueryable<E> source, Expression<Func<E, E>> updateExpression);

        bool Exists(Expression<Func<E, bool>> updateExpression);

        int Commit();


        //------------------------------------------------------------------------------
        
    }
}
