using UnityEngine;

public class BoxClosing : MonoBehaviour
{
    public GameObject boxClosed;
    public GameObject cutie;
    private JumpUp jumpUp;

    void Start()
    {
        if (null == boxClosed)
        {
            Debug.LogError("BoxClosed game object not attached to BoxClosing!");
        }
        if (null == cutie)
        {
            Debug.LogError("Cutie game object not attached to BoxClosing!");
        }
        else
        {
            jumpUp = cutie.GetComponent<JumpUp>();
            if (null == jumpUp)
            {
                Debug.LogError("BoxClosing could not find JumpUp on Cutie object!");
            }
        }
    }

    void OnMouseDown()
    {
        // hide the cutie and open box
        cutie.SetActive(false);
        gameObject.SetActive(false);

        // reset animation
        jumpUp.Reset();

        // show the closed box and have it be ready again
        boxClosed.SetActive(true);
    }
}   


