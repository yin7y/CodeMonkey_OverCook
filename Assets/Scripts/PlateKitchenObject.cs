using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class PlateKitchenObject : KitchenObject
{
    [SerializeField] List<KitchenObjectSO> validKitchenObjectSOList;
    
    List<KitchenObjectSO> kitchenObjectSOList;
    
    
    void Awake(){
        kitchenObjectSOList = new List<KitchenObjectSO>();
    }
    
    public bool TryAddIngredient(KitchenObjectSO kitchenObjectSO){
        if(validKitchenObjectSOList.Contains(kitchenObjectSO)){
            return false;
        }
        if(kitchenObjectSOList.Contains(kitchenObjectSO)){
            return false;
        }else{
            kitchenObjectSOList.Add(kitchenObjectSO);
            return true;
        }
        
    }
}
