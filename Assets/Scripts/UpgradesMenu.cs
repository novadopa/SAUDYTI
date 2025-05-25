using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UpgradesMenu : MonoBehaviour
{
    [Header("UI References")]
    public Image hpIndicator;
    public Image armorIndicator;
    public Sprite[] upgradeLevels;

    private void Start()
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        hpIndicator.sprite = upgradeLevels[UpgradesManager.Instance.HPLevel];
        armorIndicator.sprite = upgradeLevels[UpgradesManager.Instance.ArmorLevel];
    }

    public void UpgradeHP()
    {
        if (UpgradesManager.Instance.TryUpgradeHP(100))
        {
            UpdateUI();
        }
    }

    public void UpgradeArmor()
    {
        if (UpgradesManager.Instance.TryUpgradeArmor())
        {
            UpdateUI();
        }
    }


    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}