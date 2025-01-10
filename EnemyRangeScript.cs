using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeScript : MonoBehaviour
{
    public EnemyManager enemyManager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Player")
        {
            Invoke("AttackStart_Enemy", 0f);
            Invoke("AttackEnd_Enemy", 3f);
        }
    }
    public void AttackStart_Enemy()
    {
        enemyManager.AttackStart();
    }
    public void AttackEnd_Enemy()
    {
        enemyManager.AttackEnd();
    }
}
