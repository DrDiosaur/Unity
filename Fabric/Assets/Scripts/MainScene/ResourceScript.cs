using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ResourceScript : MonoBehaviour
{
    [SerializeField] private GameObject resource;
    [SerializeField] private CounterScript _counterScript;
    [SerializeField] private GameObject[] imgs;

    private void Awake()
    {
        for (int i = 0; i < imgs.Length; i++)
        {
            imgs[i] = Instantiate(resource, transform);
            imgs[i].SetActive(false);
        }
        
    }

    public void Mover()
    {
        StartCoroutine(SpawnAndMove());
    }

    public IEnumerator SpawnAndMove()
    {
        for (var i = 0; i < imgs.Length; i++)
        {
            
            imgs[i].SetActive(true);
            yield return new WaitForSeconds(0.1f);
            imgs[i].transform.DOMove(resource.transform.position, 2f).OnComplete(() => onComplete());

        }

    }

    private void onComplete()
    {
        foreach (var img in imgs)
        {
            img.SetActive(false);
            img.transform.DOMove(transform.position, 0.1f);
            
        }
        _counterScript.Counter(1f);
    }
}
