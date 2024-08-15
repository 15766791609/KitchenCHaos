using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlateKitchenObject : KitchenObject
{/// <summary>
/// 添加新的物品到盘子上时
/// </summary>
    public event EventHandler<OnTngredientAddedEventArgs> OnIngredientAdded;
    public class OnTngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private KitchenObjectListSO validkitchenObjectSoList;
    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    /// <summary>
    /// 添加菜单SO
    /// </summary>
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validkitchenObjectSoList.kitchenObjectList.Contains(kitchenObjectSO))
            //不在可以装盘的物品列表内
            return false;
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //已经放过该物品了
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnTngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });


            return true;
        }
    }

    public List<KitchenObjectSO> GetKitchenObjectSOList()
    {
        return kitchenObjectSOList;
    }
}
