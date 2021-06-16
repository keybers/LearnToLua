using LuaInterface;
using UnityEngine;

public class LuaCustomLoader : LuaFileUtils
{
    //要注意这里面要加入后缀，unity识别不了lua文件
    public override byte[] ReadFile(string fileName)
    {
        //如果想重新定义 解析lua的方式 那么只需要在该函数中去写逻辑
        Debug.Log("自定义解析方式");
        
        //如果没有lua后缀 加上最好 不管从Resources或者AB包中加载都不支持.lua后缀 所以toLua加上bytes后缀
        //我们自己可以加上.txt后缀
        if (!fileName.EndsWith(".lua"))
        {
            fileName += ".lua";
        }
        byte[] buffer = null;

        //进行热更行的lua代码 肯定是我们自己写的上层lua逻辑
        //第二种从AB包中加载文件

        //CSharpCallLua/Lesson2_Loader这样的名字 但是在AB包中我们需要文件名 所以需要拆分一下
        string[] strs = fileName.Split('/');
        TextAsset luaCode = ABManager.GetInstance().LoadRes<TextAsset>("lua", strs[strs.Length - 1]);
        if (luaCode != null)
        {
            buffer = luaCode.bytes;
            Resources.UnloadAsset(luaCode);
        }
        //tolua的自带逻辑和自带类 我们不需要去热更新 直接从resources中加载

        if (buffer == null)
        {
            //第一种从Resources
            string path = "Lua/" + fileName;
            TextAsset text = Resources.Load<TextAsset>(path);
            if (text != null)
            {
                buffer = text.bytes;
                //卸载使用后文本资源
                Resources.UnloadAsset(text);
            }
        }


        //返回bytes资源
        return buffer;
    }
}
