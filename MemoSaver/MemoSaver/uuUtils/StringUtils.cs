using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Reflection;

namespace uuUtils
{
    public static class StringUtils {

        public static string Repeat(string s, int count)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < count; i++)
            {
                sb.Append(s);
            }
            return sb.ToString();
        }
        public static string Repeat(char s, int count)
        {
            return new String(s, count);
        }

        /// <summary>
        /// 從URL中取 Key / Value
        /// </summary>
        /// <param name="s"></param>
        /// <param name="ignoreCase"></param>
        /// <returns></returns>
        public static Dictionary<string, string> ParseUrl(this string s, bool ignoreCase) {
            Dictionary<string, string> kvs = new Dictionary<string, string>();
            if (string.IsNullOrEmpty(s)) {
                return kvs;
            }

            if (s.IndexOf('?') != -1) {
                s = s.Remove(0, s.IndexOf('?'));
            }

            Regex reg = new Regex(@"[\?&]?(?<key>[^=]+)=(?<value>[^\&]*)");
            MatchCollection ms = reg.Matches(s);
            string key;
            foreach (Match ma in ms) {
                key = ignoreCase ? ma.Groups["key"].Value.ToLower() : ma.Groups["key"].Value;
                if (kvs.ContainsKey(key)) {
                    kvs[key] += "," + ma.Groups["value"].Value;
                } else {
                    kvs[key] = ma.Groups["value"].Value;
                }
            }

            return kvs;
        }

        /// <summary>
        /// 設置 URL中的 key
        /// </summary>
        /// <param name="url"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="encode"></param>
        /// <returns></returns>
        public static string SetUrlKeyValue(this string url, string key, string value, Encoding encode = null) {
            if (url == null)
                url = "";
            if (String.IsNullOrEmpty(key))
                throw new ArgumentNullException("key");
            if (value == null)
                value = "";
            if (null == encode)
                encode = Encoding.UTF8;
            //if (!string.IsNullOrEmpty(url.ParseString(key, true).Trim())) {
            if (url.ParseUrl(true).ContainsKey(key.ToLower())) {
                Regex reg = new Regex(@"([\?\&])(" + key + @"=)([^\&]*)(\&?)", RegexOptions.IgnoreCase);
                //　如果 value 前几个字符是数字，有BUG
                //return reg.Replace(url, "$1$2" + HttpUtility.UrlEncode(value, encode) + "$4");

                return reg.Replace(url, (ma) => {
                    if (ma.Success) {
                        return string.Format("{0}{1}{2}{3}", ma.Groups[1].Value, ma.Groups[2].Value, value, ma.Groups[4].Value);
                    }
                    return "";
                });

            } else {
                return string.Format("{0}{1}{2}={3}",
                    url,
                    (url.IndexOf('?') > -1 ? "&" : "?"),
                    key,
                    value);
                //return url + (url.IndexOf('?') > -1 ? "&" : "?") + key + "=" + value;
            }
        }


        /// <summary>
        /// 修正URL
        /// </summary>
        /// <param name="url"></param>
        /// <returns></returns>
        public static string FixUrl(this string url) {
            return url.FixUrl("");
        }

        /// <summary>
        /// 修正URL
        /// </summary>
        /// <param name="url"></param>
        /// <param name="defaultPrefix"></param>
        /// <returns></returns>
        public static string FixUrl(this string url, string defaultPrefix) {
            // 必須這樣,請不要修改
            if (url == null)
                url = "";

            if (defaultPrefix == null)
                defaultPrefix = "";
            string tmp = url.Trim();
            if (!Regex.Match(tmp, "^(http|https):").Success) {
                tmp = string.Format("{0}/{1}", defaultPrefix, tmp);
            }
            tmp = Regex.Replace(tmp, @"(?<!(http|https):)[\\/]+", "/").Trim();
            return tmp;
        }


        #region To int
        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int ToInt(this string str, int defaultValue) {
            int v;
            if (int.TryParse(str, out v)) {
                return v;
            } else
                return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int ToInt(this string str) {
            return str.ToInt(0);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int? ToIntOrNull(this string str, int? defaultValue) {
            int v;
            if (int.TryParse(str, out v))
                return v;
            else
                return defaultValue;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static int? ToIntOrNull(this string str) {
            return str.ToIntOrNull(null);
        }

        /// <summary>
        /// 智慧轉換為 Int ，取字串中的第一個數位串
        /// </summary>
        /// <param name="str"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static int SmartToInt(this string str, int defaultValue) {
            if (string.IsNullOrEmpty(str))
                return defaultValue;

            //Match ma = Regex.Match(str, @"(\d+)");
            Match ma = Regex.Match(str, @"((-\s*)?\d+)");
            if (ma.Success) {
                return ma.Groups[1].Value.Replace(" ", "").ToInt(defaultValue);
            } else {
                return defaultValue;
            }
        }
        #endregion

        public static string SanitizePhoneNumber(this string value)
        {
            return new string(value.ToCharArray().Where(char.IsDigit).ToArray());
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        /* value = DateTime.Now */
        public static string GetTimestamp(DateTime value, string fmg = "yyyy-MM-dd HH:mm:ss.ffff")
        {
            return value.ToString(fmg);
        }
        public static string GetRandomString(int minLen, int maxLen, string chars = null)
        {
            Random generator = new Random();
            if (string.IsNullOrEmpty(chars))
            {
                chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            }
            string ret = "";
            char last = '0';
            while(ret.Length < maxLen)
            {
                int ind = generator.Next(0, chars.Length);
                if (last != chars[ind] || chars.Length < 2)
                {
                    last = chars[ind];
                    ret += last;
                }
                if(ret.Length >= minLen)
                {
                    ind = generator.Next(minLen, maxLen);
                    if(ind%3 == 0)
                    {
                        break;
                    }
                }
            }
            return ret;
        }
    }
}
