using UnityEngine;
using System.Collections;

public class TitleScript : MonoBehaviour {

    public GameObject closedBox;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnMouseDown()
    {
        gameObject.SetActive(false);
        closedBox.SetActive(true);
    }

}
