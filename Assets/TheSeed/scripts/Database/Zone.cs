/*
 * A Zone definition
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using System;
using UnityEngine;

namespace TheSeed.Database
{
    /// <summary>
    /// A Zone definition to be stored in the database.
    /// </summary>
    [Serializable]
    public class Zone
    {
        /// <summary>
        /// The zone unique identifier.
        /// </summary>
        [SerializeField] private string uid { get; } = "ZONE_UID";
        
        /// <summary>
        /// The zone name.
        /// </summary>
        [SerializeField] private string name { get; } = "zone";
        
        /// <summary>
        /// The zone description.
        /// </summary>
        [SerializeField] private string description { get; } = "description";
        
    }
}
