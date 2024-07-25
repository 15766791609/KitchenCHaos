using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class ContainerCounter : BaseCounter
{
    //抓取事件
    public event EventHandler OnPlayerGrabbedObject;

    [SerializeField] protected KitchenObjectSO kitchenObjectSO;

    public override void Interact(Player playr)
    {
        if(!playr.HasKitchenObjetc())
        {
            KitchenObject.SpanwKitchenObject(kitchenObjectSO, playr);

            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        
    }
}
