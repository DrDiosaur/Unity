using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ProgressBarAnimation : MonoBehaviour
{
    
    [SerializeField] private ResourceScript _resourceScript;
    [SerializeField] private CounterScript _counterScript;
    [SerializeField] private AlertScript _alertScript;

    private VisualElement m_Root;
    private VisualElement m_ProducingProgressBar;
    private Label m_ProducingPercentageText;
    private bool isProducing = false;
    
    public float neededResources;

    
    
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        m_Root = GetComponent<UIDocument>().rootVisualElement;

        m_ProducingProgressBar = m_Root.Q<VisualElement>("Bar_Progress");
        m_ProducingPercentageText = m_Root.Q<Label>("txt_percentage");

        m_Root.style.visibility = Visibility.Hidden;
    }

    public void AnimateProgressBar(float duration)
    {
        if (isProducing == false && _counterScript._startNum >= neededResources - 1)
        {
            StartCoroutine(AnimateUI(duration));
            
            _counterScript.Counter(-neededResources);
        }else
        {
            _alertScript.ShowText();
        }
    }

    private IEnumerator AnimateUI(float duration)
    {
        m_Root.style.visibility = Visibility.Visible;
        isProducing = true;
        
        float endWidth = m_ProducingProgressBar.parent.worldBound.width - 25;
        
        DOTween.To(() => 5, x  => m_ProducingPercentageText.text = $"{x}%", 100, duration).SetEase(Ease.Linear).OnComplete(() => _resourceScript.Mover());
        
        DOTween.To(() => m_ProducingProgressBar.worldBound.width, x  => m_ProducingProgressBar.style.width = x, endWidth, duration).SetEase(Ease.Linear);
        
        yield return new WaitForSeconds(duration + 1f);

        m_Root.style.visibility = Visibility.Hidden;
        m_ProducingProgressBar.style.width = 0;
        isProducing = false;
        
    }

    
    
    

    
}
