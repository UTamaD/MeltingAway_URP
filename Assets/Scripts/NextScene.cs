using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if ENABLE_INPUT_SYSTEM && STARTER_ASSETS_PACKAGES_CHECKED
using UnityEngine.InputSystem;
#endif

public class NextScene : MonoBehaviour
{
    private StarterAssets.StarterAssetsInputs _input;
    public string sceneName;
    public RawImage fadeImage;
    public float fadeDuration = 0.5f;

    private bool isTransitioning = false;
    private void Start()
    {
        _input = GetComponent<StarterAssets.StarterAssetsInputs>();
    }
    private IEnumerator TransitionCoroutine()
    {
        // ∆‰¿ÃµÂ æ∆øÙ

        if (fadeImage != null)
        {

            fadeImage.gameObject.SetActive(true);
            fadeImage.color = Color.clear;


            float timer = 0;
            while (timer < fadeDuration)
            {
                timer += Time.deltaTime;
                float alpha = Mathf.Lerp(0, 1, timer / fadeDuration);
                fadeImage.color = new Color(0, 0, 0, alpha);
                yield return null;
            }




            fadeImage.gameObject.SetActive(false);
        }
        isTransitioning = false;

        // æ¿ ¿¸»Ø
        if (sceneName != null)
        {
            SceneManager.LoadScene(sceneName);
        }


        yield return null;
    }

    private void Update()
    {
        if ((_input.next == true) && !isTransitioning)
        {
            isTransitioning = true;
            _input.next = false;
            StartCoroutine(TransitionCoroutine());
            
        }

        if ((_input.reset == true) )
        {
            _input.reset = false;
            SceneManager.LoadScene("title");

        }
    }
}
