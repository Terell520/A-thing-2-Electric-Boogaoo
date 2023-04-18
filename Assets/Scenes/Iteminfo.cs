using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Iteminfo : MonoBehaviour
{
    public string itemName;
    public int itemValue;

    PlayerControl playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerScript = GameObject.Find("player").GetComponent<PlayerControl>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseOver()
    {
        Debug.Log(itemName);
        playerScript.itemText.text = itemName;
    }

    void OnMouseDown()
    {
        playerScript.hasKey = true;
        Destroy(gameObject);
    }
}
