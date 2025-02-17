using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 3;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    public GameObject restartButton;

    public Text roundText;
    private int currentRound = 1;
    private int maxRound = 4;
    public int branchesToAdvance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i < numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }
        branchesToAdvance = Random.Range(5, 10);
        UpdateRoundUI();
    }

    void Update()
    {
        AppleTree appleTree = Camera.main.GetComponent<AppleTree>();
        if (appleTree != null && appleTree.branchesFallen >= branchesToAdvance)
        {
            UpdateRound();
            appleTree.branchesFallen = 0;
        }
    }

    public void AppleMissed()
    {
        GameObject[] appleArray = GameObject.FindGameObjectsWithTag("Apple");
        foreach (GameObject tempGO in appleArray)
        {
            Destroy(tempGO);
        }

        int basketIndex = basketList.Count - 1;
        GameObject basketGO = basketList[basketIndex];
        basketList.RemoveAt(basketIndex);
        Destroy(basketGO);

        if (basketList.Count == 0)
        {
            Time.timeScale = 0;
            roundText.text = "Game Over";
            ShowRestartButton();
        }
    }

    void UpdateRoundUI()
    {
        roundText.text = "Round " + currentRound;
    }

    public void NextRound()
    {
        currentRound++;
        UpdateRoundUI();
    }

    void ShowRestartButton()
    {
        restartButton.SetActive(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void RemoveAllBaskets()
    {
        foreach (GameObject basket in basketList)
        {
            Destroy(basket);
        }
        basketList.Clear();

        roundText.text = "Game Over";
        Time.timeScale = 0;
        ShowRestartButton();
    }

    public void UpdateRound()
    {
        if (currentRound < maxRound)
        {
            currentRound++;
            UpdateRoundUI();
            IncreaseDifficulty();
        }
        else
        {
            roundText.text = "You Win!";
            Time.timeScale = 0;
            ShowRestartButton();
        }
    }

    void IncreaseDifficulty()
    {
        AppleTree appleTree = Camera.main.GetComponent<AppleTree>();

        if (appleTree != null)
        {
            appleTree.speed += 0.5f;
            appleTree.appleDropDelay = Mathf.Max(0.5f, appleTree.appleDropDelay - 0.2f);
            appleTree.changeDirChance += 0.05f;
            appleTree.branchSpawnChance += 0.05f;
        }
    }
}
