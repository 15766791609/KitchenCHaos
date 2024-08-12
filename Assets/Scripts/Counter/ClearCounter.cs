using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] protected KitchenObjectSO kitchenObjectSO;
    public override void Interact(Player player)
    {
        if (!HasKitchenObjetc())
        //当柜台上没有物品时
        {
            if (player.HasKitchenObjetc())
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
                //玩家手中拿的是盘子
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                        GetKitchenObject().DestroySelf();
                }
                else
                {
                    //玩家手里拿的不是盘子,即判断柜台上是是不是盘子
                    if(GetKitchenObject().TryGetPlate(out plateKitchenObject))
                    {
                        if (plateKitchenObject.TryAddIngredient(player.GetKitchenObject().GetKitchenObjectSO()))
                            player.GetKitchenObject().DestroySelf();
                    }
                }
            }
            else
            //玩家手中没有物品
            {
                GetKitchenObject().SetKitechenObjectParent(player);
            }
        }
    }
}
