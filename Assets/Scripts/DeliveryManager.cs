using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using System;

public class DeliveryManager : MonoBehaviour
{
    public event EventHandler OnRecipeSpawned;
    public event EventHandler OnRecipeCompleted;
    public event EventHandler OnRecipeSuccess;
    public event EventHandler OnRecipeFailed;
    
    public static DeliveryManager Instance { get; private set; }
    
    [SerializeField] RecipeListSO recipeListSO;
    List<RecipeSO> waitingRecipeSOList;
    
    float spawnRecipeTimer;
    float spawnRecipeTimerMax = 4f;
    int waitingRecipesMax = 4;
    
    void Awake(){
        Instance = this;
        
        waitingRecipeSOList = new List<RecipeSO>();
    }
    
    void Update(){
        spawnRecipeTimer -= Time.deltaTime;
        if(spawnRecipeTimer <= 0){
            spawnRecipeTimer = spawnRecipeTimerMax;
            
            if(waitingRecipeSOList.Count < waitingRecipesMax){
                RecipeSO waitingRecipeSO = recipeListSO.recipeSOList[UnityEngine.Random.Range(0, recipeListSO.recipeSOList.Count)];
                
                waitingRecipeSOList.Add(waitingRecipeSO);
                
                OnRecipeSpawned?.Invoke(this, EventArgs.Empty);
            }
        }
    }
    
    public void DeliverRecipe(PlateKitchenObject plateKitchenObject){
        for(int i = 0; i < waitingRecipeSOList.Count; i++){
            RecipeSO waitingRecipeSO = waitingRecipeSOList[i];
            
            if(waitingRecipeSO.kitcchenObjectSOList.Count == plateKitchenObject.GetKitchenObjectSOList().Count){
                bool plateContentsMatchesRecipe = true;
                foreach(KitchenObjectSO recipeKitchenObjectSO in waitingRecipeSO.kitcchenObjectSOList){
                    bool ingredientFound = false;
                    foreach (KitchenObjectSO plateKitchenObjectSO in plateKitchenObject.GetKitchenObjectSOList()){
                        if(plateKitchenObjectSO == recipeKitchenObjectSO){
                            ingredientFound = true;
                            break;
                        }
                    }
                    if(!ingredientFound){
                        plateContentsMatchesRecipe = false;
                    }
                }
                if(plateContentsMatchesRecipe){
                    
                    waitingRecipeSOList.RemoveAt(i);
                    
                    OnRecipeCompleted?.Invoke(this, EventArgs.Empty);
                    OnRecipeSuccess?.Invoke(this, EventArgs.Empty);
                    return;
                }
            }
        }
        OnRecipeFailed?.Invoke(this, EventArgs.Empty);
        // Debug.Log("Player did not deliver a correct recipe");
    }
    
    public List<RecipeSO> GetWaitingRecipeSOList(){
        return waitingRecipeSOList;
    }
}
