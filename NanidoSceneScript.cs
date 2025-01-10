using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NanidoSceneScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void DerutaButton()
    {
        SceneManager.LoadScene("SampleSceneEasy");

    }
    public void OmikuronButton()
    {
        SceneManager.LoadScene("SampleSceneDiffi");

    }
}
