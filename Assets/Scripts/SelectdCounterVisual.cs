using System;
using Mono.Cecil.Cil;
using UnityEngine;

public class SelectdCounterVisual : MonoBehaviour
{
    [SerializeField] ClearCounter clearCounter;
    [SerializeField] GameObject visualGameObject;
    void Start(){
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e){
        if(e.selectedCounter == clearCounter){
            Show();
        }else{
            Hide();
        }
    }

    void Update(){
        
    }
    
    void Show(){
        visualGameObject.SetActive(true);
    }
    void Hide(){
        visualGameObject.SetActive(false);
    }
}
