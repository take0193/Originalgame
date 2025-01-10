using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerManager2 : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpPower = 5.0f;
    int jumpCount;
    Animator animator;
    Collider weaponCollider;
    public Image hpimage;
    float maxHP = 100;
    public static float currentHP = 100;
    bool RightMove;
    bool LeftMove;
    public GameObject Hadou2;
    int HadouCount;

    // Start is called before the first frame update
    void Start()
    {
        animator = this.GetComponent<Animator>();
        weaponCollider = GameObject.Find("OHS03").GetComponent<BoxCollider>();
        currentHP = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey("right") == true || RightMove == true)
        {
            this.transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
            this.transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if(Input.GetKey("left") == true || LeftMove == true)
        {
            this.transform.position -= new Vector3(speed * Time.deltaTime, 0, 0);
            this.transform.rotation = Quaternion.Euler(0, 270, 0);
        }
        if(Input.GetKeyDown("space") == true)
        {
            JumpButtonDown();
        }
        if (Input.GetKeyDown("right"))
        {
            animator.SetBool("Running", true);
        }
        if (Input.GetKeyUp("right"))
        {
            animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown("left"))
        {
            animator.SetBool("Running", true);
        }
        if (Input.GetKeyUp("left"))
        {
            animator.SetBool("Running", false);
        }
        if (Input.GetKeyDown("space"))
        {
            animator.SetBool("Jump", true);
        }
        if (Input.GetKeyUp("space"))
        {
            animator.SetBool("Jump", false);
        }
        if (Input.GetKeyDown("up"))
        {
            animator.SetBool("Attack", true);
            weaponCollider.enabled = true;
            Invoke("ColliderReset", 0.3f);
        }
        if (Input.GetKeyUp("up"))
        {
            animator.SetBool("Attack", false);
        }
        if (Input.GetKeyDown("down"))
        {
            animator.SetBool("Hadou", true);
        }
        if (Input.GetKeyUp("down"))
        {
            animator.SetBool("Hadou", false);
        }

        float moveX = Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        float moveY = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x + moveX, -10.0f, 10.0f),
            Mathf.Clamp(transform.position.y + moveY, -10.0f, 10.0f)
           
            );

        if(currentHP <= 0)
        {
            SceneManager.LoadScene("EndScene_Lose");
        }

    }


    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.tag == "Ground")
        {
            jumpCount = 0;
        }
        if(col.gameObject.tag == "Item")
        {
            Destroy(col.gameObject);
            if(currentHP < 100)
            {
                currentHP += 40;
                hpimage.fillAmount = currentHP / maxHP;
            }
        }
        if(col.gameObject.tag == "Enemyarm")
        {
            currentHP -= 12;
            hpimage.fillAmount = currentHP / maxHP;
            animator.SetBool("Damage", true);
            Invoke("Damage", 0.3f);
        }
        
    }
    void ColliderReset()
    {
        weaponCollider.enabled = false;
    }
    void Damage()
    {
        animator.SetBool("Damage", false);
    }
    public void RightButtonDown()
    {
        RightMove = true;
        animator.SetBool("Running", true);
    }
    public void RightButtonUp()
    {
        RightMove = false;
        animator.SetBool("Running", false);
    }
    public void LeftButtonDown()
    {
        LeftMove = true;
        animator.SetBool("Running", true);
    }
    public void LeftButtonUp()
    {
        LeftMove = false;
        animator.SetBool("Running", false);
    }
    public void JumpButtonDown()
    {
        if(jumpCount < 3)
        {
            this.GetComponent<Rigidbody>().velocity = new Vector3(0, jumpPower, 0);
            jumpCount += 1;
        }
        animator.SetBool("Jump", true);
    }
    public void JumpButtonUp()
    {
        animator.SetBool("Jump", false);
    }
    public void KinkyoriButtonDown()
    {
        animator.SetBool("Attack", true);
        weaponCollider.enabled = true;
        Invoke("ColliderReset", 0.3f);
    }
    public void KinkyoriButtonUp()
    {
        animator.SetBool("Attack", false);
    }
    public void EnkyoriButtonDown()
    {
        animator.SetBool("Hadou", true);
        if(HadouCount < 5)
        {
            Instantiate(Hadou2, this.transform.position, this.transform.rotation);
            HadouCount += 1;

        }
    }
    public void EnkyoriButtonUp()
    {
        animator.SetBool("Hadou", false);
    }
}
