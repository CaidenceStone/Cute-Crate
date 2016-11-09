using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

    public GameObject Box;

	// Use this for initialization
	void Start () {
        Screen.SetResolution(800, 800, false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        gameObject.SetActive(false);
        Box.SetActive(true);
    }

}
