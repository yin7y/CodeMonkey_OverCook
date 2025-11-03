using System;
using UnityEngine;

public class PlatesCounter : BaseCounter
{
    public event EventHandler OnPlateSpawned;
    public event EventHandler OnPlateRemoved;
    
    [SerializeField] KitchenObjectSO plateKitchenObjectSO;
    
    float spawnPlateTimer;
    [SerializeField] float spawnPlateTimerMax = 4f;
    int plateSpawnedAmount;
    [SerializeField] int plateSpawnedAmountMax = 4;
    
    void Start(){
        
    }
    
    void Update(){
        spawnPlateTimer += Time.deltaTime;
        if(spawnPlateTimer > spawnPlateTimerMax){
            spawnPlateTimer = 0f;
            
            if(plateSpawnedAmount < plateSpawnedAmountMax){
                plateSpawnedAmount++;
                
                OnPlateSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }

    public override void Interact(Player player){
        if(!player.HasKitchenObject()){
            // 玩家空手
            if(plateSpawnedAmount > 0){
                // 至少有一個盤子
                plateSpawnedAmount--;
                
                KitchenObject.SpawnKitchenObject(plateKitchenObjectSO, player);
                
                OnPlateRemoved?.Invoke(this, EventArgs.Empty);
            }
        }
    }
}
