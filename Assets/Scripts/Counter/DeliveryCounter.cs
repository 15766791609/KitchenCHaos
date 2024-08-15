using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player play)
    {
        if(play.HasKitchenObjetc())
        {
            //如果玩家拿着盘子则销毁
            if(play.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                play.GetKitchenObject().DestroySelf();
            }
        }
    }
}
