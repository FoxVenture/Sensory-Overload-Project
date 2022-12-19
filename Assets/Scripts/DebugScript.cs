using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DebugScript : MonoBehaviour
{
    public GridLayoutGroup grid;
    public GameObject textPrefab;
 
    //Init variables
    void Start()
    {

    }

    public void AddItem(string text)
    {
        GameObject newText = Instantiate(textPrefab,transform.position,transform.rotation) as GameObject;
        newText.transform.SetParent(grid.transform, false);
        Text t = newText.GetComponent<Text>();
        t.text = text;
    }

}
