using AIPXiaoTong.Model;
using Framework.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AIPXiaoTong.IService
{
    public interface IBusinessService<T> : IBaseService<T> where T : BaseEntity
    {

        BaseModel GetViewModel<BM>(long? ID = null) where BM : BaseModel, new();

        ResultModel AjaxDelete(long ID);

        Expression<Func<T, bool>> GetExpress<QM>(QM model = null) where QM : BaseQueryModel, new();

        /// <summary>
        /// 分页查询(实体)
        /// </summary>
        /// <typeparam name="QM"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<T> GetList<QM>(QM model = null) where QM : BaseQueryModel, new();

        IList<T> GetAllList<QM>(QM model = null) where QM : BaseQueryModel, new();

        /// <summary>
        /// 分页查询(转换成Model)
        /// </summary>
        /// <typeparam name="LM"></typeparam>
        /// <typeparam name="QM"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        IList<LM> GetListModel<LM, QM>(QM model = null) where QM : BaseQueryModel, new() where LM : BaseListModel, new();


        IList<LM> GetAllListModel<LM, QM>(QM model = null) where QM : BaseQueryModel, new() where LM : BaseListModel, new();

        IList<LM> GetUseListModel<LM, QM>(QM model = null) where QM : BaseQueryModel, new() where LM : BaseListModel, new();

        IList<LM> SelectListModel<LM, QM>(Expression<Func<T, LM>> selector, QM model = null) where LM : BaseListModel, new() where QM : BaseQueryModel, new();

        MemoryStream ExportNPOI<Model>(List<Model> list, string SheetName = "Sheet") where Model : BaseExportModel;


        //----------------------------------------------------------
        //List<ValueTextModel> GetJobList();

    }
}
