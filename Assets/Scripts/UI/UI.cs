using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image stressMeter;
    public GameObject shoppingListObject;
    private int open = 0;

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            OpenList();
        }
    }

    public void SubtractStressBar(float percentage)
    {
        stressMeter.fillAmount -= percentage;
    }
    public void AddStressBar(float percentage)
    {
        stressMeter.fillAmount += percentage;
    }
    private void OpenList()
    {
        if (open == 0)
        {
            shoppingListObject.SetActive(true);
            open = 1;
        }
        else
        {
            shoppingListObject.SetActive(false);
            open = 0;
        }
    }
}
