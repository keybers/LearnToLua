print("**************toLua访问C#的拓展方法*************")

--静态方法的调用
Lesson4.Eat()

--成员方法
local obj = Lesson4()

--成员方法使用：
obj:Speak("你好")

--拓展方法 不能通过添加Tools类类型来解决
--CustomSettings中加.AddExtendType(typeof(Tools))
--_GT(typeof(Lesson4)).AddExtendType(typeof(Tools)),
--：会把自己传入进去
obj:Move()
