using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lesson3_LuaManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //以后使用lua解析器管理器的套路写法
        //先初始化
        LuaManager.GetInstance().Init();
        LuaManager.GetInstance().Require("CSharpCallLua/Lesson2_Loader");
    }
}
