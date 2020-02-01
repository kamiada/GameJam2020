using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    public float world_timer= 60.0f;
     public Text screen_timer;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        world_timer -= Time.deltaTime;
        screen_timer.text = world_timer.ToString();
        if(world_timer <= 0.0f)
        {
            //THE END
        }
    }
}
