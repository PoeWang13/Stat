using UnityEngine;
using UnityEngine.UI;

public class Canvas_Manager : MonoBehaviour
{
    public Stat myLife = new Stat("Life", 100);
    public Image lifeImage;
    private void Start()
    {
        myLife.OnStatChanced += MyLife_OnStatChanced;
        myLife.RemoveStat(50);
    }
    private void MyLife_OnStatChanced(object sender, System.EventArgs e)
    {
        lifeImage.fillAmount = myLife.StatValue * 1.0f / myLife.ReturnStatCore();
    }
    public void AddLife()
    {
        myLife.AddStat(10);
    }
    public void RemoveLife()
    {
        myLife.RemoveStat(10);
    }
    public void AddYuzdeLife()
    {
        myLife.AddYuzdeStat(10);
    }
    public void RemoveYuzdeLife()
    {
        myLife.RemoveYuzdeStat(10);
    }
    public void AddLifeCore()
    {
        myLife.SetStatCore(myLife.ReturnStatCore() + 10);
    }
    public void RemoveLifeCore()
    {
        myLife.SetStatCore(myLife.ReturnStatCore() - 10);
    }
}