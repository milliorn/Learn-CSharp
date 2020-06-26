using System;

namespace UtilityLibraries
{
    public static class StringLibrary
    {
        public static bool StartsWithUpper(this string str) => !string.IsNullOrWhiteSpace(str) && char.IsUpper(str[0]);
    }
}
