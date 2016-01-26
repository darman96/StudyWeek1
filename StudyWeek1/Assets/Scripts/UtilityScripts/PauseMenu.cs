using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Audio;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class PauseMenu : MonoBehaviour
{
    public AudioMixerSnapshot Paused;
    public AudioMixerSnapshot Unpaused;
    Canvas canvas;
	void Start ()
    {
        canvas = GetComponent<Canvas>();
        canvas.enabled = false;
	}

	void Update ()
    {
	if (Input.GetKeyDown(KeyCode.Escape))
        {
            canvas.enabled = !canvas.enabled;
            Pause();
        }
	}
    public void Pause()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
        Lowpass();
    }

    void Lowpass()
    {
        if(Time.timeScale == 0)
        {
            Paused.TransitionTo(.01f);
        }
        else
        {
            Unpaused.TransitionTo(.01f);
        }
    }

    public void RestartLevel()
    {
        Application.LoadLevel(1);
    }

    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif

    } 
}
