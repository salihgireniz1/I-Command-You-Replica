using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoSingleton<UIManager>
{
    public GameObject winPanel;
    public GameObject losePanel;

    public float waitTime;

    public void WinPanel()
    {
        StartCoroutine(ChangePanel(winPanel));
    }
    public void LosePanel()
    {
        StartCoroutine(ChangePanel(losePanel));
    }
    IEnumerator ChangePanel(GameObject panel)
    {
        yield return new WaitForSeconds(waitTime);
        panel.SetActive(true);
    }
}
