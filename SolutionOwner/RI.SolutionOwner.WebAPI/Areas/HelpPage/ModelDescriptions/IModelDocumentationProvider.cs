using System;
using System.Reflection;

namespace RI.SolutionOwner.WebAPI.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// IModelDocumentationProvider interface.
    /// </summary>
    public interface IModelDocumentationProvider
    {
        /// <summary>
        /// Gets the documentation.
        /// </summary>
        /// <param name="member">The member.</param>
        /// <returns>returns string.</returns>
        string GetDocumentation(MemberInfo member);

        /// <summary>
        /// Gets the documentation.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <returns>returns string.</returns>
        string GetDocumentation(Type type);
    }
}