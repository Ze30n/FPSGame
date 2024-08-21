using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public GameObject panelMain;
    public GameObject panelOpttion;

    // Start is called before the first frame update
    void Start()
    {
        panelMain.SetActive(true);
        panelOpttion.SetActive(false);
        //SceneManager.LoadScene("StartGame");
    }

    public void OnOptionClick()
    {
        panelMain.SetActive(false);
        panelOpttion.SetActive(true);
    }
    public void OnOptionClickExit()
    {
        panelMain.SetActive(true);
        panelOpttion.SetActive(false);
    }
    public void OnPlayClick()
    {
        SceneManager.LoadScene("Playground");
    }
    public void SetMusicVolume(float volume)
    {
        AudioManager.Instance.SetMusicVolume(volume);
    }
    public void SetSFXVolume(float volume)
    {
        AudioManager.Instance.SetSFXVolume(volume);
    }
    public void Exit()
    {
        Application.Quit();
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
    }
}
