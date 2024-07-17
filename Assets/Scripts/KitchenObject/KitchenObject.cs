using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private IKitchenObjectParent kitchenObjectParent;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetKitechenObjectParent(IKitchenObjectParent kitchentObjectParent)
    {
        //��ʼʱ�������ָ������Ʒ�������¸���
        if (this.kitchenObjectParent != null)
        {
            this.kitchenObjectParent.ClearKitchenObject();
        }
        this.kitchenObjectParent = kitchentObjectParent;
        kitchentObjectParent.SetKitchenObject(this);

        if(kitchentObjectParent.HasKitchenObjetc())
        {
            Debug.Log("kitchentObjectParent alerady has aa kitchenObject");
        }

        transform.parent = kitchentObjectParent.GetKitchenObjectFollowTransrom();
        transform.localPosition = Vector3.zero;
    }
    public IKitchenObjectParent GetKitchenObjectParen()
    {
        return kitchenObjectParent;
    }
}
