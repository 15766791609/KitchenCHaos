using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "cuttiongRecipeListSO", menuName = "SOMenu/cuttiongRecipeListSO")]
public class CuttiongRecipeListSO : ScriptableObject
{
    public List<CuttiongRecipeSO> cuttiongRecipesList = new List<CuttiongRecipeSO>();
}
