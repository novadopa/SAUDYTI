using UnityEngine;
using System;
public class UpgradesManager : MonoBehaviour
{
    // 1️⃣ Синглтон-инстанс
    public static UpgradesManager Instance { get; private set; }

    // 2️⃣ Данные улучшений
    public int HPLevel { get; private set; } = 0;
    public int ArmorLevel { get; private set; } = 0;

    // 3️⃣ Инициализация
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // 🔥 Не уничтожаем между сценами
        }
        else
        {
            Destroy(gameObject); // Убиваем дубликаты
        }
        HPLevel = PlayerPrefs.GetInt("HPLevel", 0);
        ArmorLevel = PlayerPrefs.GetInt("ARMORLevel", 0);
    }

    // 4️⃣ Методы улучшений

    public bool TryUpgradeArmor()
    {
        if (ArmorLevel >= 3) return false;

        ArmorLevel++;
        PlayerPrefs.SetInt("ARMORLevel", ArmorLevel);
        return true;
    }
    [SerializeField] private int[] hpUpgradeCosts = { 100, 200, 300 };

    public static event Action OnUpgradesChanged;

    public bool TryUpgradeHP(int currentMoney)
    {
        if (HPLevel >= 3) return false;

        HPLevel++;
        PlayerPrefs.SetInt("HPLevel", HPLevel);
        OnUpgradesChanged?.Invoke();
        return true;
    }

    // 5️⃣ Сброс (по желанию)
    public void ResetAll()
    {
        HPLevel = 0;
        ArmorLevel = 0;
    }
}