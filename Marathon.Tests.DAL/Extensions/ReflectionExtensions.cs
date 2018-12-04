using System.Reflection;

namespace Marathon.Tests.DAL.Extensions
{
    // Source: https://stackoverflow.com/a/46488844
    internal static class ReflectionExtensions
    {
        internal static T GetFieldValue<T>(this object obj, string name)
        {
            // Set the flags so that private and public fields from instances will be found
            var bindingFlags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            var field = obj.GetType().GetField(name, bindingFlags);
            return (T)field?.GetValue(obj);
        }
    }
}
