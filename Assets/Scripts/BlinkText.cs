using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BlinkText : MonoBehaviour
{
    public float blinkTime = 0.5f;
    public float minAlpha = 0.3f;
    public float maxAlpha = 1f;
    private TMP_Text textMesh;

    private void Start()
    {
        textMesh = GetComponent<TMP_Text>();
        StartCoroutine(Blink());
    }

    private IEnumerator Blink()
    {
        Color color = textMesh.color;

        while (true)
        {
            yield return new WaitForSeconds(blinkTime);

            float alpha = textMesh.color.a == maxAlpha ? minAlpha : maxAlpha;

            while (textMesh.color.a != alpha)
            {
                color.a = Mathf.MoveTowards(textMesh.color.a, alpha, Time.deltaTime / blinkTime);
                textMesh.color = color;
                yield return null;
            }
        }
    }
}
