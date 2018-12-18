using System;

namespace Troikatorz.Speech.Helpers
{
    public static class Files
    {
        public static bool IsValidRelativePath(string path) => Uri.IsWellFormedUriString(path, UriKind.Relative);
    }
}
