using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCounter : MonoBehaviour,IKitchenObjectParent
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;
    [SerializeField] private Transform counterTopPoint;

    private KitchenObject kitchenObject;
    public void Interact(Player playr)
    {
        //��ֹ�ظ�����
        if (kitchenObject == null)
        {
            Transform kitchenObjectTranform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObject = kitchenObjectTranform.GetComponent<KitchenObject>();
        }
        else
        {
            kitchenObject.SetKitechenObjectParent(playr);
        }

    }

    public Transform GetKitchenObjectFollowTransrom()
    {
        return counterTopPoint;
    }

    public void SetKitchenObject(KitchenObject kitchenObject)
    {
        this.kitchenObject = kitchenObject;
    }

    public KitchenObject GetKitchenObject()
    {
        return kitchenObject;
    }
    public void ClearKitchenObject()
    {
        kitchenObject = null;
    }
    public bool HasKitchenObjetc()
    {
        return (kitchenObject != null);
    }

}
