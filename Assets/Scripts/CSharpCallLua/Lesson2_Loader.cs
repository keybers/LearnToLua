using LuaInterface;
using UnityEngine;

public class Lesson2_Loader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //之所以自定义解析类 new 了就可以用 因为父类是单例模式
        LuaCustomLoader luaCustomLoader = new LuaCustomLoader();
        //学习通过toLua的解析器 自定义解析路径

        //声明Lua解析器 执行Lua代码
        LuaState luaState = new LuaState();
        luaState.Start();
        
        //第一种 使用LuaState中的方法 AddSearchPath
        //luaState.AddSearchPath(Application.dataPath + "/Lua/CSharpCallLua");
        //luaState.Require("Lesson2_Loader");

        //第二种 如果该文件 只属于Lua文件夹下 那么可以直接加父目录下
        luaState.Require("CSharpCallLua/Lesson2_Loader");

        //测试 新建文件夹 事实证明可以
        //luaState.AddSearchPath(Application.dataPath + "/MyLua");
        //luaState.Require("My");

        //主要学习目标 学会通过toLua的解析器 自定义解析方式
        //要实现自定义解析方式 新建一个类 继承 LuaFileUtils 然后重写加载函数 就达到了自定义的目的



    }
}
