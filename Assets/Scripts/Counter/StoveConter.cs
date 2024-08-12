using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class StoveConter : BaseCounter, IHasProgress
{
    public event EventHandler<OnStateChangedEventArgs> OnStateChanged;
    public event EventHandler<IHasProgress.OnProgressChangerEventArgs> OnProGressChanged;

    public class OnStateChangedEventArgs : EventArgs 
    {
        public State state;
    }



    public enum State
    {
        Idle,
        Frying,
        Fried,
        Burned
    }
    [SerializeField] private FryingRecipeListSO fryinggRecipeList;
    [SerializeField] private BurningRecipeListSO burningRecipeList;

    private State state;
    private float fryingTime;
    private float bruningTime;
    private FryingRecipeSO fryingRecipeSO;
    private BurningRecipeSO burningRecipeSO;
    private void Start()
    {
        state = State.Idle;
    }
    private void Update()
    {
        if (HasKitchenObjetc())
            switch (state)
            {
                case State.Idle:
                    break;
                case State.Frying:
                    fryingTime += Time.deltaTime;
                    OnProGressChanged?.Invoke(this, new IHasProgress.OnProgressChangerEventArgs
                    {
                        progressNormalized = fryingTime / fryingRecipeSO.fryingTimerMax
                    });
                    if (fryingTime >= fryingRecipeSO.fryingTimerMax)
                    {
                        Debug.Log("��ը���");
                        GetKitchenObject().DestroySelf();
                        //������ը�ŵ�ʳ��
                        KitchenObject.SpanwKitchenObject(fryingRecipeSO.outputSO, this);
                        state = State.Fried;
                        burningRecipeSO = GetBurningRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                        bruningTime = 0;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                      
                    }
                    break;
                case State.Fried:
                    bruningTime += Time.deltaTime;
                    OnProGressChanged?.Invoke(this, new IHasProgress.OnProgressChangerEventArgs
                    {
                        progressNormalized = bruningTime / burningRecipeSO.burningTimerMax
                    });
                    if (bruningTime >= burningRecipeSO.burningTimerMax)
                    {
                        Debug.Log("�󻵵���");
                        GetKitchenObject().DestroySelf();
                        //������ը�ŵ�ʳ��
                        KitchenObject.SpanwKitchenObject(burningRecipeSO.outputSO, this);
                        state = State.Burned;
                        OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                        {
                            state = state
                        });
                        OnProGressChanged?.Invoke(this, new IHasProgress.OnProgressChangerEventArgs
                        {
                            progressNormalized = 0
                        });
                    }
                    break;
                case State.Burned:

                    break;
            }


    }

    public override void Interact(Player player)
    {
        if (!HasKitchenObjetc())
        //����̨��û����Ʒʱ
        {
            if (player.HasKitchenObjetc())
            //������г�����Ʒ
            {
                //��Ʒ������ը
                if (HasRecipeWithInput(player.GetKitchenObject().GetKitchenObjectSO()))
                {
                    player.GetKitchenObject().SetKitechenObjectParent(this);

                    fryingRecipeSO = GetFryingRecipeSOWithInput(GetKitchenObject().GetKitchenObjectSO());

                    fryingTime = 0;
                    state = State.Frying;

                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });
                }
            }
            else
            //�������û����Ʒ
            {
            }
        }
        else
        //����̨�ϴ�����Ʒʱ
        {
            if (player.HasKitchenObjetc())
            //������г�����Ʒ
            {
                //��������õ�������
                if (player.GetKitchenObject().TryGetPlate(out PlateKitchenObject plateKitchenObject))
                {
                    if (plateKitchenObject.TryAddIngredient(GetKitchenObject().GetKitchenObjectSO()))
                        GetKitchenObject().DestroySelf();


                    state = State.Idle;
                    OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                    {
                        state = state
                    });

                    OnProGressChanged?.Invoke(this, new IHasProgress.OnProgressChangerEventArgs
                    {
                        progressNormalized = 0
                    });
                }
            }
            else
            //�������û����Ʒ
            {
                GetKitchenObject().SetKitechenObjectParent(player);
                state = State.Idle;
                OnStateChanged?.Invoke(this, new OnStateChangedEventArgs
                {
                    state = state
                });

                OnProGressChanged?.Invoke(this, new IHasProgress.OnProgressChangerEventArgs
                {
                    progressNormalized = 0
                });
            }
        }
    }
    public override void InteractAlternaten(Player player)
    {
        Debug.Log("�Զ����ȣ�����Ҫ����");
    }
    /// <summary>
    /// ���������Ƿ�����ը�˵�֮��
    /// </summary>
    /// <param name="inputKitchenObjectSO"></param>
    /// <returns></returns>
    private bool HasRecipeWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        return fryingRecipeSO != null;
    }

    private KitchenObjectSO GetOutputForInput(KitchenObjectSO inputKitchenObjectSO)
    {
        FryingRecipeSO fryingRecipeSO = GetFryingRecipeSOWithInput(inputKitchenObjectSO);
        if (fryingRecipeSO != null)
            return fryingRecipeSO.outputSO;
        else
            return null;
    }

    /// <summary>
    /// ��ȡ��ը��Ĳ�����SO
    /// </summary>
    /// <param name="inputKitchenObjectSO"></param>
    /// <returns></returns>
    private FryingRecipeSO GetFryingRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (var cuttingRecipeSO in fryinggRecipeList.fryingRecipesList)
        {
            if (inputKitchenObjectSO == cuttingRecipeSO.inputSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }

    private BurningRecipeSO GetBurningRecipeSOWithInput(KitchenObjectSO inputKitchenObjectSO)
    {
        foreach (var cuttingRecipeSO in burningRecipeList.burningRecipeListSO)
        {
            if (inputKitchenObjectSO == cuttingRecipeSO.inputSO)
            {
                return cuttingRecipeSO;
            }
        }
        return null;
    }
}
