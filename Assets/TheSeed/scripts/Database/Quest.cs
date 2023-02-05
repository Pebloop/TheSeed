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
        [SerializeField] private string uid = "QUEST";
        
        /// <summary>
        /// The quest name.
        /// </summary>
        [SerializeField] private string name = "Quest";
        
        /// <summary>
        /// The zone description.
        /// </summary>
        [SerializeField] private string description = "DESCRIPTION";
        
        // getters
        public string Uid => uid;
        public string Name => name;
        public string Description => description;
        
        // setters
        public void SetUid(string mUid) => this.uid = uid;
        public void SetName(string mName) => this.name = name;
        public void SetDescription(string mDescription) => this.description = description;
        
    }
}
