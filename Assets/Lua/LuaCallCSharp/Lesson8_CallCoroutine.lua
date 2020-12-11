print("**************toLua调用C#中的协程**************")

local CallDelay = nil

--toLua提供了一些方便开启协程的方法
StartDeley = function ()
    --toLua提供的开启协程的方法
    StartCoroutine(Delay)
end

Delay = function ()
    local t = 1
    while true do
        --可直接使用类似unity中的协程相关方法
        WaitForSeconds(1)
        --Yield(0)
        --WaitForFixedUpDate()
        --WaitForEndOfFrame()
        --Yield(异步加载返回值)
        print("Count:" .. t)
        t =t + 1

        if t > 5 then
            StopDelay()
            break
        end
    end 
end

StopDelay = function ()
    StopCoroutine(CallDelay)
    CallDelay = nil
end

--使用协程之前必须在luamanager中lua注册协程  LuaCoroutine.Register(luaState,this);
StartDeley()