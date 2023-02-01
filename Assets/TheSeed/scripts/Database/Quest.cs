/*
 * A Quest definition
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
    /// A Quest definition to be stored in the database.
    /// </summary>
    [Serializable]
    public class Quest
    {
        /// <summary>
        /// The quest unique identifier.
        /// </summary>
        [SerializeField] private string uid { get; } = "QUEST";
        
        /// <summary>
        /// The quest name.
        /// </summary>
        [SerializeField] private string name { get; } = "Quest";
        
        /// <summary>
        /// The zone description.
        /// </summary>
        [SerializeField] private string description { get; } = "DESCRIPTION";
    

    }
}