using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BurningRecipeSO", menuName = "SOMenu/BurningRecipeSO")]
public class BurningRecipeSO : ScriptableObject
{
    public KitchenObjectSO inputSO;
    public KitchenObjectSO outputSO;
    public float burningTimerMax;
}
