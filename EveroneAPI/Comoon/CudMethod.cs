using EveroneAPI.ContextDB;
using EveroneAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EveroneAPI.Comoon
{
    /// <summary>
    /// 增删查改公共方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class CrudMethod<T> where T : class
    {
        private readonly ContextDBs db;
        public CrudMethod(ContextDBs _db)
        {
            db = _db;
        }

        #region 增
        /// <summary>
        /// 增加一行数据
        /// </summary>
        /// <param name="t">数据实体</param>
        /// <returns>操作结果</returns>
        public  OperateResult Insert(T t)
        {

                OperateResult or = new OperateResult();
                try
                {
                    db.Set<T>().Add(t);
                    db.SaveChanges();
                    or.Success = true;
                    or.Describe = "";
                }
                catch (Exception ex)
                {
                    or.Success = false;
                    or.Describe = ex.Message;
                }
                return or;
        }
        /// <summary>
        /// 批量新增数据
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        //public static OperateResult InsertAll(T[] t)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        OperateResult or = new OperateResult();
        //        try
        //        {
        //            foreach (var item in t)
        //            {
        //                context.Set<T>().Add(item);
        //            }
        //            or.TotalCount = context.SaveChanges();
        //            or.Success = true;
        //            or.Describe = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            or.Success = false;
        //            or.Describe = ex.Message;
        //        }
        //        return or;
        //    }
        //}
        #endregion
        #region 删
        /// <summary>
        /// 删除一行数据
        /// </summary>
        /// <param name="id">需要删除的数据的ID</param>
        /// <returns></returns>
        //public static OperateResult Delete(int[] id)
        //{
        // using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        OperateResult or = new OperateResult();
        //        try
        //        {
        //            if (id.Length > 0)
        //            {
        //                foreach (var item in id)
        //                {
        //                    T model = context.Set<T>().Find(item);
        //                    if (model != null)
        //                    {
        //                        context.Entry<T>(model).State = EntityState.Deleted;
        //                    }
        //                }
        //                or.TotalCount = context.SaveChanges();
        //                or.Success = true;
        //                or.Describe = "";
        //            }
        //            else
        //            {
        //                or.Success = false;
        //                or.Describe = "没有选择要删除的数据ID";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            or.Success = false;
        //            or.Describe = ex.Message;
        //        }
        //        return or;
        //    }
        //}
        /// <summary>
        /// 删除一行数据（字符串数组重载）
        /// </summary>
        /// <param name="id">需要删除的数据的ID</param>
        /// <returns></returns>
        //public static OperateResult Delete(string[] id)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        OperateResult or = new OperateResult();
        //        try
        //        {
        //            if (id.Length > 0)
        //            {
        //                foreach (var item in id)
        //                {
        //                    //根据主键获取数据库中的对应实体
        //                    T model = context.Set<T>().Find(item);
        //                    if (model != null)
        //                    {
        //                        //标记为待删除
        //                        context.Entry<T>(model).State = EntityState.Deleted;
        //                    }
        //                }
        //                or.TotalCount = context.SaveChanges();
        //                or.Success = true;
        //                or.Describe = "";
        //            }
        //            else
        //            {
        //                or.Success = false;
        //                or.Describe = "没有选择要删除的数据ID";
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            or.Success = false;
        //            or.Describe = ex.Message;
        //        }
        //        return or;
        //    }
        //}
        #endregion
        #region 查
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sp">查询参数</param>
        /// <param name="order">排序条件</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <returns></returns>
        //public static OperateResult<T> Select(SelectParam sp)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {

        //        OperateResult<T> or = new OperateResult<T>();
        //        if (sp != null)
        //        {
        //            try
        //            {
        //                List<T> tempList = SelectData(db, sp);
        //                or.TotalCount = tempList.Count();
        //                if (sp.PageIndex > 0 && sp.PageSize > 0)
        //                {
        //                    or.Data = tempList.Take(sp.PageSize * sp.PageIndex).ToList().Skip((sp.PageIndex - 1) * sp.PageSize).ToList();
        //                }
        //                else
        //                {
        //                    or.Data = tempList;
        //                }
        //                or.Success = true;
        //            }
        //            catch (Exception ex)
        //            {
        //                or.Describe = ex.Message;
        //                or.TotalCount = 0;
        //                or.Data = null;
        //                or.Success = false;
        //            }
        //        }
        //        else
        //        {
        //            or.Describe = "查询参数格式不正确";
        //            or.TotalCount = 0;
        //            or.Data = null;
        //            or.Success = false;
        //        }
        //        return or;
        //    }
        //}
        /// <summary>
        /// 查询数据（只返回查询结果）
        /// </summary>
        /// <param name="sp">查询参数</param>
        /// <param name="order">排序条件</param>
        /// <param name="isDesc">是否降序排列</param>
        /// <param name="context">数据库上下文</param>
        /// <returns>查询结果</returns>
        public static List<T> SelectData(ContextDBs context, SelectParam sp)
        {
            List<T> tempList = context.Set<T>().ToList();
            //根据查询条件各个属性的数据类型决定如何筛选
            foreach (var item in sp.GetType().GetProperties())
            {
                //将查询条件的PageIndex和PageSize属性排除(以及为Null的条件)
                if (item.GetValue(sp) != null && !string.IsNullOrEmpty(item.GetValue(sp).ToString()) && item.Name != "PageIndex" && item.Name != "PageSize" && item.Name != "MaxCount")
                {
                    //字符串类型的条件，使用Contains（相当于Like）
                    if (item.PropertyType == typeof(string))
                    {
                        tempList = tempList.Where(p => p.GetType().GetProperty(item.Name).GetValue(p) != null && p.GetType().GetProperty(item.Name).GetValue(p).ToString().Contains(item.GetValue(sp).ToString())).ToList();
                    }
                    //数字类型，使用Equals（相当于=）
                    else if (item.PropertyType == typeof(int) || item.PropertyType == typeof(double) || item.PropertyType == typeof(decimal) ||
                             item.PropertyType == typeof(int?) || item.PropertyType == typeof(double?) || item.PropertyType == typeof(decimal?))
                    {
                        tempList = tempList.Where(p => p.GetType().GetProperty(item.Name).GetValue(p).Equals(item.GetValue(sp))).ToList();
                    }
                    //时间类型，筛选两次，筛选出大于时间数组中第一个值且小于第二个值的数据
                    //DateTime[] 时间数组，包含两个DateTime，第一个表示起始时间，第二个表示结束时间
                    else if (item.PropertyType == typeof(DateTime[]))
                    {
                        DateTime[] dt = (DateTime[])item.GetValue(sp);
                        if (dt.Length > 1)
                        {
                            if (dt[0] != null && dt[1] != null)
                            {
                                tempList = tempList.Where(p => ((DateTime)p.GetType().GetProperty(item.Name).GetValue(p) >= dt[0])
                                                  && ((DateTime)p.GetType().GetProperty(item.Name).GetValue(p) <= dt[1])).ToList();
                            }
                            else if (dt[0] != null && dt[1] == null)
                            {
                                tempList = tempList.Where(p => ((DateTime)p.GetType().GetProperty(item.Name).GetValue(p) >= dt[0])).ToList();

                            }
                            else if (dt[0] == null && dt[1] != null)
                            {
                                tempList = tempList.Where(p => ((DateTime)p.GetType().GetProperty(item.Name).GetValue(p) <= dt[1])).ToList();
                            }
                        }
                    }
                }
            }
            if (sp.MaxCount > 0)
            {
                tempList = tempList.Take(sp.MaxCount).ToList();
            }
            return tempList;
        }
        /// <summary>
        ///  查询大量数据（只返回查询结果）
        /// </summary>
        /// <param name="where">查询条件lambda</param>
        /// <param name="order">排序条件</param>
        /// <param name="sp">查询参数</param>
        /// <param name="totalCount">数据总量</param>
        /// <returns></returns>
        //public static List<T> SelectData(System.Linq.Expressions.Expression<Func<T, bool>> where, System.Linq.Expressions.Expression<Func<T, int>> order, SelectParam sp, out int totalCount)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        IQueryable<T> l = context.Set<T>();
        //        //获取数据总数
        //        //这里用try是因为有几个数据量太大的表，光是获取总行数都会超时
        //        try
        //        {
        //            int actualCount = context.Set<T>().Where(where).Count();
        //            totalCount = sp.MaxCount > 0 && actualCount > sp.MaxCount ? sp.MaxCount : actualCount;
        //        }
        //        catch (Exception)
        //        {
        //            totalCount = sp.MaxCount;
        //        }
        //        //取最新数据
        //        if (sp.MaxCount > 0)
        //        {
        //            l = l.Take(sp.MaxCount).OrderByDescending(order);
        //        }
        //        else
        //        {
        //            l = l.OrderByDescending(order);
        //        }
        //        //分页
        //        if (sp.PageIndex > 0)
        //        {
        //            l = l.Where(where).Skip((sp.PageIndex - 1) * sp.PageSize).Take(sp.PageSize);
        //        }
        //        else
        //        {
        //            l = l.Where(where);
        //        }
        //        return l.ToList();
        //    }
        //}
        /// <summary>
        ///  查询大量数据（只返回查询结果）多条件
        /// </summary>
        /// <param name="wheres">查询条件lambda集合</param>
        /// <param name="order">排序条件</param>
        /// <param name="sp">查询参数</param>
        /// <param name="totalCount">数据总量</param>
        /// <returns></returns>
        //public static List<T> SelectData(List<System.Linq.Expressions.Expression<Func<T, bool>>> wheres, System.Linq.Expressions.Expression<Func<T, int>> order, SelectParam sp, out int totalCount)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        IQueryable<T> l = context.Set<T>();
        //        foreach (var item in wheres)
        //        {
        //            l = l.Where(item);
        //        }
        //        //获取数据总数
        //        //这里用try是因为有几个数据量太大的表，光是获取总行数都会超时
        //        try
        //        {
        //            int actualCount = l.Count();
        //            totalCount = sp.MaxCount > 0 && actualCount > sp.MaxCount ? sp.MaxCount : actualCount;
        //        }
        //        catch (Exception)
        //        {
        //            totalCount = sp.MaxCount;
        //        }
        //        //取最新数据
        //        if (sp.MaxCount > 0)
        //        {
        //            l = l.OrderByDescending(order).Take(sp.MaxCount);
        //        }
        //        else
        //        {
        //            l = l.OrderByDescending(order);
        //        }
        //        //分页
        //        if (sp.PageIndex > 0)
        //        {
        //            l = l.Skip((sp.PageIndex - 1) * sp.PageSize).Take(sp.PageSize);
        //        }
        //        return l.ToList();
        //    }
        //}
        /// <summary>
        ///  查询大量数据（只返回查询结果）多条件  号码段
        /// </summary>
        /// <param name="wheres">查询条件lambda集合</param>
        /// <param name="order">排序条件</param>
        /// <param name="sp">查询参数</param>
        /// <param name="codeColName">号码段的字段名称（发动机号，缸盖号还是副车架号  英文）</param>
        /// <param name="totalCount">数据总量</param>
        /// <returns></returns>
        //public static List<T> SelectData(List<System.Linq.Expressions.Expression<Func<T, bool>>> wheres, System.Linq.Expressions.Expression<Func<T, int>> order, CodeFrameSelectParam sp, string codeColName, out int totalCount)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        IQueryable<T> l;
        //        if (sp.CodeFrame != null && sp.CodeFrame.Count() > 1)
        //        {
        //            int codeCount = sp.CodeFrame[1] - sp.CodeFrame[0];
        //            List<string> codeList = new List<string>();
        //            string tempCode = "";
        //            for (int i = 0; i <= codeCount; i++)
        //            {
        //                tempCode = sp.FeatureCode + (sp.CodeFrame[0] + i).ToString().PadLeft(7, '0');
        //                codeList.Add(tempCode);
        //            }
        //            string sql = $" SELECT  * FROM {typeof(T).Name} " +
        //                         $" WHERE  {codeColName} IN ('{string.Join("\',\'", codeList.ToArray())}')";
        //            l = context.Set<T>().SqlQuery(sql).AsQueryable();
        //        }
        //        else
        //        {
        //            l = context.Set<T>().AsQueryable();
        //        }
        //        foreach (var item in wheres)
        //        {
        //            l = l.Where(item);
        //        }
        //        //获取数据总数
        //        //这里用try是因为有几个数据量太大的表，光是获取总行数都会超时
        //        try
        //        {
        //            int actualCount = l.Count();
        //            totalCount = sp.MaxCount > 0 && actualCount > sp.MaxCount ? sp.MaxCount : actualCount;
        //        }
        //        catch (Exception)
        //        {
        //            totalCount = sp.MaxCount;
        //        }
        //        //取最新数据
        //        if (sp.MaxCount > 0)
        //        {
        //            l = l.OrderByDescending(order).Take(sp.MaxCount);
        //        }
        //        else
        //        {
        //            l = l.OrderByDescending(order);
        //        }
        //        //分页
        //        if (sp.PageIndex > 0)
        //        {
        //            l = l.Skip((sp.PageIndex - 1) * sp.PageSize).Take(sp.PageSize);
        //        }
        //        return l.ToList();
        //    }
        //}
        /// <summary>
        ///  查询大量数据（只返回查询结果）
        /// </summary>
        /// <param name="wheres">查询条件lambda集合</param>
        /// <param name="order">排序条件</param>
        /// <param name="sp">查询参数</param>
        /// <param name="totalCount">数据总量</param>
        /// <returns></returns>
        //public static List<T> SelectSubFrameData(List<Expression<Func<T, bool>>> wheres, System.Linq.Expressions.Expression<Func<T, int>> order, CodeFrameSelectParam sp, string codeColName, out int totalCount)
        //{
        //    using (QLNavDBEntities context = new QLNavDBEntities())
        //    {
        //        IQueryable<T> l;
        //        if (sp.CodeFrame != null && sp.CodeFrame.Count() > 1)
        //        {
        //            int codeCount = sp.CodeFrame[1] - sp.CodeFrame[0];
        //            List<string> codeList = new List<string>();
        //            string tempCode = "";
        //            for (int i = 0; i <= codeCount; i++)
        //            {
        //                tempCode = sp.FeatureCode + (sp.CodeFrame[0] + i).ToString().PadLeft(4, '0');
        //                codeList.Add(tempCode);
        //            }
        //            string sql = $" SELECT  *,[Result] as Result1 FROM {typeof(T).Name} " +
        //                         $" WHERE  {codeColName} IN ('{string.Join("\',\'", codeList.ToArray())}')";
        //            l = context.Set<T>().SqlQuery(sql).AsQueryable();
        //        }
        //        else
        //        {
        //            l = context.Set<T>().AsQueryable();
        //        }
        //        foreach (var item in wheres)
        //        {
        //            l = l.Where(item);
        //        }
        //        //获取数据总数
        //        //这里用try是因为有几个数据量太大的表，光是获取总行数都会超时
        //        try
        //        {
        //            int actualCount = l.Count();
        //            totalCount = sp.MaxCount > 0 && actualCount > sp.MaxCount ? sp.MaxCount : actualCount;
        //        }
        //        catch (Exception)
        //        {
        //            totalCount = sp.MaxCount;
        //        }
        //        //取最新数据
        //        if (sp.MaxCount > 0)
        //        {
        //            l = l.OrderByDescending(order).Take(sp.MaxCount);
        //        }
        //        else
        //        {
        //            l = l.OrderByDescending(order);
        //        }
        //        //分页
        //        if (sp.PageIndex > 0)
        //        {
        //            l = l.Skip((sp.PageIndex - 1) * sp.PageSize).Take(sp.PageSize);
        //        }
        //        return l.ToList();
        //    }
        //}
        #endregion
        #region 改
        /// <summary>
        /// 修改一行数据
        /// </summary>
        /// <param name="t">数据实体</param>
        /// <returns>操作结果</returns>
        //public static OperateResult Update(T t)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        OperateResult or = new OperateResult();
        //        try
        //        {
        //            T model = context.Set<T>().Create();
        //            model = t;
        //            context.Entry<T>(model).State = EntityState.Modified;
        //            or.TotalCount = context.SaveChanges();
        //            or.Success = true;
        //            or.Describe = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            or.Success = false;
        //            or.Describe = ex.Message;
        //        }
        //        return or;
        //    }
        //}
        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <param name="t">待修改的数据集合</param>
        /// <returns></returns>
        //public static OperateResult UpdateAll(T[] t)
        //{
        //    using (AE1RFIDSysDBEntities context = new AE1RFIDSysDBEntities())
        //    {
        //        OperateResult or = new OperateResult();
        //        try
        //        {
        //            foreach (var item in t)
        //            {
        //                T model = context.Set<T>().Create();
        //                model = item;
        //                context.Entry<T>(model).State = EntityState.Modified;
        //            }
        //            or.TotalCount = context.SaveChanges();
        //            or.Success = true;
        //            or.Describe = "";
        //        }
        //        catch (Exception ex)
        //        {
        //            or.Success = false;
        //            or.Describe = ex.Message;
        //        }
        //        return or;
        //    }
        //}
        #endregion
    }
}
