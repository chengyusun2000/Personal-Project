using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    private AsyncOperation asy;

    public void BtnLoadScene(string s)
    {
        if (asy == null)
        {
            asy = SceneManager.LoadSceneAsync(s);
            asy.allowSceneActivation = true;
            Time.timeScale = 1f;
        }
    }
}
