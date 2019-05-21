using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;

namespace uuUtils
{
    public class Cfg
    {
        static public bool IsDebug { get { return true; } }
        static protected Cfg _maincfg;
        static public Cfg MainCfg
        {
            get
            {
                if(_maincfg == null)
                {
                    _maincfg = new Cfg();
                    _maincfg.Load("g_maincfg.ini");
                }
                return _maincfg;
            }
        }
        //saved even App died!
        static public object SessionGet(string key, object defValue)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return Application.Current.Properties[key];
            }
            return defValue;
        }
        static public string SessionGet(string key, string defValue)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return Application.Current.Properties[key].ToString();
            }
            return defValue;
        }
        static public int SessionGet(string key, int defValue)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return Application.Current.Properties[key].ToString().ToInt();
            }
            return defValue;
        }
        static public bool SessionGet(string key, bool defValue)
        {
            if (Application.Current.Properties.ContainsKey(key))
            {
                return "1".Equals(Application.Current.Properties[key]);
            }
            return defValue;
        }
        static public void SessionSet(string key, string value)
        {
            Application.Current.Properties[key] = value;
        }
        static public void SessionSet(string key, object value)
        {
            Application.Current.Properties[key] = value;
        }
        static public void SessionSet(string key, int value)
        {
            Application.Current.Properties[key] = value;
        }
        static public void SessionSet(string key, bool value)
        {
            Application.Current.Properties[key] = value ? "1" : "0";
        }
        //empty key for remove all!
        static public void SessionClear(string key = null)
        {
            if(!string.IsNullOrEmpty(key))
            {
                Application.Current.Properties.Remove(key);
            }
            else
            {
                Application.Current.Properties.Clear();
            }
        }

        public Cfg()
        {
        }
        public Cfg(string fname)
        {
            Load(fname);
        }

        protected Dictionary<string, string> _ini = new Dictionary<string, string>();
        protected bool _isDirty = false;
        public bool IsDirty { get { return _isDirty; } }
        public string Get(string key)
        {
            return Get(key, null);
        }
        public string Get(string key, string defValue = null)
        {
            if (!_ini.ContainsKey(key))
            {
                return defValue;
            }
            return _ini[key];
        }
        public int Get(string key, int defValue = 0)
        {
            if (!_ini.ContainsKey(key))
            {
                return defValue;
            }
            return _ini[key].ToInt();
        }
        public bool Get(string key, bool defValue = false)
        {
            if (!_ini.ContainsKey(key))
            {
                return defValue;
            }
            return _ini[key] == "1";
        }
        public void Set(string key, string value)
        {
            Debug.Assert(key != null);
            if (!_ini.ContainsKey(key) || _ini[key] != value)
            {
                _ini[key] = value;
                _isDirty = true;
            }
        }
        public void Set(string key, bool value)
        {
            Debug.Assert(key != null);
            string svalue = value ? "1" : "0";
            if (!_ini.ContainsKey(key) || _ini[key] != svalue)
            {
                _ini[key] = svalue;
                _isDirty = true;
            }
        }
        public void Set(string key, int value)
        {
            Debug.Assert(key != null);
            string svalue = "" + value;
            if (!_ini.ContainsKey(key) || _ini[key] != svalue)
            {
                _ini[key] = svalue;
                _isDirty = true;
            }
        }
        public bool Exist(string key)
        {
            return _ini[key].Contains(key);
        }
        public IReadOnlyDictionary<string, string> Cfgs { get { return _ini; } }

        protected string _filename;
        public bool Load(string fname)
        {
            _filename = fname;
            _ini.Clear();
            string sTxt = FileUtils.FRead(fname);
            if(sTxt != null)
            {
                string[] sTxtArr = sTxt.Split('\n');
                for(int n = 0; n < sTxtArr.Length; n++)
                {
                    string str = sTxtArr[n];
                    int pos = str.IndexOf("=");
                    if(pos > 0)
                    {
                        string val = str.Substring(pos + 1).Replace("\\n", "\n");
                        _ini[str.Substring(0, pos)] = val;
                    }
                }
            }
            _isDirty = false;
            return true;
        }

        public bool Save(bool isForce = false)
        {
            Debug.Assert(!string.IsNullOrEmpty(_filename));
            if(string.IsNullOrEmpty(_filename))
            {
                throw new Exception("filename is not defined.");
            }
            if (isForce || _isDirty)
            {
                string sTxt = "";
                foreach (var item in _ini)
                {
                    string val = item.Value.Replace("\n", "\\n");
                    sTxt += item.Key + "=" + val + "\n";
                }
                FileUtils.FWrite(_filename, sTxt);
            }
            _isDirty = false;
            return true;
        }
        public bool SaveAs(string fname)
        {
            _filename = fname;
            string sTxt = "";
            foreach (var item in _ini)
            {
                string val = item.Value.Replace("\n", "\\n");
                sTxt += item.Key + "=" + val + "\n";
            }
            FileUtils.FWrite(fname, sTxt);
            _isDirty = false;
            return true;
        }
    }
}

