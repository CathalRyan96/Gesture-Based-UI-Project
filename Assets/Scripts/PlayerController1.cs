using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
