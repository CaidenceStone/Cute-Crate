using System.Collections;
using UnityEngine;

public class TitleScript : MonoBehaviour
{
    /// <summary>The Cute Crate to activate on click.</summary>
    public GameObject Box;

    /// <summary>How much to fade out each step.</summary>
    public float AlphaStep;

    /// <summary>Handle to the title screen's renderer.</summary>
    private SpriteRenderer _titleSpriteRenderer;

    /// <summary>Force correct resolution and aqcuire handles.</summary>
    void Start()
    {
        Screen.SetResolution(800, 800, false);

        _titleSpriteRenderer = gameObject.GetComponent<SpriteRenderer>();
        if (null == _titleSpriteRenderer)
        {
            Debug.LogError("No renderer on title screen object!");
        }
    }

    /// <summary>Begin the game on click.</summary>
    void OnMouseDown()
    {
        StartCoroutine(CrossfadeAndLaunch());
    }

    /// <summary>Launch the game after crossfading the titlescreen to the Cute Crate!</summary>
    /// <returns>Coroutine</returns>
    private IEnumerator CrossfadeAndLaunch()
    {
        // Activate the game.
        Box.SetActive(true);

        // Cross fade.
        while (_titleSpriteRenderer.color.a > AlphaStep)
        {
            _titleSpriteRenderer.color = new Color(
                _titleSpriteRenderer.color.r,
                _titleSpriteRenderer.color.g,
                _titleSpriteRenderer.color.b,
                _titleSpriteRenderer.color.a - AlphaStep);
            yield return new WaitForEndOfFrame();
        }

        // Deactivate the title screen.
        gameObject.SetActive(false);
    }
}
