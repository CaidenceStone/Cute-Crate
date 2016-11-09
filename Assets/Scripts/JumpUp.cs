using System.Collections;
using UnityEngine;

public class JumpUp : MonoBehaviour
{
    /// <summary>Post-animation Y position.</summary>
    public float TargetYPosition;

    /// <summary>The rate per frame to move.</summary>
    public float YStep;

    /// <summary>Post-animation X and Y scale factors.</summary>
    public float TargetScale;

    /// <summary>The rate per frame to scale.</summary>
    public float ScaleStep;

    /// <summary>Pre-animation scale.</summary>
    private Vector3 _startingScale;

    /// <summary>Pre-animation position.</summary>
    private Vector3 _startingPosition;

    /// <summary>Acquire handles.</summary>
    void Start()
    {
        _startingScale = gameObject.transform.localScale;
        _startingPosition = gameObject.transform.position;
    }

    /// <summary>Reset the animation.</summary>
    public void Reset()
    {
        gameObject.transform.position = _startingPosition;
        gameObject.transform.localScale = _startingScale;
    }

    /// <summary>Begin the reveal animation.</summary>
    public void Animate()
    {
        StartCoroutine(MoveRoutine());
        StartCoroutine(ScaleRoutine());
    }

    /// <summary>Move the sprite upwards.</summary>
    /// <returns>Coroutine</returns>
    private IEnumerator MoveRoutine()
    {
        // Animate.
        while (gameObject.transform.position.y < TargetYPosition)
        {
            gameObject.transform.position = new Vector3(
                gameObject.transform.position.x,
                gameObject.transform.position.y + YStep,
                gameObject.transform.position.z);
            yield return new WaitForEndOfFrame();
        }
        gameObject.transform.position = new Vector3(
            gameObject.transform.position.x,
            TargetYPosition,
            gameObject.transform.position.z);
    }

    /// <summary>Scale the sprite.</summary>
    /// <returns>Coroutine</returns>
    private IEnumerator ScaleRoutine()
    {
        // Animate.
        while (gameObject.transform.localScale.x < TargetScale)
        {
            gameObject.transform.localScale = new Vector3(
                gameObject.transform.localScale.x + ScaleStep,
                gameObject.transform.localScale.y + ScaleStep,
                1);
            yield return new WaitForEndOfFrame();
        }
        gameObject.transform.localScale = new Vector3(TargetScale, TargetScale, 1);
    }
}
