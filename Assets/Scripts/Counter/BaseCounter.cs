using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCounter : MonoBehaviour, IKitchenObjectParent
{
    [SerializeField] protected Transform counterTopPoint;

    private KitchenObject kitchenObject;

    public virtual void Interact(Player play)
    {
        Debug.LogError("Interact函数在需要的柜台上未重写");
    }

    public virtual void InteractAlternaten(Player play)
    {
        Debug.LogError("InteractAlternaten函数在需要的柜台上未重写");
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
