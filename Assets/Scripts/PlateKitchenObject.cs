using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    public event EventHandler<OnIngredientAddedEventArgs> OnIngredientAdded;
    public class OnIngredientAddedEventArgs : EventArgs{
        public KitchenObjectSO kitchenObjectSO;
    }
    
    [SerializeField] List<KitchenObjectSO> validKitchenObjectSOList;
    
    List<KitchenObjectSO> kitchenObjectSOList;
    
    
    void Awake(){
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO){
        if(!validKitchenObjectSOList.Contains(kitchenObjectSO)){
            return false;
        }
        if(kitchenObjectSOList.Contains(kitchenObjectSO)){
            return false;
        }else{
            kitchenObjectSOList.Add(kitchenObjectSO);
            
            OnIngredientAdded?.Invoke(this, new OnIngredientAddedEventArgs{
                kitchenObjectSO = kitchenObjectSO,
            });
            return true;
        }
        
    }
    
    public List<KitchenObjectSO> GetKitchenObjectSOList(){
        return kitchenObjectSOList;
    }
}
