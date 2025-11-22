using System;
using TMPro;
using UnityEngine;

public class GameStartCountdownUI : MonoBehaviour{
    
    const string NUMBER_POPUP = "NumberPopup";
    
    [SerializeField] TextMeshProUGUI countdownText;
    
    Animator animator;
    int previousCountdownNumber;
    
    
    void Awake(){
        animator = GetComponent<Animator>();
    }
    
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
        // Mathf.CeilToInt 無條件進位取整
        int countdownNumber = Mathf.CeilToInt(KitchenGameManager.Instance.GetCountdownToStartTimer());
        countdownText.text = countdownNumber.ToString();
        
        if(previousCountdownNumber != countdownNumber){
            previousCountdownNumber = countdownNumber;
            animator.SetTrigger(NUMBER_POPUP);
            SoundManager.Instance.PlayCountdownSound();
        }
        
        
    }
    
    void Show(){
        gameObject.SetActive(true);
    }
    
    void Hide(){
        gameObject.SetActive(false);
    }
    
    
}
