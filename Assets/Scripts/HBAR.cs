using UnityEngine;

public class HBAR : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] 
    private UnityEngine.UI.Image _healthbarForFullGROUND;
    public void UpdateHbar(Healthcontrol healthcontrol)
    {
        _healthbarForFullGROUND.fillAmount = healthcontrol.RemainingHealthPercentage;
    }
}
