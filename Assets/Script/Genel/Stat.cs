using UnityEngine.UI;

[System.Serializable]
public class StatBar
{
    public Stat stat1;
    public Stat stat2;
    public Image resim;
    public StatBar(Stat stat1, Stat stat2, Image resim)
    {
        this.stat1 = stat1;
        this.stat2 = stat2;
        this.resim = resim;
        stat1.OnStatChanced += S_OnStatChanced;
        stat2.OnStatChanced += S_OnStatChanced;
    }
    private void S_OnStatChanced(object sender, System.EventArgs e)
    {
        resim.fillAmount = stat1.StatValue * 1.0f / stat2.StatValue;
    }
}
[System.Serializable]
public class Stat
{
    /// <summary>
    /// Activates related added functions when stat changes.
    /// </summary>
    public event System.EventHandler OnStatChanced;
    // For some stat, like armor, power etc.
    public Stat(string statName)
    {
        this.statName = statName;
        CalculateStatValue();
    }
    // For some stat, like life, lifeMax etc.
    public Stat(string statName, int myStatCore)
    {
        this.statName = statName;
        this.myStatCore = myStatCore;
        CalculateStatValue();
    }
    public string statName;
    private int myStatCore;
    private int statCore;
    public int StatValue { get { return statCore; } }
    private int statAdd;
    private int statAddYuzde;
    private int statRemove;
    private int statRemoveYuzde;

    public void SetStatCore(int set)
    {
        myStatCore = set;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void AddStatCore(int add)
    {
        myStatCore += add;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void RemoveStatCore(int remove)
    {
        myStatCore -= remove;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void AddStat(int add)
    {
        statAdd += add;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void AddYuzdeStat(int addYuzde)
    {
        statAddYuzde += addYuzde;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void RemoveStat(int remove)
    {
        statRemove += remove;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    public void RemoveYuzdeStat(int removeYuzde)
    {
        statRemoveYuzde += removeYuzde;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    /// <summary>
    /// Return true if stat core bigger than parametre
    /// </summary>
    public bool CheckStatCore(int core)
    {
        return myStatCore >= core;
    }
    /// <summary>
    /// Return true if stat value bigger than parametre
    /// </summary>
    public bool CheckStat(int core)
    {
        return statCore >= core;
    }
    /// <summary>
    /// Learn Stat Core
    /// </summary>
    public int ReturnStatCore()
    {
        return myStatCore;
    }
    /// <summary>
    /// Learn Stat Pozitif Buff
    /// </summary>
    public int ReturnStatPozitifBuff()
    {
        return statAdd + (int)(myStatCore * statAddYuzde * 0.01);
    }
    public string ReturnStatStatus()
    {
        return statName + " : " + StatValue +
            " (<color=green>" + ReturnStatPozitifBuff() + "</color>)" +
            " (<color=red>" + ReturnStatNegatifBuff() + "</color>)";
    }
    /// <summary>
    /// Learn Stat Negatif Buff
    /// </summary>
    public int ReturnStatNegatifBuff()
    {
        return statRemove + (int)(myStatCore * statRemoveYuzde * 0.01);
    }
    /// <summary>
    /// Learn Stat Status
    /// </summary>
    public void ClearStat()
    {
        statAdd = 0;
        statAddYuzde = 0;
        statRemove = 0;
        statRemoveYuzde = 0;
        CalculateStatValue();
        OnStatChanced?.Invoke(this, System.EventArgs.Empty);
    }
    private void CalculateStatValue()
    {
        int core = myStatCore + statAdd + (int)(myStatCore * statAddYuzde * 0.01) - statRemove - (int)(myStatCore * statRemoveYuzde * 0.01);
        statCore = core >= 0 ? core : 0;
    }
}