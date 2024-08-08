using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "BurningRecipeListSO", menuName = "SOMenu/BurningRecipeListSO")]
public class BurningRecipeListSO : ScriptableObject
{
    public List<BurningRecipeSO> burningRecipeListSO = new List<BurningRecipeSO>();
}
