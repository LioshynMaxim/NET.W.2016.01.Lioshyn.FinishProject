using BLL.Interfacies.Entities;
using DAL.Interfacies.DTO;

namespace BLL.Mappers
{
    public static class BllParentMapper
    {
        /// <summary>
        /// Read parent from database.
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <returns>If empty parent return null, otherwise give informstion about parent.</returns>
        public static DalParent ToDalParent(this ParentEntity parent)
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

        public static ParentEntity ToParent(this DalParent parent)
        {
            if (parent == null) return null;
            return new ParentEntity
            {
                IdUser = parent.IdUser,
                PlaceOfWork = parent.PlaceOfWork
            };
        }

    }
}
