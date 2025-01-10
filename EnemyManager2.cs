using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyManager2 : MonoBehaviour
{
    public Image hpimage;
    float maxHP = 100;
    public static float currentHP2 = 100;
    Animator animator;
    public GameObject target;
    NavMeshAgent agent;
    Collider enemyattackCollider;
    public float speed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        enemyattackCollider = GameObject.Find("Glove01").GetComponent<BoxCollider>();
        currentHP2 = 100;

    }

    // Update is called once per frame
    void Update()
    {
        agent.destination = target.transform.position;

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + moveX, -10.0f, 10.0f),
            Mathf.Clamp(transform.position.y + moveY, -10.0f, 10.0f)

            );

        if (currentHP2 <= 0)
        {
            SceneManager.LoadScene("EndScene_Win");
        }
    }
    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Weapon")
        {
            
            currentHP2 -= 5;
            hpimage.fillAmount = currentHP2 / maxHP;
            animator.SetBool("Damage_Enemy", true);
            Invoke("Damage", 0.3f);
            

        }
        if (col.gameObject.tag == "Hadou2")
        {
            currentHP2 -= 8;
            hpimage.fillAmount = currentHP2 / maxHP;
            Destroy(col.gameObject);
            animator.SetBool("Damage_Enemy", true);
            Invoke("Damage", 0.3f);
        }
        
    }
    void Damage()
    {
        animator.SetBool("Damage_Enemy", false);
    }
    public void AttackStart()
    {
        animator.SetBool("Attack_Enemy", true);
        enemyattackCollider.enabled = true;
        Invoke("enemyattackColliderReset", 3f);
    }
    public void AttackEnd()
    {
        animator.SetBool("Attack_Enemy", false);
    }
    void enemyattackColliderReset()
    {
        enemyattackCollider.enabled = false;
    }
}
