using UnityEngine;

public class PlayerAppearance : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private SpriteRenderer playerSpriteRenderer;
    [SerializeField] private string defaultSpriteName = "DefaultCharacter";

    void Start()
    {
        if (playerSpriteRenderer == null)
        {
            playerSpriteRenderer = GetComponent<SpriteRenderer>();
        }

        LoadCharacterAppearance();
    }

    private void LoadCharacterAppearance()
    {
        string spriteName = PlayerPrefs.GetString("SelectedCharacter", defaultSpriteName);
        Sprite[] allSprites = Resources.LoadAll<Sprite>("Characters");

        if (allSprites != null)
        {
            foreach (Sprite sprite in allSprites)
            {
                if (sprite.name == spriteName)
                {
                    playerSpriteRenderer.sprite = sprite;
                    return;
                }
            }
        }

        Debug.LogWarning($"Character sprite '{spriteName}' not found. Using default.");
    }
}