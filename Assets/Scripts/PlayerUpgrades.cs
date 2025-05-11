public static class PlayerUpgrades
{
    public static int MaxHPLevel { get; private set; } = 0;
    public static int MaxArmorLevel { get; private set; } = 0;

    public static bool CanUpgradeHP => MaxHPLevel < 3;
    public static bool CanUpgradeArmor => MaxArmorLevel < 3;

    public static void UpgradeHP()
    {
        if (CanUpgradeHP)
            MaxHPLevel++;
    }

    public static void UpgradeArmor()
    {
        if (CanUpgradeArmor)
            MaxArmorLevel++;
    }

    // Сброс при выходе в главное меню / перезапуске игры
    public static void Reset()
    {
        MaxHPLevel = 0;
        MaxArmorLevel = 0;
    }
}