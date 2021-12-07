using UnityEngine;

[System.Serializable]
public class Stat
{
    /// <summary>
    /// Stat değiştiğinde ilgili eklenmiş fonksiyonları aktif eder.
    /// </summary>
    public event System.EventHandler OnStatChanced;
    public Stat(string statName)
    {
        this.statName = statName;
    }
    public Stat(string statName, int myStatCore)
    {
        this.statName = statName;
        this.myStatCore = myStatCore;
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
    /// <summary>
    /// Learn Stat Status
    /// </summary>
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