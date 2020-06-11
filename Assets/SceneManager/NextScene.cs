using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class NextScene : MonoBehaviour
{
    private Scene scene;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("yes");
        if (collision.tag == "Player")
        {
            
            SceneManager.LoadScene("MainMap", LoadSceneMode.Additive);
            scene = SceneManager.GetSceneByName("Town");
            //if (SceneManager.GetSceneByName("MainMap").isLoaded)
            //{
            //foreach (GameObject gameObject in scene.GetRootGameObjects())
            //    {
            //        gameObject.SetActive(false);
            //    }

            //}
            //SceneManager.SetActiveScene(SceneManager.GetSceneByName("MainMap"));


            //StartCoroutine(SetActive(SceneManager.GetSceneByName("MainMap")));



        }
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
}
