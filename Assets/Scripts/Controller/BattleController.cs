using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
class BattleController : MonoBehaviour
{
    public int Beat = 0;//敌人被击中的次数
    public int BeBeaten = 0;//玩家被击中的次数
    public int Round;//回合数
    //这三个字段原本打算用来实现回合制
    public BattleController() { }
    RoleManager RoleManager = new RoleManager();
    /// <summary>
    /// 这里战斗控制类
    /// </summary>
    /// <summary>
    /// 这里是开始玩家的回合，返回值是表示攻击/嘴炮成功与否或者逃跑
    /// </summary>
    /// <param name="role"></param>
    public RoleAct BeginPlayerTurn(string act,RoleData role)//根据UI传来的数据决定动作
    {
        Round++;
        switch (act)
        {
            case "Attack":
                Beat++;
                return Attack(role);
            case "Run":
                return Run();
            case "Talk":
                return Talk(role);
            default:
                return RoleAct.error;
        }
    }
    RoleAct Attack(RoleData role)//攻击
    {
        int Dice = Random.Range(1, 100);//用来判断闪避
        if (RoleManager.RolePropertyCheck(role.name, Property.con) >= 1 && RoleManager.GetRoleProperty(Property.dex)/2 >= Dice)//判断是否攻击成功
        {
            return RoleAct.atkTure;
        }
        else//判断是否攻击失败
        {
            return RoleAct.atkFalse;
        }
    }
    RoleAct Talk(RoleData role)//说服
    {
        if (RoleManager.RolePropertyCheck(role.name, Property.eq) >= 1)//判断是否说服成功
        {
            return RoleAct.talkTure;
        }
        else//判断是否说服失败
        {
            return RoleAct.talkFlase;
        }
    }
    RoleAct Run()//逃跑
    {
        bool Success = Tool.Probability(20);
        if (Success == true)
        {
            return RoleAct.run;
        }
        else
        {
            return RoleAct.runFalse;
        }
    }
    /// <summary>
    /// 这是开始boss的回合，返回值是成功攻击与否
    /// </summary>
    /// <param name="boss"></param>
    public bool BeginBossTurn(RoleData boss)
    {
        int Dice = Random.Range(1, 100);//判断用来闪避的骰子
        Round++;
        if (RoleManager.RolePropertyCheck(boss.name,Property.con)>=1 && RoleManager.GetRoleProperty(Property.dex) / 2 >= Dice)//判断敌人是否攻击成功
        {
            BeBeaten++;
            return true;
        }
        else
        {
            return false;
        }
    }
}

public enum RoleAct
{
    atkTure,
    atkFalse,
    talkTure,
    talkFlase,
    run,
    runFalse,//我自己加的
    error,//我自己加的
}

