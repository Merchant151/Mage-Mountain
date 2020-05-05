using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    Text money, months, reputation;
    int m1, m2, r1;

    // Start is called before the first frame update
    void Start()
    {
        money = GameObject.Find("MoneyText").GetComponent<Text>();
        months = GameObject.Find("MonthText").GetComponent<Text>();
        reputation = GameObject.Find("ReputationText").GetComponent<Text>();
        m1 = 100;
        m2 = 6;
        r1 = 50;
    }

    // Update is called once per frame
    void Update()
    {
        money.text = m1 + " / MaxMoney";
        months.text = m2 + " Month(s) remain";
        reputation.text = "Reputation: " + r1;
    }
}
