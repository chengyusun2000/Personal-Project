using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private AsyncOperation asy;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BtnLoadScene(string s)
    {
        //Cursor.visible = true;
        if (asy == null)
        {
            asy = SceneManager.LoadSceneAsync(s);
            asy.allowSceneActivation = true;
            Time.timeScale = 1f;
        }
    }
}
