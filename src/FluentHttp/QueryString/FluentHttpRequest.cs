﻿namespace FluentHttp
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics.CodeAnalysis;
    using System.Diagnostics.Contracts;

    [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1601:PartialElementsMustBeDocumented",
        Justification = "Reviewed. Suppression is OK here.")]
    public partial class FluentHttpRequest
    {
        /// <summary>
        /// Internal list of http querystrings.
        /// </summary>
        private FluentQueryStrings httpQueryStrings;

        /// <summary>
        /// Gets the http querystrings.
        /// </summary>
        [ContractVerification(true)]
        private FluentQueryStrings HttpQueryStrings
        {
            get
            {
                Contract.Ensures(Contract.Result<FluentQueryStrings>() != null);

                return this.httpQueryStrings ?? (this.httpQueryStrings = new FluentQueryStrings());
            }
        }

        /// <summary>
        /// Access querystrings.
        /// </summary>
        /// <param name="queryStrings">
        /// The querystrings.
        /// </param>
        /// <returns>
        /// Returns <see cref="FluentHttpRequest"/>.
        /// </returns>
        [ContractVerification(true)]
        public FluentHttpRequest QueryStrings(Action<FluentQueryStrings> queryStrings)
        {
            Contract.Ensures(Contract.Result<FluentHttpRequest>() != null);

            if (queryStrings != null)
                queryStrings(this.HttpQueryStrings);

            return this;
        }

        /// <summary>
        /// Gets the querystrings.
        /// </summary>
        /// <returns>
        /// Returns <see cref="FluentQueryStrings"/>.
        /// </returns>
        [ContractVerification(true)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public FluentQueryStrings GetQueryStrings()
        {
            Contract.Ensures(Contract.Result<FluentQueryStrings>() != null);

            return this.HttpQueryStrings;
        }
    }
}