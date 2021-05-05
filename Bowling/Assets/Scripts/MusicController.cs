using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    // Start is called before the first frame update
    public int sound_Turn_option;
    void Start()
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        if(PlayerPrefs.HasKey("sound_Turn")){
            sound_Turn_option = PlayerPrefs.GetInt("sound_Turn");
        }
        else{
            PlayerPrefs.SetInt("sound_Turn",1);
            PlayerPrefs.Save();
            sound_Turn_option = 1;
        }
            audioSource.mute = sound_Turn_option == 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
