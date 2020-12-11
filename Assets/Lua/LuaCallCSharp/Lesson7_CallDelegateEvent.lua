print("***************toLua调用C#中的委托和事件**********")

local obj = Lesson7()

--委托是用来装函数的
--要使用C#中的委托 就是来装lua函数

local fun = function ()
    print("Lua函数中的Function")
end

print("***委托中加函数*******")
--Lua中没有复合运算符 不能用+=
--如果是第一次往委托中加函数 因为是nil 不能直接接+ 所以第一次用=
obj.unityAction = fun
obj.unityAction = obj.unityAction + fun
--加匿名函数
obj.unityAction = obj.unityAction + function ()
    print("临时声明的函数")
end

--xlua执行 obj.unityAction()
--toLua中没有办法这样直接执行委托函数 只用通过方法来调用函数
--obj.unityAction() 无效
obj:DoUnityAction()

print("************委托中减函数*************")

obj.unityAction = obj.unityAction - fun
obj.unityAction = obj.unityAction - fun
obj:DoUnityAction()

print("************委托中清空函数*************")

obj.unityAction = nil
obj:DoUnityAction()

local fun2 = function ()
    print("事件加的函数")
end

print("***********事件加函数*************")

--xlua中的事件的加函数 对象：事件名（“+/-”，函数）
--toLua中事件加减函数 和 委托方式一样
--obj.eventAction = fun2 会报错 要遵循unity中的规则 不能直接=要写+=
obj.eventAction = obj.eventAction + fun2
obj.eventAction = obj.eventAction + function ()
    print("事件加的东西")
end
obj:DoEvent()

print("*************事件减函数*************")
obj.eventAction = obj.eventAction - fun2
obj:DoEvent()

print("*************事件清空*************")
obj:ClearEvent()
obj:DoEvent()

