namespace Argonaut.Core
{
    public interface ISaveService
    {
        /// <summary>
        /// Save all changes made to repositories.
        /// </summary>
        int SaveChanges();
    }
}
