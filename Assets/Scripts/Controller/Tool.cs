using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public static class Tool 
{
    /// <summary>
    /// 这里是条件检定的方法，对于故事中各种条件检定都调用这个方法，事件记录去StoryManager拿，角色数据去RoleManager拿
    /// </summary>
    /// <param name="trigger"></param>
    /// <returns></returns>
    public static bool Check(Trigger trigger)
    {
        GameManager gm = GameObject.FindWithTag("GameController").GetComponent<GameManager>();
        int checkData = -99999999;
        if (trigger == null)
            return true;
        if (trigger.And.Count != 0)
        {
            foreach (Trigger tr in trigger.And)
            {
                if (!Check(tr))
                {
                    return false;
                }
            }
        }
        if (trigger.OR.Count != 0)
        {
            foreach (Trigger tr in trigger.OR)
            {
                if (Check(tr))
                {
                    return true;
                }
            }
            return false;
        }
        if (trigger.key == "")
            return true;
        if(trigger.key == "time")
        {
            TimeManager tm = gm.GetManager(ManagerName.Time) as TimeManager;
            checkData = tm.GetTime().time;
        }
        else if(trigger.key.IndexOf("goodwill") > -1)
        {
            //这是干啥的？
            //string roleName = trigger.key.Replace("goodwill", "");//删除key中的goodwill，剩下角色名
            //checkData = rm.GetRoleProperty(goodwill, roleName);
        }
        else if(trigger.key.IndexOf("player") > -1)
        {
            RoleManager rm = gm.GetManager(ManagerName.Role) as RoleManager;
            RoleData roleData = rm.GetRoleAllProperty("player");
            switch (trigger.key)
            {
                case "playercon": checkData = roleData.con; break;
                case "playerdex": checkData = roleData.dex; break;
                case "playerintz": checkData = roleData.intz; break;
                case "playerapp": checkData = roleData.app; break;
                case "playereq": checkData = roleData.eq; break;
                case "playerluck": checkData = roleData.luck; break;
            }
        }
        else if(trigger.key.IndexOf("history") > -1)
        {
            StoryManager sm = gm.GetManager(ManagerName.Story) as StoryManager;
            string[] history = sm.GetHistory();
            int length = history.Length;
            for(int i = 0; i < length;i++)
            {
                if (history[i] == trigger.value) 
                {
                    return true;
                }
            }
            return false;
        }
        if(checkData == -99999999)
        {
            Debug.Log("没有正确获取到数据");
            return false;
        }
        if (trigger.equals)
        {
            if (checkData == int.Parse(trigger.value))
                return true;
            else
                return false;
        }
        else
        {
            if (trigger.not)//判断至少
            {
                if (checkData > int.Parse(trigger.value))
                    return false;
                else
                    return true;
            }
            else
            {
                if (checkData < int.Parse(trigger.value))
                    return false;
                else
                    return true;
            }
        }
    }
    /// <summary>
    /// 这里是判定具体的操作类，传入一个属性值返回成功程度或失败程度
    /// </summary>
    /// <param name="property"></param>
    /// <returns>返回一个数值，成功（1）、困难成功（2）、极难成功（3）、大成功（4）、失败（0）、大失败（-1）、错误（-2）</returns>
    public static int Roll(int property)
    {
        int random = Random.Range(1, 100);
        if (random >= 95 && property < random) return -1;//大失败
        if (random <= 5 && property > random) return 4;//大成功

        if (random > property)
        {
            return 0;
        }
        else if (random > property / 2)
        {
            return 1;
        }
        else if (random > property / 4)
        {
            return 2;
        }
        else if (random > 5)
        {
            return 3;
        }

        return -2;
    }
    /// <summary>
    /// 这里是传入一个概率，判断失败或成功
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public static bool Probability(int num)
    {
        int random = Random.Range(1, 100);
        return random >= num;
    }
}
/// <summary>
/// 这里可以拿清哥content里那个Trigger
/// </summary>
public class Trigger
{
    //当输入数值为0时，视为不检测该值
    //从P社学来的技巧：全部设为至少为多少，然后通过取反的形式来表示
    //用这两个值，我们就能表示
    [LabelText("或")]
    public List<Trigger> OR = new List<Trigger>();
    [LabelText("和")]
    public List<Trigger> And = new List<Trigger>();

    [LabelText("标签")]
    public string key;//什么标签
    [LabelText("是否取反")]
    public bool not;//是否取反
    [LabelText("等于")]
    public bool equals;
    [LabelText("数值")]
    public string value;//至少的数值
}
