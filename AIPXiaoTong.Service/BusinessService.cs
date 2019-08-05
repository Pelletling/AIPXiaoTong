using AIPXiaoTong.IService;
using AIPXiaoTong.Model;
using Framework.Common;
using Framework.LambdaExpression;
using Framework.Models;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;

namespace AIPXiaoTong.Service
{
    public class BusinessService<E> : BaseService<E>, IBusinessService<E> where E : BaseEntity
    {

        public virtual Expression<Func<E, bool>> GetExpress<QM>(QM model = null) where QM : BaseQueryModel, new()
        {
            return DynamicExpressions.True<E>();
        }

        public virtual IOrderByExpression<E> GetOrderBy()
        {
            return new OrderByExpression<E, long>(t => t.ID);
        }

        public virtual IList<E> GetList<QM>(QM model = null) where QM : BaseQueryModel, new()
        {
            if (model == null) model = new QM();

            Expression<Func<E, bool>> express = GetExpress(model);

            IOrderByExpression<E> orderby = GetOrderBy();

            IList<E> list = null;

            if (!model.IsNotTracking)
            {
                list = Gets(express, model.PageIndex, model.PageSize, orderby);
            }
            else
            {
                list = GetsNoTracking(express, model.PageIndex, model.PageSize, orderby);
            }
            return list;
        }

        public IList<E> GetAllList<QM>(QM model = null) where QM : BaseQueryModel, new()
        {
            if (model == null) model = new QM();

            model.PageSize = int.MaxValue;

            IList<E> list = GetList<QM>(model);

            return list;
        }

        public virtual IList<LM> GetListModel<LM, QM>(QM model = null)
            where LM : BaseListModel, new()
            where QM : BaseQueryModel, new()
        {
            if (model == null) model = new QM();

            model.IsNotTracking = true;

            var orgList = GetList(model) as PagedList<E>;

            if (orgList.Count > 0)
            {
                var list = new PagedList<LM>(new List<LM>(), model.PageIndex, model.PageSize, orgList.TotalItemCount);

                //Parallel.ForEach(orgList, (m, state) =>
                //{
                //    list.Add(EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<E, LM>().Map(m));
                //});
                //foreach (var m in orgList)
                //{
                //    list.Add(EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<E, LM>().Map(m));
                //}

                orgList.ForEach(m => list.Add(EmitMapper.ObjectMapperManager.DefaultInstance.GetMapper<E, LM>().Map(m)));

                list.CurrentPageIndex = orgList.CurrentPageIndex;

                return list as IList<LM>;
            }

            return new PagedList<LM>(new List<LM>(), 0, 0) as IList<LM>;
        }

        public virtual IList<LM> GetAllListModel<LM, QM>(QM model = null)
            where LM : BaseListModel, new()
            where QM : BaseQueryModel, new()
        {
            if (model == null) model = new QM();

            model.PageSize = int.MaxValue;

            IList<LM> list = GetListModel<LM, QM>(model);

            return list;
        }

        public virtual IList<LM> GetUseListModel<LM, QM>(QM model = null)
            where LM : BaseListModel, new()
            where QM : BaseQueryModel, new()
        {
            if (model == null) model = new QM();

            model.Status = 1;

            return GetAllListModel<LM, QM>(model);
        }

        public virtual IList<LM> SelectListModel<LM, QM>(Expression<Func<E, LM>> selector, QM model = null)
            where LM : BaseListModel, new()
            where QM : BaseQueryModel, new()
        {
            Expression<Func<E, bool>> express = GetExpress(model);

            IOrderByExpression<E> orderby = GetOrderBy();

            var list = Gets(express, selector, model.PageIndex, model.PageSize, orderby);

            return list;
        }

        public MemoryStream ExportNPOI<Model>(List<Model> list, string SheetName = "Sheet")
           where Model : BaseExportModel
        {
            int sheetIndex = 1;
            MemoryStream ms = new MemoryStream();
            IWorkbook workbook = new HSSFWorkbook();//创建Workbook对象

            ISheet sheet = workbook.CreateSheet(SheetName == "Sheet" ? "Sheet1" : SheetName);//创建工作表

            int rowIndex = 0;

            //插入内容
            foreach (var m in list)
            {
                //插入表头
                if (rowIndex == 0)
                {
                    IRow rowHeader = sheet.CreateRow(rowIndex);//在工作表中添加一行
                    AddHeaderNPOI<Model>(rowHeader);
                    rowIndex++;
                }

                //插入表体
                IRow row = sheet.CreateRow(rowIndex);//在工作表中添加一行

                int colIndxe = 0;

                foreach (var p in typeof(Model).GetProperties())
                {
                    ICell cell = row.CreateCell(colIndxe);//在行中添加一列

                    var attrs = p.GetCustomAttributes(true);

                    foreach (var attr in attrs)
                    {
                        var attribute = attr as DisplayAttribute;
                        if (attribute != null)
                        {
                            var value = p.GetValue(m, null);
                            cell.SetCellValue(value != null ? value.ToString() : "");//设置列的内容
                            colIndxe++;
                            break;
                        }
                    }
                }

                //若超过65535行，则创建一个新的工作薄
                if (rowIndex == 65535)
                {
                    sheet = workbook.CreateSheet((SheetName == "Sheet" ? "Sheet" : SheetName) + ++sheetIndex);
                    rowIndex = -1;
                }

                rowIndex++;
            }
            workbook.Write(ms);
            ms.Flush();
            ms.Position = 0;
            return ms;
        }

        /// <summary>
        /// 插入表头
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="row"></param>
        private void AddHeaderNPOI<T>(IRow row) where T : BaseExportModel
        {
            int colIndxe = 0;
            foreach (var p in typeof(T).GetProperties())
            {
                ICell cell = row.CreateCell(colIndxe);//在行中添加一列 
                var attrs = p.GetCustomAttributes(true);
                foreach (var attr in attrs)
                {
                    var attribute = attr as DisplayAttribute;
                    if (attribute != null)
                    {
                        cell.SetCellValue(attribute.Name);//设置列头的内容 
                        colIndxe++;
                    }
                }
            }
        }

        //public List<ValueTextModel> GetJobList()
        //{
        //    List<ValueTextModel> list = new List<ValueTextModel>();

        //    list.Add(new ValueTextModel() { Value = Convert.ToInt16(JobOption.Saler).ToString(), Text = JobOption.Saler.ToDescription() });
        //    list.Add(new ValueTextModel() { Value = Convert.ToInt16(JobOption.Finance).ToString(), Text = JobOption.Finance.ToDescription() });

        //    return list;
        //}

       
    }
}
