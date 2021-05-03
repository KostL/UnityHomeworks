using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamps : MonoBehaviour
{
    // Start is called before the first frame update
    public NightDayController m_lights;
    public Light m_light;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(m_lights.m_timer > 8 && m_lights.m_timer < 16 ){
            m_light.intensity = 3;
        }
        else{
            m_light.intensity = 0;
        }
    }
}
