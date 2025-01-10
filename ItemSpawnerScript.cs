using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnerScript : MonoBehaviour
{
    public GameObject Item;
    float timer;
    int ItemCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 20 && ItemCount < 1)
        {
            Instantiate(Item);
            ItemCount += 1;
        }
        
    }
}
