using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerScript : MonoBehaviour
{
    int count;
    public Text timerText;
    float timer = 60f;
    

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = timer.ToString("f0");
        if(timer < 0 && PlayerManager.currentHP > EnemyManager.currentHP2)
        {
            timer = 0;
            timerText.text = timer.ToString("f0");
            SceneManager.LoadScene("EndScene_Win");
        }
        if (timer < 0 && PlayerManager.currentHP <= EnemyManager.currentHP2)
        {
            timer = 0;
            timerText.text = timer.ToString("f0");
            SceneManager.LoadScene("EndScene_Lose");
        }
    }
}
