print("*************CallEnum***************")

--枚举的调用规则和类的调用的规则是一样的
--命名空间.枚举名.枚举成员
--也支持去别名

--调用unity自带的枚举 
--如果报错不认识 需要在CustomSetting中去加上 而后生成代码
PrimitiveType = UnityEngine.PrimitiveType
GameObject = UnityEngine.GameObject
Debug = UnityEngine.Debug

--GameObjec中的静态方法 创建集合体
local obj = GameObject.CreatePrimitive(PrimitiveType.Cube)

--UserData类型 保留了语言中的数据类型
print(c)

--调用我们自定义的枚举
local w = testEnum.Walk
local c = testEnum.Idle
Debug.Log(c)

--可以进行枚举比较
if(c == w) then
    print("相等")
    else
    print("枚举不相等")
end

print("枚举转字符串")
print(tostring(c))

print("枚举转数字")
print(tonumber(c)) --nil
print(c:ToInt()) -- 0
print(w:ToInt()) -- 1

--如果超出枚举范围 返回原始值
print("数字转枚举")
print(testEnum.IntToEnum(0))
print(tostring(testEnum.IntToEnum(0)))
print(testEnum.IntToEnum(1))
print(tostring(testEnum.IntToEnum(1)))

--和XLua的区别 没有提供字符串转枚举的功能