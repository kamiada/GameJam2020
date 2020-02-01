using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject player;
    public float countDown = 30.0f;
    System.Random rnd = new System.Random();
    System.Array values = ItemType.GetValues(typeof(ItemType));
    public GameObject inventory;
    public ItemType randomItem;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }


    //generate random picture
    void Update()
    {
        countDown -= Time.deltaTime;
        if(countDown <= 0.0f)
        {
            Debug.Log("Change picture");
            randomItem = (ItemType)values.GetValue(rnd.Next(values.Length));
            Debug.Log(randomItem.ToString());
            //text - bring me apple
            countDown = 30.0f;

        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player" && Input.GetKey(KeyCode.Space))
        {
            if(player.GetComponent<Inventory>().hasItem == true)
            {
                //check if this is requested item
                if (player.GetComponent<Inventory>().item == randomItem)
                {
                    Debug.Log("Yup");
                  //if yes - play hurray
                }
                else
                {
                    Debug.Log("Nae");
                    //if not - game over
                }
            }
        }
    }
}
