using System;
using TMPro;
using UnityEngine;

public class TutorialUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI keyMoveUpText;
    [SerializeField] TextMeshProUGUI keyMoveDownText;
    [SerializeField] TextMeshProUGUI keyMoveLeftText;
    [SerializeField] TextMeshProUGUI keyMoveRightText;
    [SerializeField] TextMeshProUGUI keyInteractText;
    [SerializeField] TextMeshProUGUI keyInteractAlternateText;
    [SerializeField] TextMeshProUGUI keyPauseText;
    [SerializeField] TextMeshProUGUI keyGamepadInteractText;
    [SerializeField] TextMeshProUGUI keyGamepadInteractAlternateText;
    [SerializeField] TextMeshProUGUI keyGamepadPauseText;
    
    void Start(){
        GameInput.Instance.OnBindingRebind += GameInput_OnBindingRebind;
        KitchenGameManager.Instance.OnStateChanged += KitchenGameManager_OnStateChanged;
        
        UpdateVisual();
        
        Show();
    }

    private void KitchenGameManager_OnStateChanged(object sender, EventArgs e){
        if(KitchenGameManager.Instance.IsCountdownToStartActive()){
            Hide();
        }
    }

    private void GameInput_OnBindingRebind(object sender, EventArgs e){
        UpdateVisual();
    }

    void UpdateVisual(){
        keyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
        keyMoveDownText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Down);
        keyMoveLeftText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Left);
        keyMoveRightText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Right);
        keyInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Interact);
        keyInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.InteractAlternate);
        keyPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Pause);
        keyGamepadInteractText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Interact);
        keyGamepadInteractAlternateText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_InteractAlternate);
        keyGamepadPauseText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Gamepad_Pause);
        // keyMoveUpText.text = GameInput.Instance.GetBindingText(GameInput.Binding.Move_Up);
    }
    
    void Show(){
        
        gameObject.SetActive(true);
    }
    
    void Hide(){
        gameObject.SetActive(false);
    }
}
