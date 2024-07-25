using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if(!HasKitchenObjetc())
        //当柜台上没有物品时
        {
            if(player.HasKitchenObjetc())
            //玩家手中持有物品
            {
                player.GetKitchenObject().SetKitechenObjectParent(this);
            }
            else
            //玩家手中没有物品
            {

            }
        }
        else
        //当柜台上存在物品时
        {
            if (player.HasKitchenObjetc())
            //玩家手中持有物品
            {
            }
            else
            //玩家手中没有物品
            {
                GetKitchenObject().SetKitechenObjectParent(player);
            }
        }
    }
}
