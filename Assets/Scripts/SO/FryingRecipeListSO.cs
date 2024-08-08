using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "FryingRecipeListSO", menuName = "SOMenu/FryingRecipeListSO")]
public class FryingRecipeListSO : ScriptableObject
{
    public List<FryingRecipeSO> fryingRecipesList = new List<FryingRecipeSO>();
}
