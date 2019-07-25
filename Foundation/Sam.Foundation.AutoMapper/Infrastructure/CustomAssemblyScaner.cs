using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Sam.Foundation.AutoMapper.Infrastructure
{
    public static class CustomAssemblyScaner
    {
        private static List<string> assemblyFilters = new List<string> { "*.Feature.*", "*.Foundation.*", "*.ToolStockSc.*" };

        public static Assembly[] GetAssemblies()
        {
            var assemblies = new List<Assembly>();

            foreach (var assemblyFilter in assemblyFilters)
            {
                assemblies.AddRange(AppDomain.CurrentDomain.GetAssemblies()
                    .Where(assembly => IsWildcardMatch(assembly.GetName().Name, assemblyFilter)).ToArray());
            }

            return assemblies.ToArray();
        }

        private static bool IsWildcardMatch(string input, string wildcard)
        {
            return input == wildcard
                || Regex.IsMatch(input, "^" + Regex.Escape(wildcard).Replace("\\*", ".*").Replace("\\?", ".") + "$", RegexOptions.IgnoreCase);
        }
    }
}