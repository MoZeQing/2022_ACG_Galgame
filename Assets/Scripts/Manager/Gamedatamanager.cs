using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class GameDataManager : BaseManager
{
    //请在下方声明你要贮存的数据类型，最好都加上[SerializeField]
    [SerializeField]public string test;
    


    public void SaveSystem()//
    {
        var sd = new SaveData();
       // 请在下方这个区域输入  sd.xxx = xxx ; 来储存数据
        sd.test = test;




        //请在上方这个区域输入  sd.xxx = xxx ; 来储存数据
        var json = JsonUtility.ToJson(sd);
        string fileName = "playerdata";//
        var path = Path.Combine(Application.persistentDataPath, fileName);
        try//会将运行失败或者成功的信息打在控制台上
        {
            File.WriteAllText(path, json);
#if UNITY_EDITOR
            Debug.Log($"already save data to {path}");
#endif
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"fail to save.{exception}");
        }
    }

    public void LoadSystem()
    {
         string fileName = "playerdata";
         var path = Path.Combine(Application.persistentDataPath, fileName);

        try//会将运行失败或者成功的信息打在控制台上
        {
            var json = File.ReadAllText(path);
        var sd = JsonUtility.FromJson<SaveData>(json);
            // 请在下方这个区域输入  xxx = sd.xxx  ; 来提取数据
            test = sd.test;




            //请在上方这个区域输入  xxx = sd.xxx   ; 来提取数据
#if UNITY_EDITOR
            Debug.Log($"already load data{test} to {path}");
#endif 
            
        }
        catch (System.Exception exception)
        {
            Debug.LogError($"fail to load.{exception}");
           
        }
    }
    [System.Serializable]class SaveData
        //请在下方声明你要贮存的数据类型，最好都加上[SerializeField],可以直接复制最前面的
    {
        [SerializeField] public string test ;


    }
}
