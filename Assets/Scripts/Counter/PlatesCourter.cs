using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PlatesCourter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemove;

    [SerializeField] private KitchenObjectSO plateKitchenObjectSO;

    private float spawnPlateTime;
    private float spawnPlateTimeMax = 4f;
    private int platesSoawnedAmount;
    private int platesSoawnedAmountMax = 10;


    private void Update()
    {
        spawnPlateTime += Time.deltaTime;
        if(spawnPlateTime > spawnPlateTimeMax)
        {
            spawnPlateTime = 0;
            if(platesSoawnedAmount < platesSoawnedAmountMax)
            {
                //KitchenObject.SpanwKitchenObject(plateKitchenObjectSO, this);
                platesSoawnedAmount++;

                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    public override void Interact(Player player)
    {
        //�������û����
        if(!player.HasKitchenObjetc())
        {
            //������������0
            if(platesSoawnedAmount>0)
            {
                platesSoawnedAmount--;
                KitchenObject.SpanwKitchenObject(plateKitchenObjectSO, player);

                OnPlateRemove?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
