using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.IO;
using System.Text;
using System.Xml;

using Microsoft.AspNetCore.Cryptography;
using System.Security.Cryptography;

using Microsoft.AspNetCore.Identity;
using System.Data;
using System.Reflection;

using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace InfoDaruratSystem.Web.Library.Utilities
{
    public class Functions
    {

        public static bool IsDecimal(string text)
        {
            decimal value;
            bool flag = false;
            if (Decimal.TryParse(text, out value))
                flag = true;

            return flag;
        }

        public static bool IsInteger(string text)
        {
            int value;
            bool flag = false;
            if (int.TryParse(text, out value))
                flag = true;

            return flag;
        }
        public static bool IsDateTime(string txtDate)
        {
            DateTime tempDate;

            return DateTime.TryParse(txtDate, out tempDate) ? true : false;
        }

        public static bool IsValidEmail(string emailAddress)
        {
            string regexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$";
            Match matches = Regex.Match(emailAddress, regexPattern);
            return matches.Success;
        }

        public static bool IsAlphaNumeric(string N)
        {
            bool yesNumeric = false;
            bool yesAlpha = false;
            bool bothStatus = false;

            for (int i = 0; i < N.Length; i++)
            {
                if (char.IsLetter(N[i]))
                    yesAlpha = true;

                if (char.IsNumber(N[i]))
                    yesNumeric = true;
            }

            if (yesAlpha == true && yesNumeric == true)
            {
                bothStatus = true;
            }
            else
            {
                bothStatus = false;
            }

            return bothStatus;
        }

        public static List<int> GetYear()
        {
            List<int> result = new List<int>();

            for (int x = 2014; x <= DateTime.Now.Year; x++)
            {
                result.Add(x);
            }

            return result;
        }

        public static List<string> GetMonth()
        {
            List<string> result = null;

            for (int x = 2015; x <= DateTime.Now.Year; x++)
            {
                result.Add(GetMonthName(x.ToString()));
            }

            return result;
        }

        public static string GetMonthName(string monthValue)
        {

            string monthName = string.Empty;

            if (monthValue == "1")
                monthName = "Januari";
            else if (monthValue == "2")
                monthName = "Februari";
            else if (monthValue == "3")
                monthName = "Maret";
            else if (monthValue == "4")
                monthName = "April";
            else if (monthValue == "5")
                monthName = "Mei";
            else if (monthValue == "6")
                monthName = "Juni";
            else if (monthValue == "7")
                monthName = "Juli";
            else if (monthValue == "8")
                monthName = "Agustus";
            else if (monthValue == "9")
                monthName = "September";
            else if (monthValue == "10")
                monthName = "Oktober";
            else if (monthValue == "11")
                monthName = "November";
            else if (monthValue == "12")
                monthName = "Desember";

            return monthName;
        }

        public static string ParseSeparatorDecimalWithCommaDecimal(string text)
        {
            string myDecimal = string.Empty;

            myDecimal = Convert.ToDecimal(Decimal.Parse(text)).ToString("###,###,###,##0.#0");
            return myDecimal;
        }

        public static string ParseSeparatorPercentWithDecimal(string text)
        {
            string myDecimal = string.Empty;

            myDecimal = Convert.ToDecimal(Decimal.Parse(text)).ToString("##0.#0");
            return myDecimal;
        }


        public static string HashPasswordSha256(string keyData)
        {
            StringBuilder builder = new StringBuilder();
            
            //// Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(keyData));

                // Convert byte array to a string   

                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
            }

            return builder.ToString();

        }

    public static void DeleteFileInFolderUploads(string path)
        {
            System.IO.DirectoryInfo di = new DirectoryInfo(path);

            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }

            foreach (DirectoryInfo dir in di.GetDirectories())
            {
                dir.Delete(true);
            }
        }

        public static IEnumerable<T> GetEntities<T>(DataTable dt)
        {
            if (dt == null)
            {
                return null;
            }

            List<T> returnValue = new List<T>();
            List<string> typeProperties = new List<string>();

            T typeInstance = Activator.CreateInstance<T>();

            foreach (DataColumn column in dt.Columns)
            {
                var prop = typeInstance.GetType().GetProperty(column.ColumnName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public);
                if (prop != null)
                {
                    typeProperties.Add(column.ColumnName);
                }
            }

            foreach (DataRow row in dt.Rows)
            {
                T entity = Activator.CreateInstance<T>();

                foreach (var propertyName in typeProperties)
                {

                    if (row[propertyName] != DBNull.Value)
                    {
                        string str = row[propertyName].GetType().FullName;

                        if (entity.GetType().GetProperty(propertyName).PropertyType == typeof(System.String))
                        {
                            object Val = row[propertyName].ToString();
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, Val, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                        }
                        else if (entity.GetType().GetProperty(propertyName).PropertyType == typeof(System.Guid))
                        {
                            object Val = Guid.Parse(row[propertyName].ToString());
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, Val, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                        }
                        else
                        {
                            entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, row[propertyName], BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                        }
                    }
                    else
                    {
                        entity.GetType().GetProperty(propertyName, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public).SetValue(entity, null, BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.Public, null, null, null);
                    }
                }

                returnValue.Add(entity);
            }

            return returnValue.AsEnumerable();
        }

    }

}
