using UnityEngine;
using System.Collections;

public class BoxClosing : MonoBehaviour
{
    public GameObject boxClosed;
    public GameObject cutie;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseDown()
    {

        //hide the cutie and open box
        cutie.SetActive(false);
        gameObject.SetActive(false);

        //show the closed box and have it be ready again
        boxClosed.SetActive(true);

    }
        
}   


