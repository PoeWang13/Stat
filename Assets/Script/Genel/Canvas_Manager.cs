using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Canvas_Manager : MonoBehaviour
{
    public TextMeshProUGUI statText;
    [SerializeField] private Image resim;
    private Stat lifeMax = new Stat("LifeMax", 200);
    private Stat life = new Stat("Life", 100);
    private StatBar lifeBar;
    private void Awake()
    {
        lifeBar = new StatBar(life, lifeMax, resim);
        life.RemoveStat(50);
    }
    public void AddLife()
    {
        life.AddStat(10);
    }
    public void RemoveLife()
    {
        life.RemoveStat(10);
    }
    public void AddYuzdeLife()
    {
        life.AddYuzdeStat(10);
    }
    public void RemoveYuzdeLife()
    {
        life.RemoveYuzdeStat(10);
    }
    public void AddLifeCore()
    {
        life.SetStatCore(life.ReturnStatCore() + 10);
    }
    public void RemoveLifeCore()
    {
        life.SetStatCore(life.ReturnStatCore() - 10);
    }
}