using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Gold : MonoBehaviour
{
    [Header("Currency System")]
    public int currentGold = 1000;
    public TMP_Text goldText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyGold(int amount)
    {
        currentGold += amount;
        UpdateGoldUI();
    }
    void UpdateGoldUI()
    {
        if (goldText != null)
        {
            // "1,000 G" 처럼 천 단위 쉼표(N0)를 넣어줍니다.
            goldText.text = currentGold.ToString("N0") + " G";
        }
    }

}
