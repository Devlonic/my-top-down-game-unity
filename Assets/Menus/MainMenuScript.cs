using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuScript : MonoBehaviour {
    public void OnClick_Play() {
        SceneManager.LoadScene("SampleScene");
    }
    public void OnClick_LevelsSelect() {
        SceneManager.LoadScene("LevelsSelectMenu");
    }
    public void OnClick_Settings() {
        SceneManager.LoadScene("SettingsMenu");
    }
    public void OnClick_MainMenu() {
        SceneManager.LoadScene("MainMenu");
    }
    public void OnClick_Quit() {
        Application.Quit();
    }


    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
}
