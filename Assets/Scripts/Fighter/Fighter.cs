using UnityEngine;

public class Fighter : MonoBehaviour 
{
    [Header("Fighter Stats")]
    public int strength = 5;
    public int speed = 5;
    public int striking = 0;
    public int stamina = 5;
    public int grappling = 0;
    
    void Start() 
    {
        Debug.Log($"Fighter created with {GetTotalPower()} total power");
    }
    
    public int GetTotalPower() 
    {
        return strength + speed + striking + stamina + grappling;
    }
    
    public void TrainStat(StatType statType) 
    {
        switch (statType) 
        {
            case StatType.Strength:
                strength++;
                break;
            case StatType.Speed:
                speed++;
                break;
            case StatType.Striking:
                striking++;
                break;
            case StatType.Stamina:
                stamina++;
                break;
        }
        
        Debug.Log($"Trained {statType}! New total power: {GetTotalPower()}");
    }
}

public enum StatType
{
    Strength,
    Speed,
    Striking,
    Stamina
}