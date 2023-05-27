using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaidableRole : Role
{
    //这个类是可攻略角色类，有好感度相关
}
/// <summary>
/// 这个是可攻略角色类数据，继承自RoleData，有好感度，但要访问到好感度应该要用到多态吧
/// </summary>
class RaidableRoleData : RoleData
{
    public int goodwill;//好感度
}
