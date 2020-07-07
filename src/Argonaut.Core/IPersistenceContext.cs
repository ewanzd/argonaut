using System;

namespace Argonaut.Core
{
    public interface IPersistenceContext : IDisposable
    {
        /// <summary>
        /// Save all changes made to repositories.
        /// </summary>
        int SaveChanges();
    }
}
