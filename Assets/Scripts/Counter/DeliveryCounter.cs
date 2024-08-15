using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryCounter : BaseCounter
{
    public override void Interact(Player play)
    {
        if(play.HasKitchenObjetc())
        {
            //��������������������
            if(play.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
            {
                play.GetKitchenObject().DestroySelf();
            }
        }
    }
}
