using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSelect : MonoBehaviour
{
	public GameObject[] panels;
	public Selectable[] defaultButtons;

	public void PanelToggle()
	{
		PanelToggle(0);
	}

	public void PanelToggle(int position)
	{
		Input.ResetInputAxes();
		for (int i = 0; i < panels.Length; i++)
		{
			panels[i].SetActive(position == i);
			if (position == i)
			{
				defaultButtons[i].Select();
			}
		}
	}

	// Start is called before the first frame update
	void Start()
	{
		Invoke("PanelToggle", 1f);
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
