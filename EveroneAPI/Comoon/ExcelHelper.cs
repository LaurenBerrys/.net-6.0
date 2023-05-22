using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace EveroneAPI.Comoon
{
    /// <summary>
    /// Excel操作类
    /// </summary>
    public class ExcelHelper
    {
        /// <summary>
        /// 根据List数据集合导出Excel，返回文件路径
        /// </summary>
        /// <typeparam name="T">类型</typeparam>
        /// <param name="dataList">数据集合</param>
        /// <param name="FileName">文件名</param>
        /// <param name="dic">列名中英文对照表</param>
        /// <param name="typeDic">特殊类型列名对照表</param>
        /// <returns></returns>
        //public static string GetExcel<T>(List<T> dataList, string FileName, Dictionary<string, string> dic, Dictionary<string, SpecialType> typeDic)
        //{
        //    string path = GetFilePaht(FileName);
        //    //using (ExcelPackage package = new ExcelPackage())
        //    //{
        //    //    ExcelWorksheet sheet = package.Workbook.Worksheets.Add("Sheet1");
        //    //    PropertyInfo[] prop = typeof(T).GetProperties();
        //    //    string propName = "";
        //    //    int actualColIndex = 0;//程序内使用的列序号（因为有些列不需要显示在Excel中）
        //    //    object value;
        //    //    for (int i = 0; i < dataList.Count; i++)
        //    //    {
        //    //        actualColIndex = 0;
        //    //        for (int j = 0; j < prop.Length; j++)
        //    //        {
        //    //            propName = prop[j].Name;
        //    //            if (!dic.Keys.Contains(propName)) continue;
        //    //            value = prop[j].GetValue(dataList[i]);
        //    //            if (i == 0)
        //    //            {
        //    //                sheet.Cells[i + 1, actualColIndex + 1].Value = dic[propName];
        //    //            }

        //    //            if (typeDic.Keys.Contains(propName))
        //    //            {
        //    //                sheet.Cells[i + 2, actualColIndex + 1].Value = TranSpecialType((value), typeDic[propName]);
        //    //            }
        //    //            else
        //    //            {
        //    //                sheet.Cells[i + 2, actualColIndex + 1].Value = value;
        //    //            }
        //    //            //时间格式特殊处理
        //    //            //如果是日期格式，则将此单元格格式设置为日期
        //    //            if (value != null && value.GetType().Equals(typeof(DateTime)))
        //    //            {
        //    //                sheet.Cells[i + 2, actualColIndex + 1].Style.Numberformat.Format = "yyyy-MM-dd HH:mm:ss.000";
        //    //            }
        //    //            actualColIndex++;
        //    //        }
        //    //    }
        //    //    sheet.Cells.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;//水平居中
        //    //    sheet.Cells.Style.VerticalAlignment = ExcelVerticalAlignment.Center;//垂直居中
        //    //    sheet.Cells.AutoFitColumns();
        //    //    sheet.Cells.Style.WrapText = true;//自动换行
        //    //    package.SaveAs(new FileInfo(path));
        //    //    return path;
        //    //}
        //}
        /// <summary>
        /// 获取文件完整路径（程序根目录\ExcelRecord\年\月\日\文件.xlsx）
        /// </summary>
        /// <param name="FileName">文件名（已包含后缀名）</param>
        /// <returns></returns>
        private static string GetFilePaht(string FileName)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                                    $@"ExcelRecord\{DateTime.Now.Year}\{DateTime.Now.Month}\{DateTime.Now.Day}");
            if (!Directory.Exists(path))//如果不存在就创建 dir 文件夹  
                Directory.CreateDirectory(path);
            path += $@"\{FileName}";
            FileInfo file = new FileInfo(path);
            if (file.Exists)
            {
                file.Delete();  // ensures we create a new workbook
                file = new FileInfo(path);
            }
            return path;
        }
        /// <summary>
        /// 将Excel发送至前端
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static HttpResponseMessage SendExcel(string path)
        {
            //发送Excel
            var stream = new FileStream(path, FileMode.Open);
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new StreamContent(stream)
            };
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            response.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            {
                FileName = $"123456.xlsx"
            };
            return response;
        }
        /// <summary>
        /// 将特殊类型转换成中文（例如将0、1转换成NG、OK）
        /// </summary>
        /// <param name="param">待转换数值</param>
        /// <param name="type">特殊类型</param>
        /// <returns></returns>
        private static string TranSpecialType(object param, SpecialType type)
        {
            string result = "";
            int obj;
            if (param == null)
            {
                return result;
            }
            switch (type)
            {
                case SpecialType.报警信息处理状态:
                    if (Convert.ToBoolean(param))
                    {
                        result = "已处理";
                    }
                    else
                    {
                        result = "未处理";
                    }
                    break;
                case SpecialType.测漏结果:
                    if (Convert.ToBoolean(param))
                    {
                        result = "OK";
                    }
                    else
                    {
                        result = "NG";
                    }
                    break;
                case SpecialType.复杂结果类型:
                    obj = Convert.ToInt32(param);
                    if (obj == 0)
                    {
                        result = "NC未完成";
                    }
                    else if (obj == 1)
                    {
                        result = "OK";
                    }
                    else if (obj == 2)
                    {
                        result = "NG";
                    }
                    break;
                case SpecialType.控制方式:
                    obj = Convert.ToInt32(param);
                    if (obj == 0)
                    {
                        result = "力矩控制";
                    }
                    else if (obj == 1)
                    {
                        result = "角度控制";
                    }
                    break;
                case SpecialType.结果类型:
                    obj = Convert.ToInt32(param);
                    if (obj == 0)
                    {
                        result = "NG";
                    }
                    else if (obj == 1)
                    {
                        result = "OK";
                    }
                    else if (obj == 01)
                    {
                        result = "";
                    }
                    break;
                case SpecialType.工位类型:
                    obj = Convert.ToInt32(param);
                    if (obj == 0)
                    {
                        result = "手动工位";
                    }
                    else if (obj == 1)
                    {
                        result = "自动工位";
                    }
                    break;
                case SpecialType.日志类型:
                    obj = Convert.ToInt32(param);
                    if (obj == 0)
                    {
                        result = "操作日志";
                    }
                    else if (obj == 1)
                    {
                        result = "系统日志";
                    }
                    break;
                case SpecialType.返修类型:
                    obj = Convert.ToInt32(param);
                    if (obj == 1)
                    {
                        result = "返修件";
                    }
                    else
                    {
                        result = "";
                    }
                    break;
                default:
                    break;
            }
            return result;
        }

        /// <summary>
        /// 将中文转换成特殊类型（例如将NG、OK转换成0、1）
        /// </summary>
        /// <param name="param">待转换数值</param>
        /// <param name="type">特殊类型</param>
        /// <returns></returns>
        private static object TranSpecialTypeReverse(string param, SpecialType type)
        {
            object result = "";
            switch (type)
            {
                case SpecialType.报警信息处理状态:
                    if (param.Equals("已处理"))
                    {
                        result = true;
                    }
                    else if (param.Equals("未处理"))
                    {
                        result = false;
                    }
                    break;
                case SpecialType.测漏结果:
                    if (param.Equals("OK"))
                    {
                        result = true;
                    }
                    else if (param.Equals("NG"))
                    {
                        result = false;
                    }
                    break;
                case SpecialType.复杂结果类型:
                    if (param.Equals("NC未完成"))
                    {
                        result = 0;
                    }
                    else if (param.Equals("OK"))
                    {
                        result = 1;
                    }
                    else if (param.Equals("NG"))
                    {
                        result = 2;
                    }
                    break;
                case SpecialType.控制方式:
                    if (param.Equals("力矩控制"))
                    {
                        result = 0;
                    }
                    else if (param.Equals("角度控制"))
                    {
                        result = 1;
                    }
                    break;
                case SpecialType.结果类型:
                    if (param.Equals("NG"))
                    {
                        result = 0;
                    }
                    else if (param.Equals("OK"))
                    {
                        result = 1;
                    }
                    break;
                case SpecialType.工位类型:
                    if (param.Equals("手动工位"))
                    {
                        result = 0;
                    }
                    else if (param.Equals("自动工位"))
                    {
                        result = 1;
                    }
                    break;
                case SpecialType.日志类型:
                    if (param.Equals("操作日志"))
                    {
                        result = 0;
                    }
                    else if (param.Equals("系统日志"))
                    {
                        result = 1;
                    }
                    break;
                case SpecialType.返修类型:
                    if (param.Equals("返修件"))
                    {
                        result = 1;
                    }
                    else
                    {
                        result = -1;
                    }
                    break;
                default:
                    break;
            }
            return result;
        }
        /// <summary>
        /// 特殊类型处理枚举
        /// </summary>
        public enum SpecialType
        {
            ///bool类型，0表示未处理,1表示已处理
            报警信息处理状态 = 1,
            ///int类型，0表示NC未完成，1表示OK，2表示NG
            复杂结果类型 = 2,
            ///int类型，0表示力矩控制,1表示角度控制,默认为0
            控制方式 = 3,
            ///int类型，0表示NG，1表示OK 
            结果类型 = 4,
            ///int类型，0表示手动工位，1表示自动工位
            工位类型 = 5,
            ///int类型，0表示操作日志,1表示系统日志
            日志类型 = 6,
            返修类型 = 7,
            测漏结果 = 8,
        }
        /// <summary>
        /// 将Excel中的数据导入到数据库中
        /// </summary>
        /// <param name="path">Excel文件路径</param>
        /// <param name="dic">中文列名与英文列名的对应关系</param>
        /// <param name="typeDic">特殊类型列名对应关系</param>
        //public static List<T> ExcelDataInput<T>(string path, Dictionary<string, string> dic, Dictionary<string, SpecialType> typeDic) where T : class, new()
        //{
        //    //using (ExcelPackage package = new ExcelPackage(new FileInfo(path)))
        //    //{
        //    //    //工作簿
        //    //    ExcelWorksheet sheet = package.Workbook.Worksheets[1];
        //    //    //总行数
        //    //    int rowCount = sheet.Dimension.Rows;
        //    //    //总列数
        //    //    int colCount = sheet.Dimension.Columns;
        //    //    //要返回的数据集合
        //    //    var dataList = new List<T>();
        //    //    //数据模型
        //    //    T t;
        //    //    //类型
        //    //    Type type = typeof(T);
        //    //    //此列的列名（中文）
        //    //    string colName = "";
        //    //    //此行此列的值
        //    //    object colValue;
        //    //    //属性对象
        //    //    PropertyInfo prop;
        //    //    //空白列计数
        //    //    int spaceColCount = 0;
        //    //    //EPPLUS第一个单元格坐标是（1，1），Excel中第一行是列名
        //    //    for (int i = 2; i <= rowCount; i++)
        //    //    {
        //    //        t = new T();
        //    //        spaceColCount = 0;
        //    //        for (int j = 1; j <= colCount; j++)
        //    //        {
        //    //            colName = sheet.Cells[1, j].Value.ToString();
        //    //            colValue = sheet.Cells[i, j].Value;
        //    //            //排除空值
        //    //            if (colValue == null)
        //    //            {
        //    //                spaceColCount++;
        //    //                continue;
        //    //            }
        //    //            //使用反射给模型各个属性赋值
        //    //            if (!dic.Keys.Contains(colName)) continue;
        //    //            //特殊值转换（如NG、OK转换为0、1）
        //    //            if (typeDic.Keys.Contains(colName))
        //    //            {
        //    //                colValue = TranSpecialTypeReverse(colValue.ToString(), typeDic[colName]);
        //    //            }
        //    //            prop = type.GetProperty(dic[colName]);
        //    //            if (prop.PropertyType.Equals(typeof(string)))
        //    //            {
        //    //                prop.SetValue(t, colValue.ToString());
        //    //            }
        //    //            else if (prop.PropertyType.Equals(typeof(int)) || prop.PropertyType.Equals(typeof(int?)))
        //    //            {
        //    //                prop.SetValue(t, Convert.ToInt32(colValue));
        //    //            }
        //    //            else if (prop.PropertyType.Equals(typeof(DateTime)) || prop.PropertyType.Equals(typeof(DateTime?)))
        //    //            {
        //    //                prop.SetValue(t, ToDateTimeValue(colValue.ToString()));
        //    //            }
        //    //            else
        //    //            {
        //    //                prop.SetValue(t, colValue);
        //    //            }
        //    //        }
        //    //        if (spaceColCount < colCount)
        //    //        {
        //    //            dataList.Add(t);
        //    //        }
        //    //    }
        //    //    return dataList;
        //    //}
        //}
        /// <summary>
        /// Excel数字类型时间转换成标准时间格式
        /// </summary>
        /// <param name="strNumber">数字,如:42095.7069444444/0.650694444444444</param>
        /// <returns>日期/时间格式</returns>
        public static DateTime ToDateTimeValue(string strNumber)
        {
            if (!string.IsNullOrWhiteSpace(strNumber))
            {
                //先检查 是不是数字;
                if (decimal.TryParse(strNumber, out decimal tempValue))
                {
                    //天数,取整
                    int day = Convert.ToInt32(Math.Truncate(tempValue));
                    //这里也不知道为什么. 如果是小于32,则减1,否则减2
                    //日期从1900-01-01开始累加 
                    // day = day < 32 ? day - 1 : day - 2;
                    DateTime dt = new DateTime(1900, 1, 1).AddDays(day < 32 ? (day - 1) : (day - 2));

                    //小时:减掉天数,这个数字转换小时:(* 24) 
                    decimal hourTemp = (tempValue - day) * 24;//获取小时数
                                                              //取整.小时数
                    int hour = Convert.ToInt32(Math.Truncate(hourTemp));
                    //分钟:减掉小时,( * 60)
                    //这里舍入,否则取值会有1分钟误差.
                    Decimal minuteTemp = Math.Round((hourTemp - hour) * 60, 2);//获取分钟数
                    int minute = Convert.ToInt32(Math.Truncate(minuteTemp));
                    //秒:减掉分钟,( * 60)
                    //这里舍入,否则取值会有1秒误差.
                    Decimal secondTemp = Math.Round((minuteTemp - minute) * 60, 2);//获取秒数
                    int second = Convert.ToInt32(Math.Truncate(secondTemp));
                    return new DateTime(dt.Year, dt.Month, dt.Day, hour, minute, second);
                }
            }
            return DateTime.Now;
        }
       
        /// 获取发动机拧紧数据中英文列名对照表

        public static Dictionary<string, string> GetEngineTighteningDic()
        {
            Dictionary<string, string> dic = new Dictionary<string, string>
            {
                { "EngineCode", "发动机号" },
                { "StationName", "工位名称" },
                { "DataNO", "拧紧编号" },
                { "BoltNO", "螺栓编号" },
                { "Torque", "力矩" },
                { "Angle", "角度" },
                { "Result", "结果" },
                { "ResultTime", "完成时间" },
                { "CreateTime", "创建时间" },
            };
            return dic;
        }
        /// <summary>
        /// 获取发动机拧紧数据特殊列中英文列名对照表
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, SpecialType> GetEngineTighteningTypeDic()
        {
            Dictionary<string, SpecialType> dic = new Dictionary<string, SpecialType>
            {
                { "Result", SpecialType.结果类型 },
            };
            return dic;
        }
   
    }
}
