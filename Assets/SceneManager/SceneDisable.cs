using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class SceneDisable : MonoBehaviour
{

    // Start is called before the first frame update
    private void Awake()
    {
       
        if (SceneManager.GetSceneByName("Town").isLoaded)
        {
            Scene scene1 = SceneManager.GetSceneByName("Town");
            if (scene1 != null)
            {
                foreach (GameObject gameObject in scene1.GetRootGameObjects())
                {
                    gameObject.SetActive(false);
                }
            }
        }
            


    }
    private void OnEnable()
    {
        if (SceneManager.GetSceneByName("TestInsScene").isLoaded)
        {
            Scene scene = SceneManager.GetSceneByName("TestInsScene");
            if (scene != null)
            {
                foreach (GameObject gameObject in scene.GetRootGameObjects())
                {
                    gameObject.SetActive(false);
                }
            }
        }
    }
    void Start()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMap"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
