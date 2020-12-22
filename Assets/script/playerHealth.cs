using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerHealth : MonoBehaviour
{

    public float MaxHealth;
    public float CurrentHealth;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth == 0)
        {
            SceneManager.LoadScene("SampleScene");
        }else if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = 10;
        }
    }
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if ( coll.gameObject.tag == "creed")
        {
            CurrentHealth--;
        }else if (coll.gameObject.tag == "point")
        {
            CurrentHealth++;
        }
    }
}
