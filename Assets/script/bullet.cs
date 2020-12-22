using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    Transform bulletController;
    GameObject character;
    player player;
    public GameObject audio;
    public GameObject ammo;
    public GameObject explo;

    bool isRight = false;
    // Start is called before the first frame update
    void Start()
    {
        bulletController = gameObject.GetComponent<Transform>();
        character = GameObject.Find("character");

        player = character.GetComponent<player>();

        isRight = player.getIsRight();

        Destroy(gameObject, 2);
        Destroy(explo, 2);


    }

    // Update is called once per frame
    void Update()
    {
        if (isRight)
        {
            transform.Translate(Vector3.right * 0.4f);
        }
        else
        {
            transform.Translate(Vector3.left * 0.4f);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ground")
        {
            Destroy(gameObject);
            Instantiate(explo, bulletController.position, Quaternion.identity);
            

        }
        else if (collision.gameObject.tag == "creed")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
            Instantiate(ammo, bulletController.position, Quaternion.identity);


        }
    }
}
