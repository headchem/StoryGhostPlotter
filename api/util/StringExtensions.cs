public static class StringExtensions
    {
        ///<summary>Given a string (or null), if the string has a value and has more characters than Length, then it is truncated to the specified Length, otherwise the original string is returned.</summary>
        public static string Truncate(this string variable, int Length)
        {
            if (string.IsNullOrEmpty(variable)) return variable;
            return variable.Length <= Length ? variable : variable.Substring(0, Length);
        }
    }