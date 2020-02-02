using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float velocity;
    private Rigidbody2D rigiBody;
    bool facingRight; 
    private float movementHorizontal = 0f;
    private float movementVertical = 0f;
    public GameObject inventory;
    // Start is called before the first frame update
    void Start()
    {
        rigiBody = GetComponent<Rigidbody2D>();
        facingRight = true;
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        GoBackToMenu();
    }
    //void OnTriggerEnter2D(Collider2D other)
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "item" && Input.GetKey(KeyCode.Space))
        {
            //tries to get the component
            if(other.GetComponent<Item>() != null)
            {
                //add item to inventory
                GetComponent<Inventory>().hasItem = true;
                GetComponent<Inventory>().item = other.GetComponent<Item>().type;
                inventory.GetComponent<SpriteRenderer>().sprite = other.GetComponent<SpriteRenderer>().sprite;
                Destroy(other.gameObject);
            }
        }
    }
    public void Movement()
    {
        movementHorizontal = Input.GetAxis("Horizontal");
        if (movementHorizontal < 0)
        {
            rigiBody.velocity = new Vector3(movementHorizontal
                * velocity, rigiBody.velocity.y);
        }
        if (movementHorizontal > 0)
        {
            rigiBody.velocity = new Vector3(movementHorizontal *
            velocity, rigiBody.velocity.y);
        }
        if (movementHorizontal < 0 && facingRight)
        {
            Flipping();

        }
        if (movementHorizontal > 0 && !facingRight)
        {
            Flipping();
        }

        movementVertical = Input.GetAxis("Vertical");
        if (movementVertical < 0)
        {
            rigiBody.velocity = new Vector2(0, Mathf.Lerp(0, Input.GetAxis("Vertical") * velocity, 0.8f));
        }
        if (movementVertical > 0)
        {
            rigiBody.velocity = new Vector2(0, Mathf.Lerp(0, Input.GetAxis("Vertical") * velocity, 0.8f));
        }
    }

    public void Flipping()
    {
        facingRight = !facingRight;
        transform.Rotate(Vector3.up * 180);
    }

    public void GoBackToMenu()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
