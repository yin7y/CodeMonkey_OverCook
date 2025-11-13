using System;
using UnityEngine;

public class KitchenGameManager : MonoBehaviour
{
    public static KitchenGameManager Instance { get; private set; }
    
    public event EventHandler OnStateChanged;
    
    enum State {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
        
    }
    
    State state;
    float WaitingToStartTimer = 1f;
    float countdownToStartTimer = 3f;
    float gamePlayingTimer = 10f;
    
    
    void Awake(){
        Instance = this;
        state = State.WaitingToStart;
    }
    
    void Start(){
        
    }
    
    void Update(){
        switch (state){
            case State.WaitingToStart:
                WaitingToStartTimer -= Time.deltaTime;
                if(WaitingToStartTimer < 0f){
                    state = State.CountdownToStart;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if(countdownToStartTimer < 0f){
                    state = State.GamePlaying;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if(gamePlayingTimer < 0f){
                    state = State.GameOver;
                    OnStateChanged?.Invoke(this, EventArgs.Empty);
                }
                break;
            case State.GameOver:
                break;
        }
    }
    
    public bool IsGamePlaying(){
        return state == State.GamePlaying;
    }
    
    public bool IsCountdownToStartActive(){
        return state == State.CountdownToStart;
    }
    
    public float GetCountdownToStartTimer(){
        return countdownToStartTimer;
    }
}
