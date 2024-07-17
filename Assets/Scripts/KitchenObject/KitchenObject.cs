using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] private KitchenObjectSO kitchenObjectSO;

    private ClearCounter clearCounter;

    public KitchenObjectSO GetKitchenObjectSO()
    {
        return kitchenObjectSO;
    }

    public void SetClearCounter(ClearCounter clearCounter)
    {
        //��ʼʱ�������ָ������Ʒ�������¸���
        if (this.clearCounter != null)
        {
            this.clearCounter.ClearKitchenObject();
        }
        this.clearCounter = clearCounter;
        clearCounter.SetKitchenObject(this);

        if(clearCounter.HasKitchenObjetc())
        {
            Debug.Log("Counter alerady has aa kitchenObject");
        }

        transform.parent = clearCounter.GetKitchenObjectFollowTransrom();
        transform.localPosition = Vector3.zero;
    }
    public ClearCounter GetClearCounter()
    {
        return clearCounter;
    }
}
