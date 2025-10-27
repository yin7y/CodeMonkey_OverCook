using UnityEngine;

public class KitchenObject : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    
    ClearCounter clearCounter;
    
    public KitchenObjectSO GetKitchenObjectSO(){
        return kitchenObjectSO;
    }
    
    public void SetClearCounter(ClearCounter clearCounter){
        if(this.clearCounter != null){
            this.clearCounter.ClearKitchenObject(); // 2.清空原持有者的物品欄位
        }
        
        this.clearCounter = clearCounter;   // 3.將物品的持有者更換為另個持有者
        
        if(clearCounter.HasKitchenObject()){
            Debug.LogError("Counter already has a KitchenObject");
        }
        clearCounter.SetKitchenObject(this);    // 4.將現持有者的物品欄位設為此物品
        
        transform.parent = clearCounter.GetKitchenObjectFollowTransform();  // 5.將物品的父級切換為現持有者
        transform.localPosition = Vector3.zero;
    }
    
    public ClearCounter GetClearCounter(){
        return clearCounter;
    }
    
    
}
