
namespace CRM_EngSystem_PostgreSQL.Data.Exceptions
{
    public sealed class BadQueryException : Exception
    {
        public BadQueryException(string typeName) : base(typeName){ }
    }
}
