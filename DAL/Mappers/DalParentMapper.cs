using DAL.Interfacies.DTO;
using ORM;

namespace DAL.Mappers
{
    public static class DalParentMapper
    {
        /// <summary>
        /// Read parent from database.
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <returns>If empty parent return null, otherwise give informstion about parent.</returns>
        public static DalParent ToDalParent(this Parent parent)
        {
            if (parent == null) return null;
            return new DalParent
            {
                Id = parent.Id,
                PlaceOfWork = parent.PlaceOfWork,
                IdUser = parent.IdUser
            };
        }

        /// <summary>
        /// Write new parent in database.
        /// </summary>
        /// <param name="parent">Parent.</param>
        /// <returns>If empty parent return null, otherwise write new parent in database.</returns>

        public static Parent ToParent(this DalParent parent)
        {
            if (parent == null) return null;
            return new Parent
            {
                Id = parent.Id,
                IdUser = parent.IdUser,
                PlaceOfWork = parent.PlaceOfWork
            };
        }

    }
}
