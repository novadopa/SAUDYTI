using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UpgradesMenu : MonoBehaviour
{
    //public PlayerStats playerStats;

    public Image hpIndicator; 
    public Image armorIndicator; 

    public Sprite[] upgradeLevels; 

    private int hpUpgradeLevel = 0;   
    private int armorUpgradeLevel = 0; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }

    public void UpgradeHP()
    {
        if (hpUpgradeLevel < 3)
        {
            //playerStats.UpgradeHP();
            hpUpgradeLevel++;
            hpIndicator.sprite = upgradeLevels[hpUpgradeLevel];
            //PlayerPrefs.SetInt("HPLevel", hpUpgradeLevel); 
        }
    }

    public void UpgradeArmor()
    {
        if (armorUpgradeLevel < 3)
        {
            //playerStats.UpgradeArmor();
            armorUpgradeLevel++;
            armorIndicator.sprite = upgradeLevels[armorUpgradeLevel];
            //PlayerPrefs.SetInt("ArmorLevel", armorUpgradeLevel);
        }
    }
}
