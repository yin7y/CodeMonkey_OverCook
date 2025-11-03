using System;
using Mono.Cecil.Cil;
using UnityEngine;

public class SelectdCounterVisual : MonoBehaviour
{
    [SerializeField] BaseCounter baseCounter;
    [SerializeField] GameObject[] visualGameObjectArray;
    void Start(){
        Player.Instance.OnSelectedCounterChanged += Player_OnSelectedCounterChanged;
    }

    private void Player_OnSelectedCounterChanged(object sender, Player.OnSelectedCounterChangedEventArgs e){
        if(e.selectedCounter == baseCounter){
            Show();
        }else{
            Hide();
        }
    }

    
    void Show(){
        foreach(GameObject visualGameObject in visualGameObjectArray){
            visualGameObject.SetActive(true);
            
        }
    }
    void Hide(){
        foreach(GameObject visualGameObject in visualGameObjectArray){
            visualGameObject.SetActive(false);
        }
    }
}
