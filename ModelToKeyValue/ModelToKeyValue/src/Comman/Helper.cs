namespace ModelToKeyValue.src.Comman
{
    internal static class Helper
    {
        /// <summary>
        /// get between two chars datas
        /// </summary>
        /// <param name="Begin">begin character</param>
        /// <param name="End">end character</param>
        /// <returns></returns>
        internal static string GetBetweenDatasRegex(char Begin,char End)
        {
            return $"[{Begin}].+[{End}]";
        }

        /// <summary>
        /// get between two words datas
        /// </summary>
        /// <param name="Begin">begin character</param>
        /// <param name="End">end character</param>
        /// <returns></returns>
        internal static string GetBetweenDatasRegex(string Begin, string End)
        {
            return $"[{Begin}].+[{End}]";
        }


    }
}
