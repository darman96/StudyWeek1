using UnityEngine;
using System.Collections;
using UnityEngine.Audio;

public class MixLevels : MonoBehaviour {

    public AudioMixer MasterMixer;


    public void SetMasterLevel(float masterLvl)
    {
        MasterMixer.SetFloat("masterVol", masterLvl);
    }

    public void SetSFXLevel(float sfxLvl)
    {
        MasterMixer.SetFloat("sfxVol", sfxLvl);
    }

    public void SetMusicLevel(float musicLvl)
    {
        MasterMixer.SetFloat("musicVol", musicLvl);
    }
}
