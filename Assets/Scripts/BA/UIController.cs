using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

// Unity Script | 0 references
public class UIController : MonoBehaviour {
    [SerializeField] TMP_Text scoreLabel;
    [SerializeField] SettingsPopup settingsPopup;

    private int _score;
    private void OnEnable(){
        Messenger.AddListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }

    private void OnEnemyHit(){
        _score += 1;
        scoreLabel.text = _score.ToString();
    }
    private void OnDisable(){
        Messenger.RemoveListener(GameEvent.ENEMY_HIT, OnEnemyHit);
    }
    private void Start(){
        _score = 0;
        scoreLabel.text = _score.ToString();
        
        settingsPopup.Close();
    }

    // Update is called once per frame
    void Update() {
        //scoreLabel.text = Time.realtimeSinceStartup.ToString();
    }

    public void OnOpenSettings() {
        //Debug.Log("Opening settings...");
        settingsPopup.Open();
    }
}
