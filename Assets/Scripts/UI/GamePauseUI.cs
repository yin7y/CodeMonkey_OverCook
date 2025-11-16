using System;
using UnityEngine;
using UnityEngine.UI;

public class GamePauseUI : MonoBehaviour
{
    [SerializeField] Button resumeButton;
    [SerializeField] Button mainMenuButton;
    
    void Awake(){
        resumeButton.onClick.AddListener(() => {
            KitchenGameManager.Instance.TogglePauseGame();
        });
        mainMenuButton.onClick.AddListener(() => {
            Loader.Load(Loader.Scene.MainMenuScene);
        });
    }
    
    void Start(){
        KitchenGameManager.Instance.OnGamePaused += KitchenGameManager_OnGamePaused;
        KitchenGameManager.Instance.OnGameUnpaused += KitchenGameManager_OnGameUnpaused;
    
        Hide();
    }

    private void KitchenGameManager_OnGameUnpaused(object sender, EventArgs e){
        Hide();
    }

    private void KitchenGameManager_OnGamePaused(object sender, EventArgs e){
        Show();
    }

    void Show(){
        gameObject.SetActive(true);
    }
    
    void Hide(){
        gameObject.SetActive(false);
    }
}
