using UnityEngine;

public class ResourceManager : MonoBehaviour
{
    public static ResourceManager Instance;

    public int PlayerMoney = 10;

    void Start()
    {
        if (Instance == null)
            Instance = this;
    }

    void Update()
    {
        
    }

    public bool CheckMoney(int value)
    {
        return PlayerMoney >= value;
    }
    public void AddMoney(int amount)
    {
        PlayerMoney += amount;
    }
}
