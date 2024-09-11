using ContosoPizza.Constansts;

namespace ContosoPizza.Shared.Extensions
{
    public static class AddEntityMetadataExtensions
    {
        public static void SetCreatedEntityMetadata<T>(this T entity, IHttpContextAccessor httpContextAccessor)
        {
            var dateTimeProperty = entity?.GetType().GetProperty(FieldConstants.CREATEDDATEFIELD);
            dateTimeProperty?.SetValue(entity, DateTime.Now);
            var createdByProperty = entity?.GetType().GetProperty(FieldConstants.CREATEDBYFIELD);
            var user = httpContextAccessor.HttpContext.GetUserCredential();
            createdByProperty?.SetValue(entity, user?.Id);
        }
        public static void SetModifiedEntityMetadata<T>(this T entity, IHttpContextAccessor httpContextAccessor)
        {
            var dateTimeProperty = entity?.GetType().GetProperty(FieldConstants.MODIFIEDDATEFIELD);
            dateTimeProperty?.SetValue(entity, DateTime.Now);
            var createdByProperty = entity?.GetType().GetProperty(FieldConstants.MODIFIEDBYFIELD);
            var user = httpContextAccessor.HttpContext.GetUserCredential();
            createdByProperty?.SetValue(entity, user?.Id);
        }
    }
}
