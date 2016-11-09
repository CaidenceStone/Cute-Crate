using UnityEngine;

/// <summary>
/// Rotates the cuties.
/// </summary>
public class Wobble : MonoBehaviour
{
    /// <summary>How far to rotate.</summary>
    public float MaxAngle;

    /// <summary>Rate of rotation.</summary>
    public float Speed;

    /// <summary>How far to rotate in the other direction.</summary>
    private float _minAngle;

    /// <summary>Current rotation direction.</summary>
    private RotationDirection _direction;

    // Use this for initialization
    void Start()
    {
        _direction = RotationDirection.CLOCKWISE;
        _minAngle = 360 - MaxAngle;
    }

    void Update()
    {
        if (_direction == RotationDirection.CLOCKWISE)
        {
            gameObject.transform.Rotate(Vector3.forward * (Speed * Time.deltaTime));
            if (gameObject.transform.rotation.eulerAngles.z > MaxAngle &&
                gameObject.transform.rotation.eulerAngles.z < _minAngle)
            {
                _direction = RotationDirection.COUNTER_CLOCKWISE;
            }
        }
        else
        {
            gameObject.transform.Rotate(Vector3.forward * -(Speed * Time.deltaTime));
            Debug.Log("@@ = " + gameObject.transform.rotation.eulerAngles.z);
            if (gameObject.transform.rotation.eulerAngles.z < _minAngle &&
                gameObject.transform.rotation.eulerAngles.z > MaxAngle)
            {
                _direction = RotationDirection.CLOCKWISE;
            }
        }
    }
}

public enum RotationDirection
{
    CLOCKWISE,
    COUNTER_CLOCKWISE
}