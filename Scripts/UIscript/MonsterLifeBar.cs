using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MonsterLifeBar : MonoBehaviour
{
    public Image BackGround;
    public Image RecentLife;

    public Text MonsterName;

    readonly float MaxWidth = 400f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetLifeBarValue(float lifeall,float lifenow)
    {
        RecentLife.GetComponent<RectTransform>().sizeDelta = new Vector2(lifenow / lifeall * MaxWidth, 10);
    }

    public void SetMonsterName(string strname)
    {
        MonsterName.text = strname;
    }
}
