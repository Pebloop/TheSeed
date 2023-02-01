/*
 * The game database
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using System.Collections.Generic;
using UnityEngine;

namespace TheSeed.Database
{
    /// <summary>
    /// The game database
    /// </summary>
    public class DataBase : MonoBehaviour
    {
        /// <summary>
        /// The database instance
        /// </summary>
        public static DataBase Instance;

        /// <summary>
        /// All the items in the database
        /// </summary>
        public List<Item> items = new List<Item>();
        
        /// <summary>
        /// All the quests in the database.
        /// </summary>
        public List<Quest> quests = new List<Quest>();
        
    }
}
