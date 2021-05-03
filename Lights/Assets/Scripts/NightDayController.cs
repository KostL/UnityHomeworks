using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NightDayController : MonoBehaviour
{
    // Start is called before the first frame update
    public Light m_Light;
   public float  m_timer;
    void Start()
    {
        m_Light.intensity = 1;
    }

    // Update is called once per frame
    void Update()
    {   //Сейчас цикл длится 24 секунды, чтобы было 24 минуты - раскомитить деление на 60 Time.deltaTime
        m_timer+=1*Time.deltaTime; //60; 
        Debug.Log(m_timer);
        if (m_timer > 12){
            m_Light.intensity = (m_timer-12)/12;
        }
        else{
            m_Light.intensity =1 - m_timer/12;
        }
        
        if (m_timer > 24){
            m_timer = 0;
        }
    }
}
