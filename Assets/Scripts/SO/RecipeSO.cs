using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RecipeSO", menuName = "SOMenu/RecipeSO")]
public class RecipeSO : ScriptableObject
{
    public List<KitchenObjectSO> KitchenObjectList = new List<KitchenObjectSO>();
    public string recipeName;

}
