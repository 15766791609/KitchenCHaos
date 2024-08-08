using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FryingRecipeSO", menuName = "SOMenu/FryingRecipeSO")]
public class FryingRecipeSO : ScriptableObject
{
    public KitchenObjectSO inputSO;
    public KitchenObjectSO outputSO;
    public float fryingTimerMax;
}
