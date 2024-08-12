using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnTngredientAddedEventArgs> OnIngredientAdded;
    public class OnTngredientAddedEventArgs : EventArgs
    {
        public KitchenObjectSO kitchenObjectSO;
    }

    [SerializeField] private KitchenObjectListSO validkitchenObjectSoList;
    private List<KitchenObjectSO> kitchenObjectSOList;

    private void Awake()
    {
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }

    /// <summary>
    /// ��Ӳ˵�SO
    /// </summary>
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO)
    {
        if (!validkitchenObjectSoList.kitchenObjectList.Contains(kitchenObjectSO))
            //���ڿ���װ�̵���Ʒ�б���
            return false;
        if (kitchenObjectSOList.Contains(kitchenObjectSO))
        {
            //�Ѿ��Ź�����Ʒ��
            return false;
        }
        else
        {
            kitchenObjectSOList.Add(kitchenObjectSO);

            OnIngredientAdded?.Invoke(this, new OnTngredientAddedEventArgs
            {
                kitchenObjectSO = kitchenObjectSO
            });


            return true;
        }
    }
}
