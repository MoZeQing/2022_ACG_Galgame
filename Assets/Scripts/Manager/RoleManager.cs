using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoleManager : BaseManager
{
    private RoleData playerData;
    private Dictionary<string, Role> _roles = new Dictionary<string, Role>();

    public Sprite npcSprite;
    public GameObject rolePrefab;
    public Transform canvas;

    /// <summary>
    /// 这个方法是获取主要角色，加载存档中的角色数据
    /// </summary>
    public override void LoadData()
    {

    }
    /// <summary>
    /// 这个方法是创建故事中特殊的次要角色
    /// </summary>
    public void CreatRole(RoleData roleData)
    {
        Role role = GameObject.Instantiate(rolePrefab, canvas).GetComponent<Role>();//忘记怎么拼了
        role.SetData(roleData);
        role.GetComponent<SpriteRenderer>().sprite = npcSprite;
        _roles.Add(role.GetData().name, role);        
    }
    /// <summary>
    /// 这个方法是清空创建的次要角色
    /// </summary>
    public void DelRole(string name)
    {
        _roles.Remove(name);
    }
    /// <summary>
    /// 这个方法是更新角色数据，一般是故事结尾由故事操作类调用
    /// </summary>
    public void RoleDataUpData(string name,RoleData roleData)
    {
        _roles[name].SetData(roleData);
    }
    /// <summary>
    /// 这个方法是给其他插件查看角色数据
    /// </summary>
    /// <returns>返回的是数值</returns>
    public int GetRoleProperty(string name,Property property)
    {
        return (int)_roles[name].GetType().GetProperty(property.ToString()).GetValue(_roles[name]);
    }
    /// <summary>
    /// 这个方法是给其他插件获取角色的所有数据（通常是保存）
    /// </summary>
    /// <returns>这个类是角色数据类</returns>
    public RoleData GetRoleAllProperty(string name)
    {
        return _roles[name].GetData();
    }
    /// <summary>
    /// 这个是属性检定的方法，调用工具类，同时检定完之后要调用UI输出结果
    /// </summary>
    /// <param name="RoleTag">这个是角色</param>
    /// <param name="Property">这个是属性</param>
    /// <returns>返回一个数值，成功（1）、困难成功（2）、极难成功（3）、大成功（4）、失败（0）、大失败（-1）</returns>
    public int RolePropertyCheck(string roleName , Property property)
    {
        return Tool.Roll(GetRoleProperty(roleName, property));
    }
}
public enum Property
{
    con,//体制
    dex,//敏捷
    iq,//其实是int，但因为那个是关键字用不了，是智力——智商
    app,//外貌
    eq,//情商
    luck,//幸运
}