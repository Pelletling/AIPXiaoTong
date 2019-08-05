using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Db
{
    /// <summary>
    /// 实现多DbContext的事务，支持分布式事务
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {
        /// <summary>
        /// 提交事务
        /// </summary>
        void Commit();
    }
}