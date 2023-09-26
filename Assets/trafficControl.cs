using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class trafficControl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate (0, 0, 0.8f);
        
      Vector3 pos = transform.position;
        if(pos.z > 70)
        {
            pos.z = -120;
            transform.position = pos;
        }
        
        if(pos.z < -140)
        {
            pos.z = -110;
            transform.position = pos;
        }
    }

      private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name.StartsWith("MyCar"))
        {
            SceneManager.LoadScene("gameOver");
        }
      }


}
