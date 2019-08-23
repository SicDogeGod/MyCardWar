using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FloatText : MonoBehaviour
{
    public float floatspeed;
    public Text selftext;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Awake()
    {
        floatspeed = Random.Range(1f,3f);
        Destroy(this.gameObject , 1f);
    }

    // Update is called once per frame
    void Update()
    {
        Floating();
    }

    public void SetFloatText(string str , Color colors)
    {
        selftext.text = str;
        selftext.color = colors;
    }

    void Floating()
    {
        this.transform.Translate(Vector2.up * Time.deltaTime * floatspeed);
    }
}
