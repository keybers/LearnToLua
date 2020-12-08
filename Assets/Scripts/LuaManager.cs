using LuaInterface;
/// <summary>
/// 通过LuaManager管理唯一的一个toLua解析器
/// </summary>
public class LuaManager : SingletonAutoMono<LuaManager>
{
    private LuaState luaState;
    /// <summary>
    /// 自定义解析的初始化
    /// </summary>
    public void Init()
    {
        //激活自定义解析器，最后打包的时候再用
        //new LuaCustomLoader();
        //初始化唯一的LuaState
        luaState = new LuaState();
        luaState.Start();

        //委托初始化

        //协程相关

        //Lua使用unity中的相关类
    }

    public LuaState LuaState
    {
        get
        {
            return luaState;
        }
    }

    /// <summary>
    /// 提供一个外部执行 lua语法字符串的 方法
    /// </summary>
    /// <param name="str">lua语法字符串</param>
    /// <param name="chunkName">执行出处</param>
    public void DoString(string str,string chunkName = "LuaManager.cs")
    {
        luaState.DoString(str,chunkName);
    }

    /// <summary>
    /// 执行指定的lua脚本
    /// </summary>
    /// <param name="fileName">lua文件名</param>
    public void Require(string fileName)
    {
        luaState.Require(fileName);
    }

    /// <summary>
    /// 销毁lua解析器
    /// </summary>
    public void Dispose()
    {
        if (luaState == null)
            return;
        luaState.CheckTop();
        luaState.Dispose();
        luaState = null;
    }
}