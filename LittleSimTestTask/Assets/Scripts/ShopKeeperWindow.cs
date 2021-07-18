using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopKeeperWindow : MonoBehaviour
{

    [SerializeField] private CanvasGroup _canvasGroup;

    [SerializeField]
    private ShopKeeperButton[] _shopKeeperButtons;
    
    [SerializeField]
    private Text pageNumber;
    
    private List<List<ShopKeeperItem>> pages = new List<List<ShopKeeperItem>>();

    

    private int pageIndex;
    public void CreatePages(ShopKeeperItem[] items)
    {
       List<ShopKeeperItem> page = new List<ShopKeeperItem>();

       for (int i = 0; i < items.Length; i++)
       {
           page.Add(items[i]);

           if (page.Count == 10 || i == items.Length - 1)
           {
               pages.Add(page);
               page = new List<ShopKeeperItem>();
           }
       }
       
       AddItems();
    }

    public void AddItems()
    {
        //for (int i = 0; i < items.Length; i++)
        //{
          //  _shopKeeperButtons[i].AddItem(items[i]);
        //}

        pageNumber.text = pageIndex + 1 + "/" + pages.Count;

        if (pages.Count > 0)
        {
            for (int i = 0; i < pages[pageIndex].Count; i++)
            {
                if (pages[pageIndex][i] != null)
                {
                    _shopKeeperButtons[i].AddItem(pages[pageIndex][i]);
                }   
            }
        }
    }
    
    public void Open()
    {
        _canvasGroup.alpha = 1;
        _canvasGroup.blocksRaycasts = true;
    }
    
    
    public void Close()
    {
        _canvasGroup.alpha = 0;
        _canvasGroup.blocksRaycasts = false;
    }

    public void NextPage()
    {
        if (pageIndex < pages.Count - 1)
        {
            pageIndex++;
            AddItems();
        }
    }

    public void PreviousPage()
    {
        if (pageIndex > 0)
        {
            pageIndex--;
            AddItems();
        }
    }

    public void ClearButtons()
    {
        foreach (var button in _shopKeeperButtons)
        {
            button.gameObject.SetActive(false);
        }
    }
}
