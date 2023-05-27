using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeManager : BaseManager
{
    private  int _gameTime;
    public int GameTime { get => _gameTime; set => _gameTime = value; }
    /// <summary>
    /// 加载存档中的时间
    /// </summary>
    void LoadData()
    {

    }
    /// <summary>
    /// 用于其他插件获取时间
    /// </summary>
    public TimeData GetTime()
    {
        TimeData timeData = new TimeData();
        timeData.day = (GameTime / 3) + 1;
        timeData.time = GameTime % 3;
        timeData.turn = GameTime;
        return timeData;
    }
    /// <summary>
    /// 更新时间
    /// </summary>
    void UpData()
    {
        if(GameTime ==null)
        {
            GameTime =0;
        }
        else 
        {
            GameTime ++;
        }

    }
}
/// <summary>
/// 这个类是时间数据类，其他插件通常需要获取天数day和一天中现在是第几个事件（早中晚）time
/// </summary>
public class TimeData
{
    public int day;
    public int time;
    public int turn;
}
public enum time
{
    morning,
    noon,
    night,
}

