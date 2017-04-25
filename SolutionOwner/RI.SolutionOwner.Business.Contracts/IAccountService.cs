//---------------------------------------------------------
// <copyright file="IAccountService.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using System.Collections.Generic;
using System.Threading.Tasks;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Business.Contracts
{
    /// <summary>
    /// The Account service abstraction.
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// Creates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The User entity.</returns>
        IUser CreateUser(IUser user);

        /// <summary>
        /// Creates the users.
        /// </summary>
        void CreateUsers();

        /// <summary>
        /// Gets all user.
        /// </summary>
        /// <returns>The collection of User.</returns>
        Task<IEnumerable<IUser>> GetAllUser();

        /// <summary>
        /// Gets the user by identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns>The User entity.</returns>
        Task<IUser> GetUserById(int id);

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The updation status.</returns>
        bool UpdateUser(IUser user);

        /// <summary>
        /// Deletes the user.
        /// </summary>
        /// <param name="user">The user.</param>
        /// <returns>The deletion status.</returns>
        bool DeleteUser(IUser user);
    }
}
