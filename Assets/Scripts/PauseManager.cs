using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour {
    private bool isPaused = true;

    [SerializeField]
    private Canvas pauseCanvas;

    // Start is called before the first frame update
    void Start() {
        this.pauseCanvas = GetComponent<Canvas>();
        TogglePause();
    }

    // Update is called once per frame
    void Update() {
        if ( Input.GetKeyDown(KeyCode.Escape) ) {
            TogglePause();
        }
    }

    public void TogglePause() {
        isPaused = !isPaused;

        // set time to 0 if paused, overwise - 1
        Time.timeScale = ( isPaused ? 0f : 1f );

        // show pause menu if isPaused is true and hide if false
        if ( pauseCanvas is not null ) {
            pauseCanvas.enabled = isPaused;
        }
    }
}
