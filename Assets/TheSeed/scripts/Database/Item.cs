/*
 * An Item definition
 *
 * Author: Pebloop
 * Date: 2023-02-01
 * 
 */

using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace TheSeed.Database
{
    /// <summary>
    ///  An Item definition to be stored in the database.
    /// </summary>
    [Serializable]
    public class Item
    {
        /// <summary>
        /// The item unique identifier.
        /// </summary>
        [SerializeField] private string uid { get; } = "ITEM";
        
        /// <summary>
        /// The item name.
        /// </summary>
        [SerializeField] private string name { get; } = "Item";
        
        /// <summary>
        /// The item description.
        /// </summary>
        [SerializeField] private string description { get; } = "Item Description";
        
        /// <summary>
        /// The item icon.
        /// </summary>
        [SerializeField] private Sprite icon { get; } = null;
        
        /// <summary>
        /// The item prefab.
        /// </summary>
        [SerializeField] private GameObject prefab { get; } = null;

        /// <summary>
        /// Is the item stackable?
        /// </summary>
        [SerializeField] private bool isStackable { get; } = false;
        
        /// <summary>
        /// How much the item can be stacked.
        /// </summary>
        [SerializeField] private int maxStack { get; } = 1;
        
        /// <summary>
        /// Is the item usable?
        /// </summary>
        [SerializeField] private bool isConsumable { get; } = false;
        
        /// <summary>
        /// Does the item disapear when consumed ?
        /// </summary>
        [SerializeField] private bool disapearWhenConsumed { get; } = false;
        
        /// <summary>
        /// Action to perform when the item is consumed.
        /// </summary>
        [SerializeField] private UnityEvent onUse { get; } = null;

    }
}
