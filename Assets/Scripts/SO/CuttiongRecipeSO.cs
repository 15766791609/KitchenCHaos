using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cuttiongRecipeSO", menuName = "SOMenu/cuttiongRecipeSO")]
public class CuttiongRecipeSO:ScriptableObject
{
    public KitchenObjectSO inputSO;
    public KitchenObjectSO outputSO;
    public int maxCuttingProgress;
}
