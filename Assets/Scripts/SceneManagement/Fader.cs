using System.Collections;
using UnityEngine;

namespace RPG.SceneManagement
{
    public class Fader : MonoBehaviour
    {
        CanvasGroup canvasGroup;
        Coroutine currentActiveFade = null;

        private void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void FadeOutImmediate()
        {
            canvasGroup.alpha = 1;
        }

        public IEnumerator FadeOut(float time)
        {
            return Fade(1, time);

        }

        public IEnumerator Fade(float target, float time)
        {
            // Cancel running coroutines
            if (currentActiveFade != null)
            {
                StopCoroutine(currentActiveFade);
            }
            // Run fadeout coroutine
            currentActiveFade = StartCoroutine(FadeRoutine(target, time));
            yield return currentActiveFade;
        }
        
        private IEnumerator FadeRoutine(float target, float time)
        {
            while (Mathf.Approximately(canvasGroup.alpha, target)) 
            {
                // moving alpha toward 1
                canvasGroup.alpha += Mathf.MoveTowards(canvasGroup.alpha, target, Time.deltaTime / time);
                yield return null;
            }
        }

        public IEnumerator FadeIn(float time)
        {
            return Fade(0, time);
        }
    }
}