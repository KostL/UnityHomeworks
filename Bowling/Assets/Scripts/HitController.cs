using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class HitController : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform m_TrianglePos;
    public GameObject m_TrianglePrefab;
    public UnityEvent<int,int> OnHit;

    public Transform m_BallSpawnPos;
    GameObject m_cur_triangle;
    GameObject m_hitted_ball;
    public int curRound = 0;
    public int kegelsHit = 0;

    void ResetTriangle(){
        if (m_cur_triangle != null){
            Destroy(m_cur_triangle);
        }
        m_cur_triangle = GameObject.Instantiate<GameObject>(m_TrianglePrefab,m_TrianglePos.position,m_TrianglePos.rotation);
        curRound = 0;
        kegelsHit = 0;
    }
    void Start()
    {
        ResetTriangle();
    }
    void  Check_kegels(){
        List<GameObject> dropped_kegels = new List<GameObject>();
        foreach (Transform kegel in m_cur_triangle.transform){
            Debug.Log(kegel.transform.localEulerAngles);
            if(kegel.transform.localEulerAngles.x > 5 || kegel.transform.localEulerAngles.x < -5 ||
            kegel.transform.localEulerAngles.y > 5 || kegel.transform.localEulerAngles.y < -5||
            kegel.transform.localEulerAngles.z > 5 || kegel.transform.localEulerAngles.z < -5){
                kegelsHit++;
                dropped_kegels.Add(kegel.gameObject);
            }
        }
        foreach (GameObject kegel in dropped_kegels){
            GameObject.Destroy(kegel);
        }
        Debug.Log(""+kegelsHit);
    }

    void ResetBall(){
        Rigidbody rbdy = m_hitted_ball.gameObject.GetComponent<Rigidbody>();

        //Stop Moving/Translating
        rbdy.velocity = Vector3.zero;

        //Stop rotating
        rbdy.angularVelocity = Vector3.zero;
        m_hitted_ball.transform.position = m_BallSpawnPos.position;
    }
    IEnumerator  Hit(float waitTime){
        yield return new WaitForSeconds(waitTime);
        ResetBall();
        Check_kegels();
        OnHit.Invoke(kegelsHit,curRound);
        if(kegelsHit == 10){
            ResetTriangle();
        }else{
            if(curRound == 1){
                ResetTriangle();
            }
            else{
                   curRound++;
            } 
        }
    }
    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag == "Ball"){
            m_hitted_ball = other.gameObject;
             StartCoroutine("Hit", 5.0F);
            new WaitForSeconds(2);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
