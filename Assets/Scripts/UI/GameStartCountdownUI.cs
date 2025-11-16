using System;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour
{
    
    [SerializeField] TextMeshProUGUI countdownText;
    
    void Start(){
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
    
        Hide();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e){
        if(KitchenGameManager.Instance.IsCountdownToStartActive()){
            Show();
        }else{
            Hide();
        }
    }

    void Update(){
        countdownText.text = Mathf.Ceil(KitchenGameManager.Instance.GetCountdownToStartTimer()).ToString();
    }
    
    void Show(){
        gameObject.SetActive(true);
    }
    
    void Hide(){
        gameObject.SetActive(false);
    }
    
    
}
