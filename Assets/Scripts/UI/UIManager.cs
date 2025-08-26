// // UIManager.cs - Main UI controller
// using UnityEngine;
// using UnityEngine.UI;
// using TMPro;
// using System.Collections.Generic;

// public class UIManager : MonoBehaviour
// {
//     [Header("Screens")]
//     public GameObject mainMenuScreen;
//     public GameObject fighterProfileScreen;
//     public GameObject combatScreen;
//     public GameObject gymScreen;
//     public GameObject shopScreen;

//     [Header("Main Menu")]
//     public Button fightButton;
//     public Button profileButton;
//     public Button gymButton;
//     public Button shopButton;

//     [Header("Fighter Profile UI")]
//     public TextMeshProUGUI fighterNameText;
//     public TextMeshProUGUI fighterLevelText;
//     public TextMeshProUGUI experienceText;
//     public Slider experienceBar;
//     public TextMeshProUGUI coinsText;
//     public TextMeshProUGUI winsText;
//     public TextMeshProUGUI lossesText;

//     [Header("Fighter Stats")]
//     public TextMeshProUGUI strengthText;
//     public TextMeshProUGUI speedText;
//     public TextMeshProUGUI techniqueText;
//     public TextMeshProUGUI staminaText;
//     public TextMeshProUGUI martialArtText;
//     public Button trainStrengthButton;
//     public Button trainSpeedButton;
//     public Button trainTechniqueButton;
//     public Button trainStaminaButton;

//     [Header("Combat UI")]
//     public TextMeshProUGUI playerHealthText;
//     public TextMeshProUGUI enemyHealthText;
//     public Slider playerHealthBar;
//     public Slider enemyHealthBar;
//     public TextMeshProUGUI combatLogText;
//     public Button combatActionButton;

//     [Header("Gym UI")]
//     public TextMeshProUGUI gymLevelText;
//     public Transform equipmentContainer;
//     public Button upgradeGymButton;

//     private Dictionary<GameState, GameObject> screens;
//     private PlayerData playerData;

//     public void Initialize()
//     {
//         SetupScreens();
//         SetupButtons();
//         playerData = GameManager.Instance.playerData;
//         ShowScreen(GameState.MainMenu);
//     }

//     void SetupScreens()
//     {
//         screens = new Dictionary<GameState, GameObject>
//         {
//             { GameState.MainMenu, mainMenuScreen },
//             { GameState.FighterProfile, fighterProfileScreen },
//             { GameState.Combat, combatScreen },
//             { GameState.Gym, gymScreen },
//             { GameState.Shop, shopScreen }
//         };
//     }

//     void SetupButtons()
//     {
//         // Main Menu Buttons
//         fightButton?.onClick.AddListener(() => StartFight());
//         profileButton?.onClick.AddListener(() => ShowFighterProfile());
//         gymButton?.onClick.AddListener(() => ShowGym());
//         shopButton?.onClick.AddListener(() => ShowShop());

//         // Training Buttons
//         trainStrengthButton?.onClick.AddListener(() => TrainStat(StatType.Strength));
//         trainSpeedButton?.onClick.AddListener(() => TrainStat(StatType.Speed));
//         trainTechniqueButton?.onClick.AddListener(() => TrainStat(StatType.Technique));
//         trainStaminaButton?.onClick.AddListener(() => TrainStat(StatType.Stamina));

//         // Combat Button
//         combatActionButton?.onClick.AddListener(() => ExecuteCombatAction());

//         // Gym Button
//         upgradeGymButton?.onClick.AddListener(() => UpgradeGym());
//     }

//     public void UpdateUIForState(GameState state)
//     {
//         ShowScreen(state);
//         UpdateCurrentScreenData();
//     }

//     void ShowScreen(GameState state)
//     {
//         // Hide all screens
//         foreach (var screen in screens.Values)
//         {
//             if (screen != null) screen.SetActive(false);
//         }

//         // Show current screen
//         if (screens.ContainsKey(state) && screens[state] != null)
//         {
//             screens[state].SetActive(true);
//         }
//     }

//     void UpdateCurrentScreenData()
//     {
//         switch (GameManager.Instance.currentState)
//         {
//             case GameState.MainMenu:
//                 UpdateMainMenuData();
//                 break;
//             case GameState.FighterProfile:
//                 UpdateFighterProfileData();
//                 break;
//             case GameState.Gym:
//                 UpdateGymData();
//                 break;
//         }
//     }

//     void UpdateMainMenuData()
//     {
//         // Update main menu with quick stats
//         if (fighterLevelText != null)
//         {
//             fighterLevelText.text = $"Level {playerData.fighterLevel}";
//         }

//         if (coinsText != null)
//         {
//             coinsText.text = $"Coins: {playerData.coins}";
//         }
//     }

//     void UpdateFighterProfileData()
//     {
//         if (playerData == null) return;

//         // Basic Info
//         if (fighterNameText != null)
//             fighterNameText.text = playerData.playerName;

//         if (fighterLevelText != null)
//             fighterLevelText.text = $"Level {playerData.fighterLevel}";
//     }
// }