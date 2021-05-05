using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public class ScoreBoard : MonoBehaviour
{
    // Start is called before the first frame update
    public FrameData[] frameDatas;
    public GameObject ScoreTable;
   
   int curFrame = 0;
    void Start()
    {
        frameDatas = new FrameData[10];
        ResetScore();
        UpdateScoreBoard();
    }

    void ResetScore(){
        for (int i = 0; i < 10; ++i){
            frameDatas[i] = new FrameData();
        }
    }

   public void OnHit(int kegelsHit, int round){
        if (round == 0){
            frameDatas[curFrame].points_hit1 = kegelsHit;
            if (kegelsHit == 10){
                curFrame++;
            }
        }
        if (round == 1){
            frameDatas[curFrame].points_hit2 = kegelsHit - frameDatas[curFrame].points_hit1;
            curFrame++;
        }
        UpdateScoreBoard();
        if (curFrame == 10){
            curFrame = 0;
            ResetScore();
        }

    }

    void UpdateScoreBoard(){
        int i = 0;
        int curScore = 0;
        foreach (Transform scoreTextTr in ScoreTable.transform){
            Text scoreText = scoreTextTr.gameObject.GetComponent<Text>();
            scoreText.text = "";
            
            if(frameDatas[i].points_hit1 == 10){
                curScore += 10;
                scoreText.text += "X\n";
                scoreText.text += ""+curScore;
                i++;
                continue;
            }
            else if(frameDatas[i].points_hit1 == -1){
                scoreText.text += "- ";
            }
            else{
                 scoreText.text += ""+frameDatas[i].points_hit1+" ";
            }

            if(frameDatas[i].points_hit2 + frameDatas[i].points_hit1  == 10){
                scoreText.text += "\\\n";    

            }
            else if (frameDatas[i].points_hit2 == -1){
                 scoreText.text += "-";
                 i++;
                 continue;
            }
            else {
                scoreText.text += ""+ frameDatas[i].points_hit2 + "\n"; 
            }
            curScore += frameDatas[i].points_hit1 + frameDatas[i].points_hit2;
            scoreText.text += ""+curScore;
            i++;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
public class FrameData{
    public int points_hit1 = -1;
    public int points_hit2 = -1;
}
