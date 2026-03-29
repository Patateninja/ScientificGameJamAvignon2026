using UnityEngine;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public List<int> balances = new(); // 0 = PlayerMoney 1 = MayorMoney 2 = Public
    public List<int> pop = new(); // 0 = PlayerMoney 1 = MayorMoney 2 = Public 3 = None
    public int totalPop = 0;

    void Start()
    {
        if (Instance == null)
            Instance = this;

        balances.Add(5);
        balances.Add(5);
        balances.Add(4);


        pop.Add(0);
        pop.Add(0);
        pop.Add(0);
        pop.Add(0);
    }

    void Update()
    {
        
    }

    public bool CheckMoney(int value, int targetID)
    {
        return balances[targetID] >= value;
    }
    public void AddMoney(int amount, int targetID)
    {
        balances[targetID] += amount;
    }

    public void UpdatePop()
    {
        totalPop = 0;
        foreach(int i in pop)
        {
            totalPop += i;
        }
    }
}
