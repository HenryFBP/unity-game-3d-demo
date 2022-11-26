using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollector : MonoBehaviour
{
    int coinsCollected = 0;

    [SerializeField] TextMeshProUGUI coinsText;
    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            coinsCollected += 1;
            UpdateText();
        }

    }

    private void Start()
    {
        UpdateText();
    }

    private void UpdateText()
    {
        coinsText.text = ("coins = " + coinsCollected);
    }
}
