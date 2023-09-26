using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class carControl : MonoBehaviour
{
    public Text ScoreText;
    float scoreValue = 0;
    public Text HealthText;
    float healthValue = 100;

    public Text FuelText;
    float fuelValue = 100;
    // Start is called before the first frame update
    void Start()
    {
        ScoreText.text = "Score " + scoreValue.ToString();
        FuelText.text = "Fuel Value " + fuelValue.ToString();
        HealthText.text = "Health " + healthValue.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if ((Input.GetKey(KeyCode.W)) || (Input.GetKey(KeyCode.UpArrow)))
        {
            transform.Translate(Vector3.forward * Time.deltaTime * 100);
            scoreValue+=5;
             ScoreText.text = "Score" + scoreValue.ToString(); 

            fuelValue-=1;
            FuelText.text = "fUEL VALUE " + fuelValue.ToString();

        }
        if(Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
        {
            transform.Translate(Vector3.back * Time.deltaTime * 100);
        }
        if(Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
        {
            transform.Rotate(Vector3.down * Time.deltaTime * 100);
        }
        if(Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * 100);
        }

        Vector3 pos = transform.position;
        if(pos.z > 80)
        {
            pos.z = -120;
            transform.position = pos;
        }
        
        if(pos.z < -160)
        {
            pos.z = -120;
            transform.position = pos;
        }

        if (fuelValue <= 0)
        {
            SceneManager.LoadScene("gameOver");
        }

    }

    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.name.StartsWith("car"))
        {
            healthValue -=5;
            HealthText.text = "Health " + healthValue.ToString();
            SceneManager.LoadScene("gameOver");
        }

           if(collision.gameObject.name.StartsWith("fuelDrum")){
            fuelValue = 100;
            FuelText.text = "Fuel Value" + fuelValue.ToString();
        }
    }

    public void reload(){
        SceneManager.LoadScene("SampleScene");
    }
}
