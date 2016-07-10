// Code generated by Microsoft (R) AutoRest Code Generator 0.16.0.0
// Changes may cause incorrect behavior and will be lost if the code is
// regenerated.

namespace Pinnacle.ResponsibleGaming.ApiClient
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Rest;
    using Models;

    /// <summary>
    /// Extension methods for DepositLimit.
    /// </summary>
    public static partial class DepositLimitExtensions
    {
            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customerId'>
            /// </param>
            public static object Get(this IDepositLimit operations, string customerId)
            {
                return Task.Factory.StartNew(s => ((IDepositLimit)s).GetAsync(customerId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customerId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> GetAsync(this IDepositLimit operations, string customerId, CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.GetWithHttpMessagesAsync(customerId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customerId'>
            /// </param>
            /// <param name='requestamount'>
            /// </param>
            /// <param name='requestperiodInDays'>
            /// </param>
            /// <param name='requeststartDate'>
            /// </param>
            /// <param name='requestendDate'>
            /// </param>
            /// <param name='requestauthor'>
            /// </param>
            /// <param name='requestcustomerId'>
            /// </param>
            public static object Set(this IDepositLimit operations, string customerId, double? requestamount = default(double?), int? requestperiodInDays = default(int?), DateTime? requeststartDate = default(DateTime?), DateTime? requestendDate = default(DateTime?), string requestauthor = default(string), string requestcustomerId = default(string))
            {
                return Task.Factory.StartNew(s => ((IDepositLimit)s).SetAsync(customerId, requestamount, requestperiodInDays, requeststartDate, requestendDate, requestauthor, requestcustomerId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customerId'>
            /// </param>
            /// <param name='requestamount'>
            /// </param>
            /// <param name='requestperiodInDays'>
            /// </param>
            /// <param name='requeststartDate'>
            /// </param>
            /// <param name='requestendDate'>
            /// </param>
            /// <param name='requestauthor'>
            /// </param>
            /// <param name='requestcustomerId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> SetAsync(this IDepositLimit operations, string customerId, double? requestamount = default(double?), int? requestperiodInDays = default(int?), DateTime? requeststartDate = default(DateTime?), DateTime? requestendDate = default(DateTime?), string requestauthor = default(string), string requestcustomerId = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.SetWithHttpMessagesAsync(customerId, requestamount, requestperiodInDays, requeststartDate, requestendDate, requestauthor, requestcustomerId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customerId'>
            /// </param>
            /// <param name='requestauthor'>
            /// </param>
            /// <param name='requestcustomerId'>
            /// </param>
            public static object Disable(this IDepositLimit operations, string customerId, string requestauthor = default(string), string requestcustomerId = default(string))
            {
                return Task.Factory.StartNew(s => ((IDepositLimit)s).DisableAsync(customerId, requestauthor, requestcustomerId), operations, CancellationToken.None, TaskCreationOptions.None, TaskScheduler.Default).Unwrap().GetAwaiter().GetResult();
            }

            /// <param name='operations'>
            /// The operations group for this extension method.
            /// </param>
            /// <param name='customerId'>
            /// </param>
            /// <param name='requestauthor'>
            /// </param>
            /// <param name='requestcustomerId'>
            /// </param>
            /// <param name='cancellationToken'>
            /// The cancellation token.
            /// </param>
            public static async Task<object> DisableAsync(this IDepositLimit operations, string customerId, string requestauthor = default(string), string requestcustomerId = default(string), CancellationToken cancellationToken = default(CancellationToken))
            {
                using (var _result = await operations.DisableWithHttpMessagesAsync(customerId, requestauthor, requestcustomerId, null, cancellationToken).ConfigureAwait(false))
                {
                    return _result.Body;
                }
            }

    }
}