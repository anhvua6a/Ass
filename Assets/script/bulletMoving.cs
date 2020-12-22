using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMoving : MonoBehaviour {
    Transform bulletController;
    GameObject character;
    playerController playerController;
    public GameObject explo;
    AudioSource audio;
    

    // Start is called before the first frame update
    bool isRight = false;

    
    void Start () {

        bulletController = gameObject.GetComponent<Transform> ();
        character = GameObject.Find("character");
       
      //  bird = gameObject.tag("creed");
        playerController = character.GetComponent<playerController>();

        isRight = playerController.getIsRight();

        Destroy(gameObject, 2);
        Destroy(explo, 2);
    }

    // Update is called once per frame
    void Update () {
        // 1f : tốc độ bay của đạn
        // bulletController.Translate (Vector3.right * 1f, Space.World);
        // if (bulletController.position.x > 5f) {
        //  Destroy (gameObject);

        if (isRight)
        {
            transform.Translate(Vector3.right * 0.2f);
        }
        else
        {
            transform.Translate(Vector3.left * 0.2f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground" )
        {
            Destroy(gameObject);
            Instantiate(explo, bulletController.position, Quaternion.identity);
            audio.Play();

        }else if (collision.gameObject.name == "character")
        {
            
        }else if(collision.gameObject.tag == "creed")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            Instantiate(explo, bulletController.position, Quaternion.identity);
            audio.Play();
        }
    }


}
