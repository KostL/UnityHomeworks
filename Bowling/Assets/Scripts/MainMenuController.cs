using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MainMenuController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject soundButton;
    public AudioSource audioSource;
    public int sound_Turn_option;

    void Start()
    {
        if(PlayerPrefs.HasKey("sound_Turn")){
            sound_Turn_option = PlayerPrefs.GetInt("sound_Turn");
        }
        else{
            PlayerPrefs.SetInt("sound_Turn",1);
            PlayerPrefs.Save();
            sound_Turn_option = 1;
        }
        UpdateSoundOption();
    }
    void UpdateSoundOption(){
        Text text  = soundButton.GetComponentInChildren<Text>();
        if (sound_Turn_option == 1){
            text.text = "Sound: ON";
            audioSource.mute = false;
        }
        else{
            text.text = "Sound: OFF";
            audioSource.mute = true;
        }
    }
   public void ClickExit (){
        Application.Quit();
    }
   public void ClickStartGame (){
     // Scene menu = SceneManager.GetActiveScene();
        SceneManager.LoadScene("GameScene", LoadSceneMode.Single);
       // SceneManager.UnloadSceneAsync(menu);
    }

   public void ClickSound(){
       sound_Turn_option = sound_Turn_option == 1 ? 0 : 1;
       UpdateSoundOption();
       PlayerPrefs.SetInt("sound_Turn",sound_Turn_option);
       PlayerPrefs.Save();
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
