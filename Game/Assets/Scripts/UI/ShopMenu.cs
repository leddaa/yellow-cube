using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShopMenu : MonoBehaviour
{
    // Prices
    private readonly int DARK_MEDIC_PRICE = 500;
    private readonly int HACKER_PRICE = 500;
    private readonly int BLAH_PRICE = 500;
    private readonly int SKULL_PRICE = 500;
    private readonly int GOLDEN_SKULL_PRICE = 5;

    enum Character : int {YELLOWCUBE, DARKMEDIC, HACKER, BLAH, SKULL, GOLDENSKULL};

    public bool MoneyCheck(int amount)
    {
        return amount <= PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS);
    }

    public bool MoneyCheckYC(int YCamount)
    {
        return YCamount <= GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<DataStore>().GetInt(DatastoreKeys.TOTAL_YC_COINS, 0);
    }

    // Standard skin - Yellow Cube
    public void Skin0()  
    {
        PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.YELLOWCUBE);
        PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.YELLOWCUBE); 
    }
   
    // Skins
   public void PurchaseSkin1() // Dark Medic Purchase
    {
        if (MoneyCheck(DARK_MEDIC_PRICE))
        {
            PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.DARKMEDIC);
            PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.DARKMEDIC);
            PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, (PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS) - DARK_MEDIC_PRICE));
            PlayerPrefs.SetInt(PrefKeys.DARK_MEDIC_PURCHASED, 1);
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_1).SetActive(false);

            UpdateCoinsText();
        }
    }
    
    public void Skin1() // Dark Medic Select/Preview
    {
        PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.DARKMEDIC);

            if (PlayerPrefs.GetInt(PrefKeys.DARK_MEDIC_PURCHASED) == 1)
            {
                PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.DARKMEDIC);
            }
    }

    public void PurchaseSkin2() // Hacker Purchase
    {
        if (MoneyCheck(HACKER_PRICE))
        {
            PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.HACKER);
            PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.HACKER);
            PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, (PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS) - HACKER_PRICE));
            PlayerPrefs.SetInt(PrefKeys.HACKER_PURCHASED, 1);
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_2).SetActive(false);

            UpdateCoinsText();
        }
    }

    public void Skin2() // Hacker Select/Preview
    {
        PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.HACKER);

            if (PlayerPrefs.GetInt(PrefKeys.HACKER_PURCHASED) == 1)
            {
                PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.HACKER);
            }
    }

    public void PurchaseSkin3() // Blah Purchase
    {
        if (MoneyCheck(BLAH_PRICE))
        {
            PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.BLAH);
            PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.BLAH);
            PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, (PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS) - BLAH_PRICE));
            PlayerPrefs.SetInt(PrefKeys.BLAH_PURCHASED, 1);
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_3).SetActive(false);

            UpdateCoinsText();
        }
    }

    public void Skin3() // Blah Select/Preview
    {
        PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.BLAH);

            if (PlayerPrefs.GetInt(PrefKeys.BLAH_PURCHASED) == 1)
            {
                PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.BLAH);
            }
    }

    public void PurchaseSkin4() // Skull Purchase
    {
        if (MoneyCheck(SKULL_PRICE))
        {
            PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.SKULL);
            PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.SKULL);
            PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, (PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS) - SKULL_PRICE));
            PlayerPrefs.SetInt(PrefKeys.SKULL_PURCHASED, 1);
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_4).SetActive(false);

            UpdateCoinsText();
        }
    }

    public void Skin4() // Skull Select/Preview
    {
        PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.SKULL);

            if (PlayerPrefs.GetInt(PrefKeys.SKULL_PURCHASED) == 1)
            {
                PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.SKULL);
            }
    }

    public void PurchaseSkin5() // Golden Skull Purchase || YC
    {
        int totalYCCoins = GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<DataStore>().GetInt(DatastoreKeys.TOTAL_YC_COINS, 0);
        if (MoneyCheckYC(GOLDEN_SKULL_PRICE))
        {
            PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.GOLDENSKULL);
            PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.GOLDENSKULL);
            PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, (PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS) - GOLDEN_SKULL_PRICE));
            GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<DataStore>().SetInt(DatastoreKeys.TOTAL_YC_COINS, totalYCCoins - GOLDEN_SKULL_PRICE);
            PlayerPrefs.SetInt(PrefKeys.GOLDEN_SKULL_PURCHASED, 1);
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_YC_1).SetActive(false);

            UpdateYCCoinsText();
        }
    }

    public void Skin5() // Golden Skull Select/Preview
    {
        PlayerPrefs.SetInt(PrefKeys.DUMMY_CHARACTER, (int)Character.GOLDENSKULL);

        if (PlayerPrefs.GetInt(PrefKeys.GOLDEN_SKULL_PURCHASED) == 1)
        {
            PlayerPrefs.SetInt(PrefKeys.CURRENT_CHARACTER, (int)Character.GOLDENSKULL);
        }
    }

    // Main Menu Button
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(Scenes.UI_MENU);
    }

    // Skins Menu Button
    public void LoadSkinsMenu()
    {
        SceneManager.LoadScene(Scenes.SKINS_MENU);
    }

    // Back Button
    public void LoadSceneBack()
    {
        SceneManager.LoadScene(Scenes.SHOP_MENU);
    }

    private void Awake()
    {
        if (PlayerPrefs.GetInt(PrefKeys.DARK_MEDIC_PURCHASED) == 1)
        {
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_1).SetActive(false);
        }

        if (PlayerPrefs.GetInt(PrefKeys.HACKER_PURCHASED) == 1)
        {
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_2).SetActive(false);
        }

        if (PlayerPrefs.GetInt(PrefKeys.BLAH_PURCHASED) == 1)
        {
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_3).SetActive(false);
        }

        if (PlayerPrefs.GetInt(PrefKeys.SKULL_PURCHASED) == 1)
        {
            GameObject.FindGameObjectWithTag(Tags.BUY_BUTTON_4).SetActive(false);
        }

        UpdateCoinsText();
        UpdateYCCoinsText();

    }

    public void UpdateCoinsText()
    {
        // Update coins amount
        GameObject.FindGameObjectWithTag(Tags.COINS_TEXT).GetComponent<TextMeshProUGUI>().text = PlayerPrefs.GetInt(PrefKeys.TOTAL_COINS).ToString() + " coins";
    }

    public void UpdateYCCoinsText()
    {
        GameObject.FindGameObjectWithTag(Tags.TOTAL_GEMS).GetComponent<TextMeshProUGUI>().text = GameObject.FindGameObjectWithTag(Tags.DATA_STORE).GetComponent<DataStore>().GetInt(DatastoreKeys.TOTAL_YC_COINS, 0) + " YC Coins";
    }

    // Reset
    public void HardReset()
    {
        PlayerPrefs.SetInt(PrefKeys.YELLOW_CUBE_PURCHASED, 0);
        PlayerPrefs.SetInt(PrefKeys.DARK_MEDIC_PURCHASED, 0);
        PlayerPrefs.SetInt(PrefKeys.HACKER_PURCHASED, 0);
        PlayerPrefs.SetInt(PrefKeys.BLAH_PURCHASED, 0);
        PlayerPrefs.SetInt(PrefKeys.SKULL_PURCHASED, 0);
        Debug.Log(PlayerPrefs.GetInt(PrefKeys.YELLOW_CUBE_PURCHASED));
        PlayerPrefs.SetInt(PrefKeys.TOTAL_COINS, 1000);
    }

    public void LoadSandbox()
    {
        SceneManager.LoadScene("Level 1 SandBox");
    }
}
