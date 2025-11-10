using UnityEngine;
using UnityEngine.UI;

public class PlateIconsSingleUI : MonoBehaviour
{
    [SerializeField] Image image;
    
    void Start(){
        
    }
    
    public void SetKitchenObjectSO(KitchenObjectSO kitchenObjectSO){
        image.sprite = kitchenObjectSO.sprite;
    }
}
