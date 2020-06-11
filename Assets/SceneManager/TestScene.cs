using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class TestScene : MonoBehaviour
{
    public bool Done = false;
    private void Awake()
    {
        if (SceneManager.GetSceneByName("MainMap").isLoaded)
        {
            Scene scene = SceneManager.GetSceneByName("MainMap");
            if (scene != null)
            {
                foreach (GameObject gameObject in scene.GetRootGameObjects())
                {
                    gameObject.SetActive(false);
                }
            }
        }
        StartCoroutine(SetActive(SceneManager.GetSceneByName("TestInsScene")));
        StartCoroutine(SetDone());
        
    }
    private void OnEnable()
    {
        
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public IEnumerator SetActive(Scene scene)
    {
        int i = 0;
        while (i == 0)
        {
            i++;
            yield return null;
        }
        SceneManager.SetActiveScene(scene);
        yield break;
    }


    public IEnumerator SetDone()
    {
        int i = 0;
        while (i == 0)
        {
            i++;
            yield return null;
        }
        Done = true;
        yield break;
    }

    public void load()
    {
        SceneManager.SetActiveScene(SceneManager.GetSceneByName("Mainmap"));
        if (SceneManager.GetSceneByName("MainMap").isLoaded)
        {
            Scene scene = SceneManager.GetSceneByName("MainMap");
            if (scene != null)
            {
                foreach (GameObject gameObject in scene.GetRootGameObjects())
                {
                    if(gameObject.tag!="DontEnable")
                    {
                        gameObject.SetActive(true);
                    }
                    
                }
            }
        }
        SceneManager.UnloadSceneAsync("TestInsScene");
    }
}
