using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SellManager : MonoBehaviour
{
    [SerializeField] Animation shipToGo;
    [SerializeField] GameObject winPanel;


    private void OnMouseUp()
    {
        shipToGo.Play();
        StartCoroutine(showWinPanel());
    }




    IEnumerator showWinPanel()
    {
        yield return new WaitForSeconds(6f);
        winPanel.SetActive(true);
    }


}
