/*
 * An Item definition
 *
 * Author: Pebloop
 * Date: 2023-02-05
 * 
 */

using System;
using UnityEngine;
using UnityEngine.Events;

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
        [SerializeField] private string uid = "ITEM";
        
        /// <summary>
        /// The item name.
        /// </summary>
        [SerializeField] private string name = "Item";
        
        /// <summary>
        /// The item description.
        /// </summary>
        [SerializeField] private string description = "Item Description";
        
        /// <summary>
        /// The item icon.
        /// </summary>
        [SerializeField] private Sprite icon;
        
        /// <summary>
        /// The item prefab.
        /// </summary>
        [SerializeField] private GameObject prefab;

        /// <summary>
        /// Is the item stackable?
        /// </summary>
        [SerializeField] private bool isStackable;
        
        /// <summary>
        /// How much the item can be stacked.
        /// </summary>
        [SerializeField] private int maxStack = 1;
        
        /// <summary>
        /// Is the item usable?
        /// </summary>
        [SerializeField] private bool isConsumable;
        
        /// <summary>
        /// Does the item disappear when consumed ?
        /// </summary>
        [SerializeField] private bool disappearWhenConsumed;
        
        /// <summary>
        /// Action to perform when the item is consumed.
        /// </summary>
        [SerializeField] private UnityEvent use;
        
        // Getters
        public string Uid => uid;
        public string Name => name;
        public string Description => description;
        public Sprite Icon => icon;
        public GameObject Prefab => prefab;
        public bool IsStackable => isStackable;
        public int MaxStack => maxStack;
        public bool IsConsumable => isConsumable;
        public bool DisappearWhenConsumed => disappearWhenConsumed;
        public UnityEvent Use => use;
        
        // Setters
        public void SetUid(string mUid) => this.uid = mUid;
        public void SetName(string mName) => this.name = mName;
        public void SetDescription(string mDescription) => this.description = mDescription;
        public void SetIcon(Sprite mIcon) => this.icon = mIcon;
        public void SetPrefab(GameObject mPrefab) => this.prefab = mPrefab;
        public void SetIsStackable(bool mIsStackable) => this.isStackable = mIsStackable;
        public void SetMaxStack(int mMaxStack) => this.maxStack = mMaxStack;
        public void SetIsConsumable(bool mIsConsumable) => this.isConsumable = mIsConsumable;
        public void SetDisappearWhenConsumed(bool mDisappearWhenConsumed) => this.disappearWhenConsumed = mDisappearWhenConsumed;
        public void SetUse(UnityEvent mUse) => this.use = mUse;


    }
}
