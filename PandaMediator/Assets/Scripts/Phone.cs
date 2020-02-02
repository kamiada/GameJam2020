using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Phone : MonoBehaviour
{
    public GameObject player;
    private float countDown = 1.0f;
    System.Random rnd = new System.Random();
    System.Array values = ItemType.GetValues(typeof(ItemType));
    public GameObject inventory;
    public ItemType randomItem;
    public Text cloud_text;
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        inventory = GameObject.FindGameObjectWithTag("Inventory");
    }


    //generate random picture
    void Update()
    {
        countDown -= Time.deltaTime;
        cloud_text.text = "I demand " + randomItem.ToString();
        if (countDown <= 0.0f)
        {
            randomItem = (ItemType)values.GetValue(rnd.Next(values.Length));
            cloud_text.text = "I demand " + randomItem.ToString();
            countDown = 4.0f;
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
                    cloud_text.text = "I am happy. For now";
                    inventory.GetComponent<SpriteRenderer>().sprite = null;
                }
                else
                {
                    cloud_text.text = "No, you imbecile!";
                }
            }
        }
    }
}
