using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public bool isRight = true;
    public GameObject bullet;
    public GameObject score;
    public GameObject AniPoint;

    Transform playerMoving;
    Animator animator;
    Rigidbody2D rigidbody;
    AudioSource audio;

    bool jump = false;
    public float Speed;
    public float jumpSpeed;
    // Start is called before the first frame update


    int number = 0;
    void Start()
    {
        playerMoving = gameObject.GetComponent<Transform>();
        animator = gameObject.GetComponent<Animator>();
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        score.GetComponent<UnityEngine.UI.Text>().text = number.ToString();
        if (Input.GetKey(KeyCode.A))
        {
            isRight = false;
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            transform.Translate(Vector3.left * Speed, Space.World);
            animator.SetBool("shot", true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
              //  animator.SetBool("run", false);
                animator.SetBool("jump", true);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(bullet, playerMoving.position, Quaternion.identity);
                animator.SetBool("shot", true);
            }
        }
        else if (Input.GetKey(KeyCode.D))
        {
            isRight = true;
            transform.rotation = Quaternion.Euler(0, 0, 0);
            transform.Translate(Vector3.right * Speed, Space.World);
            animator.SetBool("shot", true);
            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
              //  animator.SetBool("run", false);
                animator.SetBool("jump", true);
            }
            else if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(bullet, playerMoving.position, Quaternion.identity);
                animator.SetBool("shot", true);
            }

        }
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
            rigidbody.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Impulse);
           // animator.SetBool("run", false);
            animator.SetBool("jump", true);
            if (Input.GetKeyDown(KeyCode.F))
            {
                Instantiate(bullet, playerMoving.position, Quaternion.identity);
            }
        }
        else if (Input.GetKeyDown(KeyCode.F))
        {
            Instantiate(bullet, playerMoving.position, Quaternion.identity);
        }
        else
        {
            jump = false;
            animator.SetBool("run", false);
            animator.SetBool("jump", false);
            animator.SetBool("shot", false);
        }
    }
    public bool getIsRight()
    {
        return isRight;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
         if (collision.gameObject.tag == "point")
        {
            number++;
            Destroy(collision.gameObject);
            Instantiate(AniPoint, playerMoving.position, Quaternion.identity);
        }
    }
}
