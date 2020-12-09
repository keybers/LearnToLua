using LuaInterface;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson6_CallListDic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().LuaState.Require("Main");

        //学习如何调用Lua中的List 和 Dic

        //List 
        //toLua中的 C#得到Lua中的表 只有一个套路 通过LuaTable获取
        LuaTable luaTable = LuaManager.GetInstance().LuaState.GetTable("testList");
        //1，2.对应的是位置 不是Key
        Debug.Log("luTable:" + luaTable[1]);
        Debug.Log("luTable:" + luaTable[2]);
        Debug.Log("luTable:" + luaTable[3]);
        Debug.Log("luTable:" + luaTable[4]);
        Debug.Log("luTable:" + luaTable[5]);

        //遍历
        //先转成数组
        object[] objs = luaTable.ToArray();
        foreach(var i in objs)
        {
            Debug.Log("遍历打印：" + i);
        }
        //是引用拷贝
        luaTable[1] = 999;
        LuaTable luaTable2 = LuaManager.GetInstance().LuaState.GetTable("testList");
        Debug.Log("测试引用：" + luaTable2[1]);



        LuaTable luaTable1 = LuaManager.GetInstance().LuaState.GetTable("testList2");
        //1，2.对应的是位置 不是Key
        Debug.Log("luaTable1:" + luaTable1[1]);
        Debug.Log("luaTable1:" + luaTable1[2]);
        Debug.Log("luaTable1:" + luaTable1[3]);
        Debug.Log("luaTable1:" + luaTable1[4]);
        Debug.Log("luaTable1:" + luaTable1[5]);

        objs = luaTable1.ToArray();
        foreach (var i in objs)
        {
            Debug.Log("遍历打印：" + i);
        }

        //Dictionary相关
        LuaTable dic = LuaManager.GetInstance().LuaState.GetTable("testDic");
        Debug.Log(dic["1"]);
        Debug.Log(dic["2"]);
        Debug.Log(dic["3"]);
        Debug.Log(dic["4"]);

        LuaDictTable<string, int> luaDic = dic.ToDictTable<string, int>();
        Debug.Log("luaDic:" + luaDic["1"]);
        Debug.Log("luaDic:" + luaDic["2"]);
        Debug.Log("luaDic:" + luaDic["3"]);
        Debug.Log("luaDic:" + luaDic["4"]);

        //dictionary也是引用拷贝
        dic["1"] = 8527;
        LuaTable luaTable3 = LuaManager.GetInstance().LuaState.GetTable("testDic");
        Debug.Log("luaTable3引用拷贝测试：" + dic["1"]);

        //如果想通过中括号得到值 只支持string和int 其它类型的键值无法获取
        LuaTable dic2 = LuaManager.GetInstance().LuaState.GetTable("testDic2");
        //Debug.Log(dic2[true]);
        LuaDictTable<object,object> luaDic2 = dic2.ToDictTable<object, object>();
        Debug.Log("luaDic2:" + luaDic2["1"]);
        Debug.Log("luaDic2:" + luaDic2[true]);
        Debug.Log("luaDic2:" + luaDic2["4"]);
        Debug.Log("luaDic2:" + luaDic2[3]);

        //dic使用迭代器遍历
        IEnumerator<LuaDictEntry<object,object>> dicIE = luaDic2.GetEnumerator();
        while (dicIE.MoveNext())
        {
            Debug.Log(dicIE.Current.Key + "_" + dicIE.Current.Value);
        }

        List<int> tes = null;
        List<int>.Enumerator tefd = tes.GetEnumerator();

    }

}
