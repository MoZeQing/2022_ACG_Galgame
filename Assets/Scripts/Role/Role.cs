using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//这里是角色的父类
public class Role : MonoBehaviour
{
    public SpriteRenderer sprite;

    private RoleData _roleData;

    public void SetData(RoleData roleData)
    {
        _roleData = roleData;
    }
    public RoleData GetData()
    {
        return _roleData;
    }
}
/// <summary>
/// 这个是角色数据，包含角色的各种属性
/// </summary>
public class RoleData
{
    public string name;
    public int HP;
    public int con;//体质
    public int dex;//敏捷
    public int intz;//其实是int，但因为那个是关键字用不了，是智力
    public int app;//外貌
    public int eq;//情商
    public int luck;//幸运
}
