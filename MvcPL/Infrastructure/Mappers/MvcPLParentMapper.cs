using BLL.Interfacies.Entities;
using MvcPL.Models;

namespace MvcPL.Infrastructure.Mappers
{
    public static class MvcPLParentMapper
    {
        /// <summary>
        /// Read parent from database.
        /// </summary>
        /// <param name="parent">Parent</param>
        /// <returns>If empty parent return null, otherwise give informstion about parent.</returns>
        public static ParentEntity ToBllParent(this ParentModel parent)
        {
            if (parent == null) return null;
            return new ParentEntity
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

        public static ParentModel ToParentModel(this ParentEntity parent)
        {
            if (parent == null) return null;
            return new ParentModel
            {
                Id = parent.Id,
                IdUser = parent.IdUser,
                PlaceOfWork = parent.PlaceOfWork
            };
        }

    }
}
