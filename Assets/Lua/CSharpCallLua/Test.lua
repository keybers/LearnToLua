print("************************C#调用Lua的测试脚本***************")

--全局变量
testNumber = 1
testBool = true
testFloat = 1.2
testString = "fds"

local testLocal = 10

testFunction = function ()
    print("无参无返回")
end

testFunction2 = function (a)
    print("有参数有返回")
    return a + 100
end

testFunction3 = function (a)
    print("有参多返回值")
    return 1 ,2 , true ,"fds" ,a
end

testFunction4 = function (a, ...)
    print("变长参数无返回")
    print(a)
    arg = {...}
    for k,v in pairs(arg) do
        print(k,v)
    end
end

--table表现的List
testList = {1,2,3,456,87}
testList2 = {"2","7879",456,false}

--table中表现的Dic
testDic = {
    ["1"] = 10,
    ["2"] = 20,
    ["3"] = 30,
    ["4"] = 40,
    ["5"] = 50,
}

testDic2 = {
    ["1"] = false,
    [true] = 45,
    [3] = "fsd",
    ["4"] = true,
}


--lua中的一个自定义table(类)
testTable = {
    testInt = 2,
    testBool = true,
    testFloat = 4.5,
    testString = "fsdfds",
    testFunction = function ()
        print("testTable中的函数打印")
    end

}
--lua协程相关代码 都是tolua提供写协程的方式
local coDelay = nil
--开启协程程序 协程相关的lua逻辑都是toLua帮助实现的

startDelay = function ()
    coDelay = coroutine.start(testCoroutine)
end

testCoroutine = function ()
    local t = 1
    while true do
        --等待一秒执行一次
        coroutine.wait(1)
        print("count:" .. t)
        t = t + 1

        if t>=5 then
            stopDelay()
            break
        end
    end
end

stopDelay = function ()
    coroutine.stop(coDelay) 
end