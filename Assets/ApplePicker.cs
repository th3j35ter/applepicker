using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ApplePicker : MonoBehaviour
{
    [Header("Inscribed")]
    public GameObject basketPrefab;
    public int numBaskets = 4;
    public float basketBottomY = -14f;
    public float basketSpacingY = 2f;
    public List<GameObject> basketList;

    public GameObject restartButton;

    public Text roundText;
    private int currentRound = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        basketList = new List<GameObject>();
        for (int i = 0; i <= numBaskets; i++)
        {
            GameObject tBasketGO = Instantiate<GameObject>(basketPrefab);
            Vector3 pos = Vector3.zero;
            pos.y = basketBottomY + (basketSpacingY * i);
            tBasketGO.transform.position = pos;
            basketList.Add(tBasketGO);
        }

        UpdateRoundUI();
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
            roundText.text = "Game Over";
            ShowRestartButton();
            Time.timeScale = 0;
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
    }
}
