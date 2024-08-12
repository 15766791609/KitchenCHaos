using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlateCOmpleteVisual : MonoBehaviour
{
    [Serializable]
    public struct kitchenObjectSO_GameObject
    {
        public KitchenObjectSO kitchenObjectSO;
        public GameObject gameObject;
    }


    [SerializeField] private PlateKitchenObject plateKitchenObject;
    [SerializeField] private List<kitchenObjectSO_GameObject> kitchenObjectSO_GameObjectList;

    private void Start()
    {
        plateKitchenObject.OnIngredientAdded += OnPlateKitchenObject_OnIngredientAdded;

        foreach (kitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSO_GameObjectList)
        {
                kitchenObjectSOGameObject.gameObject.SetActive(false);
        }
    }

    private void OnPlateKitchenObject_OnIngredientAdded(object sender, PlateKitchenObject.OnTngredientAddedEventArgs e)
    {
        foreach (kitchenObjectSO_GameObject kitchenObjectSOGameObject in kitchenObjectSO_GameObjectList)
        {
            if(kitchenObjectSOGameObject.kitchenObjectSO == e.kitchenObjectSO)
            {
                kitchenObjectSOGameObject.gameObject.SetActive(true);
            }
        }
    }
}
