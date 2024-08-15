using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryManager : MonoBehaviour
{
    [SerializeField] private RecipeListSO recipeList;

    private List<RecipeSO> waitingRecipeSoList;
    private float spawnRecipeTimer;
    private float spawnRecipeTimerMax = 4;
    private int waitingRecipesMax = 4;

    private void Awake()
    {
        waitingRecipeSoList = new List<RecipeSO>();
    }

    private void Update()
    {
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0f)
        {
            spawnRecipeTimer = spawnRecipeTimerMax;

            if(waitingRecipeSoList.Count < waitingRecipesMax)
            {
                RecipeSO waitingRecipeSO = recipeList.recipeSOList[Random.Range(0, recipeList.recipeSOList.Count)];
                Debug.Log(waitingRecipeSO);
                waitingRecipeSoList.Add(waitingRecipeSO);
            }
        }
    }
}
