using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SimpleFighterUI : MonoBehaviour
{
    [Header("Fighter Info")]
    public TextMeshProUGUI fighterNameText;
    public TextMeshProUGUI levelText;
    public TextMeshProUGUI healthText;
    
    [Header("Basic Stats")]
    public TextMeshProUGUI strengthText;
    public TextMeshProUGUI speedText;
    public TextMeshProUGUI staminaText;
    
    [Header("Simple Controls")]
    public Button trainButton;
    public Button restButton;
    
    // Simple fighter data
    private string fighterName = "John Fighter";
    private int level = 1;
    private int currentHealth = 100;
    private int maxHealth = 100;
    private int strength = 10;
    private int speed = 8;
    private int stamina = 12;
    
    void Start()
    {
        // Set up button listeners
        if (trainButton != null)
            trainButton.onClick.AddListener(OnTrainClicked);
            
        if (restButton != null)
            restButton.onClick.AddListener(OnRestClicked);
        
        // Update UI for first time
        UpdateUI();
    }
    
    void UpdateUI()
    {
        // Update fighter info
        if (fighterNameText != null)
            fighterNameText.text = fighterName;
            
        if (levelText != null)
            levelText.text = "Level: " + level;
            
        if (healthText != null)
            healthText.text = "Health: " + currentHealth + "/" + maxHealth;
        
        // Update stats
        if (strengthText != null)
            strengthText.text = "Strength: " + strength;
            
        if (speedText != null)
            speedText.text = "Speed: " + speed;
            
        if (staminaText != null)
            staminaText.text = "Stamina: " + stamina;
    }
    
    void OnTrainClicked()
    {
        Debug.Log("Training...");
        
        // Simple training - randomly improve a stat
        int randomStat = Random.Range(0, 3);
        
        switch(randomStat)
        {
            case 0:
                strength += 1;
                Debug.Log("Strength increased!");
                break;
            case 1:
                speed += 1;
                Debug.Log("Speed increased!");
                break;
            case 2:
                stamina += 1;
                Debug.Log("Stamina increased!");
                break;
        }
        
        // Training costs some health
        currentHealth = Mathf.Max(0, currentHealth - 10);
        
        UpdateUI();
    }
    
    void OnRestClicked()
    {
        Debug.Log("Resting...");
        
        // Restore some health
        currentHealth = Mathf.Min(maxHealth, currentHealth + 20);
        
        UpdateUI();
    }
}