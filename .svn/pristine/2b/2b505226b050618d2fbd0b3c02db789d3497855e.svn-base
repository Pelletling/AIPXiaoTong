using System;
using System.Linq;
using System.Linq.Expressions;

namespace Framework.LambdaExpression
{
    public interface IOrderByExpression<TEntity> where TEntity : class
    {
        IOrderedQueryable<TEntity> ApplyOrderBy(IQueryable<TEntity> query);
        IOrderedQueryable<TEntity> ApplyThenBy(IOrderedQueryable<TEntity> query);
    }

    /// <summary>
    /// 排序
    /// </summary>
    /// <typeparam name="TEntity">排序的对象，例：Users</typeparam>
    /// <typeparam name="TOrderBy">排序的字段类型，如按ID排序,填long</typeparam>
    public class OrderByExpression<TEntity, TOrderBy> : IOrderByExpression<TEntity> where TEntity : class
    {
        private Expression<Func<TEntity, TOrderBy>> _expression;
        private bool _descending;

        /// <summary>
        /// 排序,例如：new OrderByExpression<WorkOrder,long>(t=>t.ID,true)
        /// </summary>
        /// <param name="expression"></param>
        /// <param name="descending"></param>
        public OrderByExpression(Expression<Func<TEntity, TOrderBy>> expression,
            bool descending = false)
        {
            _expression = expression;
            _descending = descending;
        }

        public IOrderedQueryable<TEntity> ApplyOrderBy(
            IQueryable<TEntity> query)
        {
            if (_descending)
                return query.OrderByDescending(_expression);
            else
                return query.OrderBy(_expression);
        }

        public IOrderedQueryable<TEntity> ApplyThenBy(
            IOrderedQueryable<TEntity> query)
        {
            if (_descending)
                return query.ThenByDescending(_expression);
            else
                return query.ThenBy(_expression);
        }
    }
}
