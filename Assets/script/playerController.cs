using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour {

    public GameObject swings;
    public bool isRight = true;

    public GameObject score;
    public GameObject paticle;
    public GameObject phitieu;
public float speed;
    public float distance;
    public bool isClimbing;

    public float inputVetical;
    public float inputHorizontal;

    

    

    Transform playerMoving;
    Animator animator;
    Rigidbody2D rigidbody;
    AudioSource audio;



    int number = 0;
    int IDLE = 0;

    int RUNNING = 1;

    // isGround
    
    public LayerMask whatIsLadder;

    
    // Start is called before the first frame update
    void Start () {
        playerMoving = gameObject.GetComponent<Transform> ();
        animator = gameObject.GetComponent<Animator> ();
      //  score = GameObject.Find("score");
        rigidbody = gameObject.GetComponent<Rigidbody2D>();
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {

        score.GetComponent<UnityEngine.UI.Text>().text = number.ToString();

        //isGrounded
        // isGrounded = Physics2D.OverlapArea(new Vector2(transform.position.x - 0.5f, transform.position.y - 0.5f),
         //   new Vector2(transform.position.x + 0.5f, transform.position.y - 0.5f), groudLayers);


        // GetKeyDown chỉ xảy ra 1 lần
        // bắn đạn
        if (Input.GetKeyDown (KeyCode.F)) {
            Instantiate (swings, playerMoving.position, Quaternion.identity);
           // animator.SetBool("attack", true);
        }

        // di chuyển sang trái
        else if (Input.GetKey (KeyCode.A)) 
        {
            isRight = false;
            // xoay ngược lại: mirror
            transform.rotation = Quaternion.Euler(0, 180f, 0);
            

            transform.Translate(Vector3.left * 0.2f, Space.World);
            // đổi sang trạng thái đi bộ
            animator.SetBool ("run", true);
           // animator.SetBool("attack", false);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
              //  animator.SetBool("jump", true);
                animator.SetBool("move", false);
            }

        }
        // di chuyển sang phải
        else if (Input.GetKey (KeyCode.D)) {
            isRight = true;
            animator.SetBool ("move", true);
         //   animator.SetBool("attack", false);

            //quay đầu
            transform.rotation = Quaternion.Euler(0, 0, 0);

            playerMoving.Translate (Vector3.right * 0.2f,Space.World);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                rigidbody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);

             //   animator.SetBool("jump", true);
                animator.SetBool("move", false);
            }
        }
        // nhảy
        else if (Input.GetKeyDown (KeyCode.Space)) {
            rigidbody.AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
         //   animator.SetBool("jump", true);
            animator.SetBool("move", false);
        }

        
        else
        {
            animator.SetBool("move", false);
          //  animator.SetBool("jump", false);
          //  animator.SetBool("attack", false);
        }
        
    }
    public bool getIsRight()
    {
        return isRight;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        /*if(coll.gameObject.tag == "star")
        {
            number++;
            Destroy(coll.gameObject);
            Instantiate(paticle, transform.position, Quaternion.identity);
            audio.Play();
            
        }else if(coll.gameObject.name == "door")
        {
            SceneManager.LoadScene("Cave1");
        }else if(coll.gameObject.tag == "lava" || coll.gameObject.tag == "creed")
        {
           
        }*/
        
        
    }
    /* void FixedUpdate()
    {
        inputHorizontal = Input.GetAxisRaw("Horizontal");
        rigidbody.velocity = new Vector2(inputHorizontal * 0.1f, rigidbody.velocity.y);

        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position,Vector2.up,distance,whatIsLadder);
          if(hitInfo.collider != null)
        {
            if (Input.GetKeyDown(KeyCode.W))
            {
                isClimbing = true;
            }
            
            
        }
          if(isClimbing == true && hitInfo.collider != null)
        {
            inputVetical = Input.GetAxisRaw("Vertical");
            rigidbody.velocity = new Vector2(rigidbody.position.x, inputVetical * 0.1f);
            rigidbody.gravityScale = 0;
        }
        else
        {
            rigidbody.gravityScale = 2;
        }

    }
*/

}