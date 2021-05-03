using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody m_Rigidbody;
    public float m_Thrust = 20f;
     public float m_SpeedRotation = 20f;
    Vector3 m_EulerAngleVelocity;
    // Start is called before the first frame update
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
        m_EulerAngleVelocity = new Vector3(0, m_SpeedRotation, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        m_Rigidbody.AddForce(transform.forward * m_Thrust*Input.GetAxis("Vertical"));
        Quaternion deltaRotation = Quaternion.Euler(m_EulerAngleVelocity * Time.fixedDeltaTime*Input.GetAxis("Horizontal"));
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * deltaRotation);

    }
}
