using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Scripts : MonoBehaviour
{//[SerializeField] 
    int money_count = 0, click_count = 1, upgrade_price = 5, level = 1;
    public Text money_countText;
    public Button upgrade;
    public GameObject banknote;
    public Transform banknote_spawnPoint;

    private void Start()
    {
        upgrade.interactable = false;
        money_countText.text = money_count.ToString();
        click_countText.text = '+' + click_count.ToString();
        upgrade_priceText.text = "Upgrade " + upgrade_price.ToString();
        level_Text.text = "LV" + level.ToString();

    }

    public void ButtonClick()
    {
        money_count += click_count;
        money_countText.text = money_count.ToString();
        if (money_count >= upgrade_price)
            upgrade.interactable = true;
        Instantiate(banknote, GetRandomPosition(), Quaternion.identity);
    }

    Vector3 GetRandomPosition()
    {
        float x = banknote_spawnPoint.position.x + Random.Range(-2f, 2f);
        float y = banknote_spawnPoint.position.y + Random.Range(0f, 1f);
        return new Vector3(x, y, 0f);
    }

    int upgrade_power = 1;
    public Text click_countText;
    public Text upgrade_priceText;
    public Text level_Text;

    public void UpgrageButtonClick()
    {
        if (money_count >= upgrade_price)
        {
            money_count -= upgrade_price;
            level++;
            click_count += upgrade_power;
            click_countText.text = '+' + click_count.ToString();
            upgrade_price += click_count * level;
            upgrade_priceText.text = "Upgrade " + upgrade_price.ToString();
            level_Text.text = "LV " + level.ToString();
            money_countText.text = money_count.ToString();
            if (money_count < upgrade_price)
                upgrade.interactable = false;
        }
    }
}
