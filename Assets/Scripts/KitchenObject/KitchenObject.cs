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
        //开始时清除父对象对其的持有并且重新赋予新的父对象
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
    public IKitchenObjectParent GetKitchenObjectParent()
    {
        return kitchenObjectParent;
    }

    public void DestroySelf()
    {
        kitchenObjectParent.ClearKitchenObject();
        Destroy(gameObject);
    }

   /// <summary>
   /// 处理后替换物品
   /// </summary>
   /// <param name="kitchenObjectSO">新生成物品的SO</param>
   /// <param name="kitchenObjectParent">生成位置的父物体</param>
   /// <returns></returns>
    public static KitchenObject SpanwKitchenObject(KitchenObjectSO kitchenObjectSO, IKitchenObjectParent kitchenObjectParent)
    {
        Transform kitchenObjectTransfrom = Instantiate(kitchenObjectSO.prefab);
        KitchenObject kitchenObject = kitchenObjectTransfrom.GetComponent<KitchenObject>();
        kitchenObject.SetKitechenObjectParent(kitchenObjectParent);

        return kitchenObject;
    }
}
