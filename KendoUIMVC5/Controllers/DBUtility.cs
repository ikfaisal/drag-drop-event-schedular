using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;

namespace KendoUIMVC5.Controllers
{
    public static class DBUtility
    {
        /// <summary>
        /// Converts a DataTable to a list with generic objects
        /// </summary>
        /// <typeparam name="T">Generic object</typeparam>
        /// <param name="table">DataTable</param>
        /// <returns>List with generic objects</returns>
        public static List<T> DataTableToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (DataRow row in table.Rows)
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            Type t = Nullable.GetUnderlyingType(propertyInfo.PropertyType) ?? propertyInfo.PropertyType;
                            if (table.Columns.Contains(prop.Name) == true)
                            {
                                object safeValue = (row[prop.Name] == DBNull.Value) ? null : Convert.ChangeType(row[prop.Name], t);
                                propertyInfo.SetValue(obj, safeValue, null);
                            }
                        }
                        catch (Exception ex)
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public static string GetHourMinuteFromSecond(long seconds)
        {
            TimeSpan time = TimeSpan.FromSeconds(seconds);
            string hourMinute = time.ToString(@"hh\:mm").Replace(":", "");

            return hourMinute;
        }
    }
}