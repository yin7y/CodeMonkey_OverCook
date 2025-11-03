using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    
    
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player){
        // Debug.Log("Interact");
        if(!player.HasKitchenObject()){
            KitchenObject.SpawnKitchenObject(kitchenObjectSO, player);
            
            
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        
    }

    
}
