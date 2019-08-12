using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterLifeBar : MonoBehaviour
{
    public Image BackGround;
    public Image RecentLife;

    public Text MonsterName;

    float testfloatl = 1f;


    float MaxWidth = 400f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //SetLifeBar(testfloatl);
    }

    public void SetLifeBarValue(float lifepercent)
    {
        testfloatl = lifepercent;
    }
    /*
    public void SetLifeBar(float lifepercent)
    {
        RecentLife.GetComponent<RectTransform>().sizeDelta =new Vector2(lifepercent * MaxWidth,10) ;
    }
    public void SetMonsterName(string strname)
    {
        MonsterName.text = strname;
    }
    */
}
