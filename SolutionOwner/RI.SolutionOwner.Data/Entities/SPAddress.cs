//---------------------------------------------------------
// <copyright file="SPAddress.cs" company="RechargeIndia">
// All rights reserved. Copyright © 2017 RechargeIndia.
// </copyright>
//---------------------------------------------------------

using RI.Framework.Core.Data.Entities;
using RI.SolutionOwner.Data.Contracts;

namespace RI.SolutionOwner.Data.Entities
{
    /// <summary>
    /// class SPAddress
    /// </summary>
    public class SPAddress : BaseEntity, ISPAddress
    {
        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address { get; set; }

        /// <summary>
        /// Gets or sets the street.
        /// </summary>
        /// <value>
        /// The street.
        /// </value>
        public string Street { get; set; }

        /// <summary>
        /// Gets or sets the area.
        /// </summary>
        /// <value>
        /// The area.
        /// </value>
        public string Area { get; set; }

        /// <summary>
        /// Gets or sets the po box.
        /// </summary>
        /// <value>
        /// The po box.
        /// </value>
        public string POBox { get; set; }

        /// <summary>
        /// Gets or sets the zone.
        /// </summary>
        /// <value>
        /// The zone.
        /// </value>
        public string Zone { get; set; }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City { get; set; }

        /// <summary>
        /// Gets or sets the state.
        /// </summary>
        /// <value>
        /// The state.
        /// </value>
        public string State { get; set; }

        /// <summary>
        /// Gets or sets the country.
        /// </summary>
        /// <value>
        /// The country.
        /// </value>
        public string Country { get; set; }

        /// <summary>
        /// Gets or sets the time zone.
        /// </summary>
        /// <value>
        /// The time zone.
        /// </value>
        public string TimeZoneId { get; set; }

        /// <summary>
        /// Gets or sets the NFC.
        /// </summary>
        /// <value>
        /// The NFC.
        /// </value>
        public string NFC { get; set; }

        /// <summary>
        /// Gets or sets the contact person.
        /// </summary>
        /// <value>
        /// The contact person.
        /// </value>
        public string ContactPerson { get; set; }

        /// <summary>
        /// Gets or sets the mobile number.
        /// </summary>
        /// <value>
        /// The mobile number.
        /// </value>
        public string MobileNumber { get; set; }

        /// <summary>
        /// Gets or sets the contact person email.
        /// </summary>
        /// <value>
        /// The contact person email.
        /// </value>
        public string ContactPersonEmail { get; set; }

        /// <summary>
        /// Gets or sets the so solution partner.
        /// </summary>
        /// <value>
        /// The so solution partner.
        /// </value>
        public virtual SOSolutionPartner SOSolutionPartner { get; set; }
    }
}
