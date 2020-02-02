using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using UnityEngine;

public class WorldTimer : MonoBehaviour
{
    float world_timer= 15.0f;
    float delay = 2.0f;
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
            delay -= Time.deltaTime;
            if(delay <=-0.0f)
            {
                LoadScene("GameOver");
            }
        }
    }
    public void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }
}
