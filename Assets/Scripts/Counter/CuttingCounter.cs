using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CuttingCounter : BaseCounter,IHasProgress
{
    //事件的直接声明
    public event EventHandler<IHasProgress.OnProgressChangerEventArgs> OnProGressChanged;
 
    public event EventHandler OnCut;


    [SerializeField] private CuttiongRecipeListSO cuttiongRecipeList;

    //切割进度
    private int cuttingProgress;


    public override void Interact(Player player)
    {
        if (!HasKitchenObjetc())
        //当柜台上没有物品时
        {
            if (player.HasKitchenObjetc())
            //玩家手中持有物品
            {
                //物品可以切割
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitechenObjectParent(this);
                    cuttingProgress = 0;


                    CuttiongRecipeSO cuttiongRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
                    OnProGressChanged?.Invoke(this, new IHasProgress.OnProgressChangerEventArgs { progressNormalized = cuttingProgress * 1.0f / cuttiongRecipeSO.maxCuttingProgress });

                }

            }
            else
            //玩家手中没有物品
            {
            }
        }
        else
        //当柜台上存在物品时
        {

            if (player.HasKitchenObjetc())
            //玩家手中持有物品
            {
                //玩家手中拿的是盘子
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                        GetKitchenObject().DestroySelf();
                }
            }
            else
            //玩家手中没有物品
            {
                GetKitchenObject().SetKitechenObjectParent(player);
            }
        }
    }

    public override void InteractAlternaten(Player play)
    {
        //存在物品且可以进行切割
        if (HasKitchenObjetc() && HasRecipeWithInput(GetKitchenObject().GetKitchenObjectSO()))
        {
            cuttingProgress++;
            CuttiongRecipeSO cuttiongRecipeSO = GetCuttingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());
            OnCut?.Invoke(this,EventArgs.Empty);
            OnProGressChanged?.Invoke(this, new IHasProgress.OnProgressChangerEventArgs { progressNormalized = cuttingProgress * 1.0f / cuttiongRecipeSO.maxCuttingProgress  });
            if (cuttingProgress >= cuttiongRecipeSO.maxCuttingProgress)
            {
                KitchenObjectSO outputKitcenObjectSO = GetOutputForInput(GetKitchenObject().GetKitchenObjectSO());
                GetKitchenObject().DestroySelf();

                KitchenObject.SpanwKitchenObject(outputKitcenObjectSO, this);
            }
        }
    }

    /// <summary>
    /// 检查该物体是否在切割菜单之内
    /// </summary>
    /// <param name="inputKitchenObjectSO"></param>
    /// <returns></returns>
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttiongRecipeSO cuttiongRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        return cuttiongRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        CuttiongRecipeSO cuttiongRecipeSO = GetCuttingRecipeSOWithInput(inputKitchenObjectSO);
        if (cuttiongRecipeSO != null)
            return cuttiongRecipeSO.outputSO;
        else
            return null;
    }
    private CuttiongRecipeSO GetCuttingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (var cuttingRecipeSO in cuttiongRecipeList.cuttiongRecipesList)
        {
            if (inputKitchenObjectSO == cuttingRecipeSO.inputSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }
}
