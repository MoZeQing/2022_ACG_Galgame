using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
public class GameManager : BaseManager
{
    private BattleManager bm;
    private StoryManager sm;
    private TimeManager tm;
    private RoleManager rm;

    private GameDataManager gdm;
    /// <summary>
    /// 这里负责story的加载并且调用UiMamanger切换初始界面,并获取所有管理类
    /// </summary>
    void Start()
    {
       //获取管理类
        bm=GetComponent<BattleManager>(); //找！
        sm=GetComponent<StoryManager>();
        tm=GetComponent<TimeManager>();
        rm=GetComponent<RoleManager>();

        gdm = GetComponent<GameDataManager>();
    }
    /// <summary>
    /// 这个方法负责加载存档数据（包括人物数据，历史事件，时间）
    /// </summary>
    public override void LoadData(int DataNo)//添加一个加载存档的参数，集中读档
    {
        gdm.LoadData(DataNo);

        sm.LoadData();
        rm.LoadData();
        tm.LoadData();
        rm.LoadData();
    }
    /// <summary>
    /// 给其他类获取其他manager类的对象
    /// </summary>
    /// <param name="Name"></param>
    public BaseManager GetManager(ManagerName mn)
    {
        switch (mn)
        {
            case ManagerName.Battle: return bm;

        }
    }
}
/// <summary>
/// 这是存档数据，包含角色数据roleData，历史事件HistoryStorys，和当前事件TimeData
/// </summary>
public class SavedData
{
    //public Dictionary<string, RoleData> roleDatas;
    public Dictionary <string,RoleData> rolesData;
    public string[] historyStorys;
    public TimeData timedata;
}
public enum ManagerName
{
    Game,
    Battle,
    Role,
    Story,
    Time,
    Ui,
}
