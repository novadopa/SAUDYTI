using UnityEngine;
using UnityEngine.Events;

public class Healthcontrol : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private float _currentHealth;
    [SerializeField]
    private float _maxHealth;


    public float RemainingHealthPercentage
    {
        get
        {
            return _currentHealth / _maxHealth;
        }
    }
    public UnityEvent OnDied;
    public UnityEvent OnHealthChanged;
    public UnityEvent OnHealed;
    public GameOvER Manager;
    public void TakeDamega(float damega)
    {
        if (_currentHealth == 0)
        {
            return;
        }
        _currentHealth -= damega;

        OnHealthChanged.Invoke();

        if (_currentHealth < 0)
        {
            _currentHealth = 0;

        }

        if (_currentHealth <= 0)
        {
            _currentHealth = 0;
            OnDied.Invoke();

            if (Manager != null)
            {
                Debug.Log("Calling gameOver()...");
                Manager.gameOver();  // Ensure this is called
            }
        }
    }
    public void Heal(float amount)
    {
        if (_currentHealth >= _maxHealth) return;

        _currentHealth = Mathf.Min(_currentHealth + amount, _maxHealth);

        // Визуальные эффекты

        OnHealthChanged.Invoke();
        OnHealed.Invoke();
    }

    public void AddHealth(float amountToAdD)
    {
        if(_currentHealth == _maxHealth)
        {
            return ;
        }
        _currentHealth += amountToAdD;
        OnHealthChanged.Invoke();
        if (_currentHealth > _maxHealth)
        {
            _currentHealth = _maxHealth;
        }

    }

    public void TakeDamaga(float damega)
    {
        if (_currentHealth == 0) return; // Don't apply damage if already dead

        _currentHealth -= damega;
        OnHealthChanged.Invoke();

        if (_currentHealth <= 0)  // Fix: Combine both checks into one
        {
            _currentHealth = 0;
            OnDied.Invoke();  // Call OnDied event first (if needed)
            Destroy(gameObject);  // Destroy the enemy
        }
    }


    [SerializeField] private GameObject coinPrefab;
    [SerializeField] private int minCoins = 1;
    [SerializeField] private int maxCoins = 3;
    [SerializeField] private float spawnRadius = 0.5f; // Радиус разброса

    private void DropCoins()
    {
        if (coinPrefab == null) return;

        Vector3 spawnPos = transform.position;
        int coinsToDrop = Random.Range(minCoins, maxCoins + 1);

        for (int i = 0; i < coinsToDrop; i++)
        {
            Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;
            Instantiate(coinPrefab, spawnPos + randomOffset, Quaternion.identity);
        }
    }
    [SerializeField] private GameObject healthPotionPrefab;
    [SerializeField][Range(0, 100)] private int dropChancePercent = 30; // 30% по умолчанию

    private void TryDropHealthPotion()
    {
        if (healthPotionPrefab == null) return;

        // Более предсказуемый вариант
        int randomRoll = Random.Range(0, 101); // 0-100
        if (randomRoll <= dropChancePercent)
        {
            Vector3 spawnPos = transform.position + Random.insideUnitSphere * spawnRadius;
            Instantiate(healthPotionPrefab, spawnPos, Quaternion.identity);
        }
    }
    [SerializeField] private GameObject expPrefab;
    private void DropEXP()
    {
        if (expPrefab == null) return;

        Vector3 spawnPos = transform.position;

        Vector3 randomOffset = Random.insideUnitCircle * spawnRadius;
        Instantiate(expPrefab, spawnPos + randomOffset, Quaternion.identity);
    }

    public void HandleDeath()
    {
        DropCoins();
        TryDropHealthPotion();
        DropEXP();
    }



}
