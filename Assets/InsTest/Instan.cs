using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Instan : MonoBehaviour
{
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(button, transform);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
