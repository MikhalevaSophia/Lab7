using library;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;

namespace lab7
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly assembly = Assembly.Load(new AssemblyName("animals"));
            void AppendXML(string output)
            {
                File.AppendAllText("AssemblyIfo.xml", output + "\n");
            }
            File.Delete("AssemblyInfo.xml");
            AppendXML("<animals>");
            AppendXML(assembly.FullName);

            foreach(Type type in assembly.ExportedTypes)
            {
                if (type.GetTypeInfo().IsClass)
                {
                    AppendXML($"\n<class> {type.Name} : {type.BaseType}");//информация о классе 
                    IEnumerable<CommentAttribute> attributes = type.GetTypeInfo()
                                                                   .GetCustomAttribute()
                                                                   .OfType<CommentAttribute>().ToArray;//считывание комментов
                    if(attributes.Count() > 0)//вывод комментариев
                    {
                        foreach(CommentAttribute attribute in  attributes)
                        {
                            AppendXML($"<comment>{attribute.Comment}</comment>");
                        }
                    }
                    foreach(MethodInfo method in type.GetMethods())
                    {
                        AppendXML($"<method>{(method.IsStatic ? "static" : "")}{(method.IsVirtual ? "virtual" : "")}{method.ReturnType.Name} {method.Name}()</method>");
                    }
                    AppendXML("</class>");
                }
            }
            AppendXML("</amimals>");
        }
    }
}