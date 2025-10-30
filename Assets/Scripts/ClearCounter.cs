using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : BaseCounter
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterTopPoint;
    
    KitchenObject kitchenObject;

    
    public override void Interact(Player player){
        Debug.Log("Interact");
        
    }
    
    
}
