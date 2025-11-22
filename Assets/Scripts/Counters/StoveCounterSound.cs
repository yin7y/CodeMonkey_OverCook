using System;
using Unity.VisualScripting;
using UnityEngine;

public class StoveCounterSound : MonoBehaviour
{
    [SerializeField] StoveCounter stoveCounter;
    AudioSource audioSource;
    float warningSoundTimer;
    bool playWarningSound;
    
    void Awake(){
        audioSource = GetComponent<AudioSource>();
    }
    
    void Start(){
        stoveCounter.OnStateChanged += StoveCounter_OnStateChanged;
        stoveCounter.OnProgressChanged += StoveCounter_OnProgressChanged;
    }
    
    void Update(){
        if(playWarningSound){
            warningSoundTimer -= Time.deltaTime;
            if(warningSoundTimer <= 0f){
                float warningSoundTimerMax = .2f;
                warningSoundTimer = warningSoundTimerMax;
                
                SoundManager.Instance.PlayWarningSound(stoveCounter.transform.position);
            }
        }
        
    }

    private void StoveCounter_OnProgressChanged(object sender, IHasProgress.OnProgressChangedEventArgs e){
        float burnShowProgressAmount = .5f;
        playWarningSound = stoveCounter.IsFried() && e.progressNormalized >= burnShowProgressAmount;
        
    }

    private void StoveCounter_OnStateChanged(object sender, StoveCounter.OnStateChangedEventArgs e){
        bool playSound = e.state == StoveCounter.State.Frying || e.state == StoveCounter.State.Fried;
        if(playSound){
            audioSource.Play();
        }else{
            audioSource.Pause();
        }
        
        
    }
}
