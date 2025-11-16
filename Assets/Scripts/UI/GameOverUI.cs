using System;
using TMPro;
using UnityEngine;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI recipesDeliveredText;
    
    void Start(){
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    
        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e)
    {
        if(KitchenGameManager.Instance.IsGameOver()){
            Show();
            
            recipesDeliveredText.text = DeliveryManager.Instance.GetSuccessfulRecipesAmount().ToString();
        }else{
            Hide();
        }
    }
    
    void Show(){
        gameObject.SetActive(true);
    }
    
    void Hide(){
        gameObject.SetActive(false);
    }
}
