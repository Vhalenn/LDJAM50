using UnityEngine;

static public class Constant
{
    public static float timeSpeed = 1;
    public static float floorHeight = 5;

    // FINANCIAL CONSTANT
    public static float newFloorCost = 1.25f;
    public static float moneyGoalMultiplier = 1.5f;
    public static float inflation = 1.03f;

    public static float partToTheShareHolders = 0.8f;

    static public string DisplayBigNumber(float n)
    {
        string txt = string.Empty;
        if (n >= 1000000000) txt = (n / 1000000000).ToString("F1") + "b";
        else if (n >= 1000000) txt = (n / 1000000).ToString("F1") + "m";
        else if (n >= 1000) txt = (n / 1000).ToString("F1") + "k";
        else txt = n.ToString("F0");

        return txt;
    }
}
