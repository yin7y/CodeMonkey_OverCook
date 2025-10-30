using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    
    IKitchenObjectParent kitchenObjectParent;
    
    public KitchenObjectSO GetKitchenObjectSO(){
        return kitchenObjectSO;
    }
    
    public void SetKitchenObjectParent(IKitchenObjectParent kitchenObjectParent){
        if(this.kitchenObjectParent != null){
            this.kitchenObjectParent.ClearKitchenObject(); // 2.清空原持有者的物品欄位
        }
        
        this.kitchenObjectParent = kitchenObjectParent;   // 3.將物品的持有者更換為另個持有者
        
        if(kitchenObjectParent.HasKitchenObject()){
            Debug.LogError("IKitchenObjectParent already has a KitchenObject");
        }
        kitchenObjectParent.SetKitchenObject(this);    // 4.將現持有者的物品欄位設為此物品
        
        transform.parent = kitchenObjectParent.GetKitchenObjectFollowTransform();  // 5.將物品的父級切換為現持有者
        transform.localPosition = Vector3.zero;
    }
    
    public IKitchenObjectParent GetKitchenObjectParent(){
        return kitchenObjectParent;
    }
    
    
}
