using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    // Start is called before the first frame update
    public Rigidbody rd;
    public int score = 0;
    public bool finished = false;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI winText;
    void Start()
    {
        Debug.Log("start");
        rd = GetComponent<Rigidbody>();
        scoreText.text = "score:" + score;
        //winText.text = "you win!";
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal"); //ad
        float v = Input.GetAxis("Vertical"); //ws
        rd.AddForce(new Vector3(h,0,v));
        // Debug.Log("update");
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("restart");
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }else if (Input.GetKeyDown(KeyCode.C)){
            if(!finished) {
                Debug.Log("continue");
                winText.gameObject.SetActive(false);
                Time.timeScale = 1;
            }
            
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.tag == "Food")
        {
            Destroy(collision.gameObject);
            score++;
            scoreText.text = "score:" + score;

            if(score == 12)
            {
                winText.gameObject.SetActive(true);

            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("trigger");
        if (other.tag == "Food")
        {
            Destroy(other.gameObject);
            score++;
            scoreText.text = "score:" + score;

            if (score == 14 ||  other.name == "diamond")
            {
                winText.gameObject.SetActive(true);
                Time.timeScale = 0;

            }else if(other.name == "champion"){
                winText.text = "you are the champion!!!\n Press R to restart the game.";
                finished = true;
                winText.gameObject.SetActive(true);
                Time.timeScale = 0;
            }


        }
    }
}
