using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldUpdater : MonoBehaviour
{
    [SerializeField] private Text goldText;

    // private void 

    public void UpdateGoldText() {
        GameManager.Instance.IncreaseGold();
        goldText.text = GameManager.Instance.goldAmount.ToString();
    }
}
