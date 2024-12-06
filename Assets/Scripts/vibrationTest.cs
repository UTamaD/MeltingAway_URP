using UnityEngine;
using UnityEngine.InputSystem;
using System.Collections;

public class vibrationTest : MonoBehaviour
{
    public float duration = 10.0f;
    public float speed = 1f;
    public float amplitude = 1f;

    void Start()
    {
        StartCoroutine(Vibrate());
    }

    IEnumerator Vibrate()
    {
        Gamepad gamepad = Gamepad.current;
        if (gamepad == null)
        {
            Debug.LogError("Gamepad not found!");
            yield break;
        }

        gamepad.SetMotorSpeeds(speed, speed);

        yield return new WaitForSeconds(duration);

        gamepad.SetMotorSpeeds(0f, 0f);
    }
}
