/*
 * A Monster definition
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
    /// A Monster definition to be stored in the database.
    /// </summary>
    [Serializable]
    public class Monster
    {
        /// <summary>
        /// The monster unique identifier.
        /// </summary>
        [SerializeField] private string uid { get; } = "MONSTER";

    }
}
