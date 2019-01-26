using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Image stressMeter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SubtractStressBar(float percentage)
    {
        stressMeter.fillAmount -= percentage;
    }
    public void AddStressBar(float percentage)
    {
        stressMeter.fillAmount += percentage;
    }
}
