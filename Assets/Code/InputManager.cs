using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputManager : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    public TextMeshProUGUI scoreText;

    public Slider powerSlider;
    public bool phoneIsAttached = true;
    public Transform bulletSpawn;
    public Rigidbody2D bullet;
    public float minPower = 50f, maxPower = 200f;

    public int score = 0;

    //these should be private
    public float timer = 0;
    public bool mouseIsDown = false;
    
    // Start is called before the first frame update
    void Start()
    {
        debugText.text = "Input Mgr Connected!";
        timer = minPower;
    }

    // Update is called once per frame
    void Update()
    {
        if(phoneIsAttached){
            if(Input.touchCount > 0){
                Touch touch = Input.GetTouch(0);
                debugText.text = "Pressed! Timer = " + timer;
                timer += Time.deltaTime * 50;
                powerSlider.value = timer;
                
                if(touch.phase == TouchPhase.Ended){
                    debugText.text = "Timer = " + timer;
                    Shoot();
                }
            }
        }
        else{
            if(Input.GetKeyDown(KeyCode.Mouse0)){
                debugText.text = "You are clicking the screen!";
                mouseIsDown = true;
                
            }
            if(Input.GetKeyUp(KeyCode.Mouse0)){
                mouseIsDown = false;
                debugText.text = "Timer = " + timer;
                Shoot();
            }
            if(mouseIsDown){
                timer += Time.deltaTime * 50;
                powerSlider.value = timer;
                debugText.text = "Clicked! Timer = " + timer;
            }
        }
    }
    void Shoot(){
        if(timer > maxPower) timer = maxPower;

        debugText.text = "Pow! Power = " + timer.ToString("0.00");

        Rigidbody2D rb = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
        rb.AddRelativeForce(Vector2.up * 10 * timer);
        timer = minPower;
        powerSlider.value = timer;
    }

    public void UpdateScore(int givenScore){
        score += givenScore;
        scoreText.text = "Score: " + score.ToString();
    }
}
