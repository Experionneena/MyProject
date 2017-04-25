using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace RI.SolutionOwner.WebAPI.Areas.HelpPage.ModelDescriptions
{
    /// <summary>
    /// EnumTypeModelDescription class.
    /// </summary>
    public class EnumTypeModelDescription : ModelDescription
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumTypeModelDescription" /> class.
        /// </summary>
        public EnumTypeModelDescription()
        {
            Values = new Collection<EnumValueDescription>();
        }

        /// <summary>
        /// Gets the values.
        /// </summary>
        /// <value>
        /// The values.
        /// </value>
        public Collection<EnumValueDescription> Values { get; private set; }
    }
}