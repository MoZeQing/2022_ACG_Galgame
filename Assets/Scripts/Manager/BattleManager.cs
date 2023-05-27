using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

class BattleManager : BaseManager
{
    public RoleData Player;
    public RoleData Boss;

    static GameManager GameManager = new GameManager();
    //static UiManager UiManager = new UiManager();
    //BaseManager RoleManager = GameManager.GetManager(MangerName.Role);
    //UIForm BattleForm = UiManager.GetForm(UIFormTag.BattleForm);
    BattleController BattleController = new BattleController();
    /// <summary>
    /// 这是加载数据，通常是rolemanager拿对战双方的数据
    /// </summary>
    void LoadData(string playerName, string bossName)
    {
        try
        {
            RoleData testPlayer = Player;
            RoleData testBoss = Boss;
            //Player = RoleManager.GetRoleAllProperty(playerName);
            //Boss = RoleManager.GetRoleAllProperty(bossName);
            if (testPlayer==Player || testBoss==Boss)//判断有无成功获取数值
            {
                throw new System.Exception();
            }
        }
        catch (System.Exception)
        {
            System.Console.WriteLine("未成功获取玩家或敌人的数值");
        }
    }
    /// <summary>
    /// 开始一个战斗，调用战斗操作类，切换UI，在调用结束后还要调用结束战斗
    /// 输入的值是先手的人，玩家先手不可逃跑
    /// </summary>
    void BeginBattle(string first)
    {
        BattleForm.Restart_method();
    }
    /// <summary>
    /// 结束战斗删除在BattleManager暂存的角色数据
    /// </summary>
    void BattleEnd()
    {
        Player = null;
        Boss = null;
    }
    public RoleAct Act(string name, string act)//UI调用此方法进行玩家的回合
    {
         return BattleController.BeginPlayerTurn(act,Player);
    }
    public bool Act(string name)//UI调用此方法进行敌人的回合
    {
        BattleForm.MaskOp();
        return BattleController.BeginBossTurn(Boss);
    }
    public Result BattleResult()//所有战斗的结果
    {
        
        if (BattleController.Beat == 2)
        {
            return Result.Triumph;
        }
        if (BattleController.BeBeaten == 2)
        {
            return Result.Failure;
        }
        if (Act(Player.name,BattleForm.act) == RoleAct.atkTure)//这边需要UI那边定义一个参数
        {
            return Result.Persuade;
        }
        return Result.Null;
    }
    
    public enum Result
    {
        Triumph,//战斗胜利
        Failure,//战斗失败
        Persuade,//说服成功 
        Null,
    }
}

