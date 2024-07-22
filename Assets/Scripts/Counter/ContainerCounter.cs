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
        Transform kitchenObjectTranform = Instantiate(kitchenObjectSO.prefab);
        kitchenObjectTranform.GetComponent<KitchenObject>().SetKitechenObjectParent(playr);

        OnPlayerGrabbedObject?.Invoke(this,EventArgs.Empty);
    }
}
