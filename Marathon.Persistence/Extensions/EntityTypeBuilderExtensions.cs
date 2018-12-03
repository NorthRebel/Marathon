using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Marathon.Persistence.Extensions
{
    /// <summary>
    /// Extension methods for <see cref="EntityTypeBuilder"/> and inner types
    /// </summary>
    /// <remarks>
    /// Intended for Microsoft SQL Server (version 2008 and above)
    /// </remarks>
    public static class EntityTypeBuilderExtensions
    {
        /// <summary>
        /// Set decimal column type with precision for entity property
        /// </summary>
        /// <param name="propertyBuilder">Current property</param>
        /// <param name="precision">Maximum number of digits that are present in the number</param>
        /// <param name="scale">Maximum number of decimal places</param>
        // TODO: Needs to remove them by follow DRY
        public static PropertyBuilder<decimal?> DecimalPrecision(this PropertyBuilder<decimal?> propertyBuilder, byte precision, byte scale)
        {
            return propertyBuilder.HasColumnType($"decimal({precision},{scale})");
        }

        /// <summary>
        /// Set decimal column type with precision for entity property
        /// </summary>
        /// <param name="propertyBuilder">Current property</param>
        /// <param name="precision">Maximum number of digits that are present in the number</param>
        /// <param name="scale">Maximum number of decimal places</param>
        public static PropertyBuilder<decimal> DecimalPrecision(this PropertyBuilder<decimal> propertyBuilder, byte precision, byte scale)
        {
            return propertyBuilder.HasColumnType($"decimal({precision},{scale})");
        }

        /// <summary>
        /// Set varbinary column type for binary entity property
        /// </summary>
        /// <param name="propertyBuilder">Current property</param>
        /// <param name="maxBytesLimit">Data space limit in bytes</param>
        /// <param name="extended">Limit by file system</param>
        public static PropertyBuilder<byte[]> HasVarbinaryType(this PropertyBuilder<byte[]> propertyBuilder, long? maxBytesLimit = null, bool extended = false)
        {
            // Extended option doesn't have limits
            if (extended)
                maxBytesLimit = null;

            return propertyBuilder.HasColumnType($"varbinary({(maxBytesLimit.HasValue ? maxBytesLimit.Value.ToString() : "max")}) {(extended ? "FILESTREAM" : "")}");
        }

        /// <summary>
        /// Set char column type for string entity property
        /// </summary>
        /// <param name="propertyBuilder">Current property</param>
        /// <param name="maxLength">Max fixed length</param>
        public static PropertyBuilder<string> HasCharType(this PropertyBuilder<string> propertyBuilder, long maxLength)
        {
            return propertyBuilder.HasColumnType($"char({maxLength})");
        }
    }
}
