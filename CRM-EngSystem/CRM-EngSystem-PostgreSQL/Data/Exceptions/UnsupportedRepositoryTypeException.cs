
namespace CRM_EngSystem_PostgreSQL.Data.Exceptions
{
    public sealed class UnsupportedRepositoryTypeException : Exception
    {
        public UnsupportedRepositoryTypeException(string typeName) : base(typeName){ }
    }
}
