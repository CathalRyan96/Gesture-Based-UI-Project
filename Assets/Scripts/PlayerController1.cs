using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController1 : MonoBehaviour {

    public float horizontal;

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

	

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            //if (transform.position.y > other.transform.position.y + 1)
                transform.SetParent(other.transform);
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
            transform.SetParent(null);
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Trap")
        {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }
}
