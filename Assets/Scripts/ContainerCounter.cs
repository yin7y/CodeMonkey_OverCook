using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class ContainerCounter : BaseCounter
{
    public event EventHandler OnPlayerGrabbedObject;
    
    
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    
    public override void Interact(Player player){
        // Debug.Log("Interact");
        if(!HasKitchenObject()){
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetKitchenObjectParent(player); // 1.設定物品初持有者
            
            OnPlayerGrabbedObject?.Invoke(this, EventArgs.Empty);
        }
        
    }

    
}
