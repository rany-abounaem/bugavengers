using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{

    public Slider playerHpSlider;
    public TextMeshProUGUI hpValueText, expValueText, levelValueText;


    // Start is called before the first frame update
    void Start()
    {
        PlayerStats.instance.hpUpdated.AddListener(() => UpdatePlayerHpUI());
        PlayerStats.instance.maxHpUpdated.AddListener(() => UpdatePlayerHpUI());
        PlayerStats.instance.levelUpdated.AddListener(() => UpdatePlayerLvlUI());
        PlayerStats.instance.expUpdated.AddListener(() => UpdatePlayerExpUI());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void UpdatePlayerHpUI()
    {
        playerHpSlider.value = (float) (PlayerStats.instance.health / PlayerStats.instance.maxHealth);
        hpValueText.text = PlayerStats.instance.health.ToString();

    }

    void UpdatePlayerLvlUI()
    {
        levelValueText.text = PlayerStats.instance.level.ToString();
    }

    void UpdatePlayerExpUI()
    {
        expValueText.text = PlayerStats.instance.experience.ToString();
    }

}
