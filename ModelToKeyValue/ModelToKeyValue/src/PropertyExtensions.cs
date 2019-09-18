using ModelToKeyValue.src.Comman;
using System;
using collection = System.Collections;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using ModelToKeyValue.src.Exceptions;
using System.Text.RegularExpressions;

namespace ModelToKeyValue.src
{
    internal static class PropertyExtensions
    {
        /// <summary>
        /// Check for propertyinfo has attribute or not
        /// </summary>
        /// <typeparam name="T">Attribute type</typeparam>
        /// <param name="property">Property info</param>
        /// <returns>boolean</returns>
        internal static bool HasAttribute<T>(this PropertyInfo propertyInfo) where T : Attribute
        {
            if (propertyInfo == null)
                throw new NullReferenceException(StaticDatas.PropertyNullMessage);

            return propertyInfo.GetCustomAttribute(typeof(T), false) == null ? false : true;
        }

        /// <summary>
        /// checks type is nested or not
        /// </summary>
        /// <param name="property">propertyinfo</param>
        /// <returns>boolean</returns>
        internal static bool IsComplex(this Type typ)
        {
            if (typ == null)
                throw new NullReferenceException(StaticDatas.PropertyNullMessage);

            if (typ.IsEnum)
                return false;

            switch (typ.FullName)
            {
                case "System.String":
                    return false;
                case "System.Guid":
                    return false;
                case "System.DateTime":
                    return false;
                case "System.Int64":
                    return false;
                case "System.Int32":
                    return false;
                case "System.Int16":
                    return false;
                case "System.Byte":
                    return false;
                case "System.SByte":
                    return false;
                case "System.Decimal":
                    return false;
                case "System.Double":
                    return false;
                default:
                    return true;
            }
        }

        /// <summary>
        /// checks type is collection or not
        /// </summary>
        /// <param name="property"></param>
        /// <returns></returns>
        internal static bool IsCollection(this object value)
        {
            return (value is collection.IEnumerable && !(value is string));
        }

        /// <summary>
        /// Searches the specified input string for all occurrences of a specified regular
        /// expression
        /// <param name="str">word</param>
        /// <param name="regex">regular expression pattern</param>
        /// <returns>ienumerable string collection</returns>
        internal static IEnumerable<string> GetMathces(this string str, string regex)
        {
            if (string.IsNullOrEmpty(str))
                throw new NullReferenceException(StaticDatas.StringNullMessage);

            if (string.IsNullOrEmpty(regex))
                throw new InvalidRegexException(StaticDatas.PatternNullMessage);

            return Regex.Matches(str, regex).OfType<Match>().Select(x => x.Groups[0].Value);
        }
    }
}
