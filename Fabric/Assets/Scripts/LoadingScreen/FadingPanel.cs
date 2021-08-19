using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class FadingPanel : MonoBehaviour
{

    [SerializeField] private CanvasGroup canvasGroup;
    [SerializeField] private Image img;

    private Tween _fadeTween;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(MakeFade());
    }
    

    public void FadeIn(float duration)
    {
        img.DOFade(1f, duration);
    }

    public void FadeOut(float duration)
    {
        Fade(0f, duration, () => { canvasGroup.interactable = false;
            canvasGroup.blocksRaycasts = false;
        });
    }

    private void Fade(float endValue, float duration, TweenCallback onEnd)
    {
        if (_fadeTween != null)
        {
            _fadeTween.Kill(false);
        }

        _fadeTween = canvasGroup.DOFade(endValue, duration);
        _fadeTween.onComplete += onEnd;
    }

    private IEnumerator MakeFade()
    {
        yield return new WaitForSeconds(1f);
        FadeIn(1f);
        yield return new WaitForSeconds(2f);
        FadeOut(1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene("GameScene");
    }
}
