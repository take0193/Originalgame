using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSpawnerScript : MonoBehaviour
{
    public GameObject Hadou;
    int HadouCount;
    public PlayerManager playerManager;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("down") == true && HadouCount < 5)
        {
            Instantiate(Hadou, this.transform.position, this.transform.rotation);
            HadouCount += 1;
        }
    }
}
