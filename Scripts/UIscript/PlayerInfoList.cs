using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfoList : MonoBehaviour
{
    public Image lifeBar;
    public Image energyBar;

    public ItemIcon Weapon;
    public ItemIcon LiftHand;
    public ItemIcon Arrom;
    public ItemIcon Book;

    public Text playerName;
    public Text playerLevel;
    public Text playerLife;

    readonly float MaxHeight = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetTextValue(string pname,string plevel)
    {
        playerName.text = pname;
        playerLevel.text = plevel;
    }

    public void SetLifeBarValue(float maxlife,float recentlife)
    {
        lifeBar.GetComponent<RectTransform>().sizeDelta = new Vector2(50,recentlife / maxlife * MaxHeight);
        playerLife.text = recentlife.ToString() + "/" + maxlife.ToString();
    }
}