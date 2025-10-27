using Unity.VisualScripting;
using UnityEngine;

public class ClearCounter : MonoBehaviour
{
    [SerializeField] KitchenObjectSO kitchenObjectSO;
    [SerializeField] Transform counterTopPoint;
    [SerializeField] ClearCounter secondClearCounter;
    public bool testing;
    
    KitchenObject kitchenObject;
    
    void Update(){
        if(testing && Input.GetKeyDown(KeyCode.T)){
            if(kitchenObject != null){
                kitchenObject.SetClearCounter(secondClearCounter);
            }
        }
    }
    
    public void Interact(){
        Debug.Log("Interact");
        if(kitchenObject == null){
            Transform kitchenObjectTransform = Instantiate(kitchenObjectSO.prefab, counterTopPoint);
            kitchenObjectTransform.GetComponent<KitchenObject>().SetClearCounter(this); // 1.設定物品初持有者
        }else{
            Debug.Log(kitchenObject.GetClearCounter());
        }
        
    }
    
    public Transform GetKitchenObjectFollowTransform(){
        return counterTopPoint;
    }
    
    public void SetKitchenObject(KitchenObject kitchenObject){
        this.kitchenObject = kitchenObject;
    }
    
    public KitchenObject GetKitchenObject(){
        return kitchenObject;
    }
    
    public void ClearKitchenObject(){
        kitchenObject = null;
    }
    
    public bool HasKitchenObject(){
        return kitchenObject != null;
    }
}
