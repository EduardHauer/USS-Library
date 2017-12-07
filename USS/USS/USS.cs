using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsingSystem
{
    public class Extra
    {
        Dictionary<string, object> data;
        List<string> names;

        public Extra()
        {
            data = new Dictionary<string, object>();
            names = new List<string>();
        }

        public object GetData(string name)
        {
            return data[name];
        }
        public object GetData(int index)
        {
            return data[names[index]];
        }

        public string GetName(int index)
        {
            return names[index];
        }

        public void Add(string name, object value)
        {
            data.Add(name, value);
            names.Add(name);
        }

        public int Count()
        {
            return names.Count;
        }
    }
    public class USS : Extra
    {
        public List<string> fS;

        public string name;

        public USS(string name)
        {
            this.name = name;
            fS = new List<string>();
        }

        public void GetStrings()
        {
            fS.Add($"%s uss {name}.uss = {'{'}");
            for (int i = 0; i < Count(); i++)
            {
                if (GetData(i).GetType() == typeof(string))
                {
                    char a = i != (Count() - 1) ? ',' : ' ';
                    fS.Add($"   {GetName(i)} = {'"'}{GetData(i)}{'"'}{a}");
                }
                else if (GetData(i).GetType() == typeof(int))
                {
                    char a = i != (Count() - 1) ? ',' : ' ';
                    fS.Add($"   {GetName(i)} = {GetData(i)}{a}");
                }
                else if (GetData(i).GetType() == typeof(UsingSystemFiles))
                {
                    fS.Add($"   {GetName(i)} = {'{'}");
                    List<string> fS2 = new List<string>();
                    fS2 = UsingSystemFiles.GetString((GetData(i) as UsingSystemFiles), 2);
                    for (int j = 0; j < fS2.Count; j++)
                    {
                        fS.Add(fS2[j]);
                    }
                    char a = i != (Count() - 1) ? ',' : ' ';
                    fS.Add($"   {'}'}{a}");
                }
            }
            fS.Add($"{'}'} %f");
        }
    }
    public class UsingSystemFiles : Extra
    {
        public UsingSystemFiles()
        {
        }

        public static List<string> GetString(UsingSystemFiles ussf, int lvl = 0)
        {
            List<string> str = new List<string>();
            string space = "";
            for (int i = 0; i < lvl; i++)
            {
                space += "   ";
            }
            for (int i = 0; i < ussf.Count(); i++)
            {
                if (ussf.GetData(i).GetType() == typeof(string))
                {
                    char a = i != (ussf.Count() - 1) ? ',' : ' ';
                    str.Add($"{space}{ussf.GetName(i)} = {'"'}{ussf.GetData(i)}{'"'}{a}");
                }
                else if (ussf.GetData(i).GetType() == typeof(int))
                {
                    char a = i != (ussf.Count() - 1) ? ',' : ' ';
                    str.Add($"{space}{ussf.GetName(i)} = {ussf.GetData(i)}{a}");
                }
                else if (ussf.GetData(i).GetType() == typeof(UsingSystemFiles))
                {
                    str.Add($"{space}{ussf.GetName(i)} = {'{'}");
                    List<string> str2 = new List<string>();
                    str2 = GetString((ussf.GetData(i) as UsingSystemFiles), lvl + 1);
                    for (int j = 0; j < str2.Count; j++)
                    {
                        str.Add(str2[j]);
                    }
                    char a = i != (ussf.Count() - 1) ? ',' : ' ';
                    str.Add($"{space}{'}'}{a}");
                }
            }
            return str;
        }
    }
}
