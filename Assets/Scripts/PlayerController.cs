using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public float jump;
    private float moveInput;
    public Rigidbody2D rb;

    public KeyCode jumpKey;
    public string midJump = "n";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        //player movement
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);

        //jumping
        if ((Input.GetKeyDown(jumpKey)) && (midJump == "n"))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector3(0, 5, 0);
            midJump = "y";

        }

        if (GetComponent<Rigidbody2D>().velocity.y == 0)
        {
            midJump = "n";

        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "spike")
        {
            Scene scene;
            scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            if(transform.position.y>other.transform.position.y+1)
            transform.SetParent(other.transform);
        }
    }

    void OnCollisonExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Platform"))
        {
            transform.SetParent(null);
        }
    }
}
