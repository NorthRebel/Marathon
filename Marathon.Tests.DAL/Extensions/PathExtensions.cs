using System;
using System.IO;

namespace Marathon.Tests.DAL.Extensions
{
    /// <summary>
    /// Extensions for <see cref="Path"/>
    /// </summary>
    public static class PathExtensions
    {
        public static string GetAbsolutePath(string filePath)
        {
            var path = Path.IsPathRooted(filePath) ? filePath : Path.GetRelativePath(Directory.GetCurrentDirectory(), filePath);

            if (!File.Exists(path))
                throw new ArgumentException($"Could not find file at path: {path}");

            return path;
        }
    }
}
