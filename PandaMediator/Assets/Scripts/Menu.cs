using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public void LoadScene(string SceneName)
    {
        EditorSceneManager.LoadScene(SceneName);
    }
}
