# 艾瑟萌开发管理系统

## 配置方法

使用 VisualStudio2017 打开工程的 .sln 文件即可。可能会出现窗体无法编辑的情况，先生成一次解决方案，再尝试重启或许能解决。

## 基本使用

待补充

## 艾瑟萌模板引擎

### 模板介绍

艾瑟萌模板引擎具备模板引擎的基本功能，此外还可以通过单个模板文件生成多个不同内容不同语言的代码文件。也可以在一个模板中嵌入另一个模板，增强模板的复用性。

### 模板语法

#### 变量块

- 语法：`${NAME}`

- 释义：从当前上下文绑定的数据中查找名称为NAME的成员（包括：属性（Property）、字段（Field）和无参方法（Method））的值（若为方法，则使用其返回值），嵌入当前的变量块中。如果没有绑定数据，从全局的变量字典中查找键为NAME的值并嵌入。

- 举例：

```
/// \<summary\>
/// ${name}
/// \</summary\>
namespace ${csCode} { }
```

若当前绑定数据如下所示（这里是简化表示，实际上绑定的是一个`BaseData`对象）：

```
name: "系统模块"
csCode: "GameModule"
```

则生成的代码为：

```csharp
/// <summary>
/// 系统模块
/// </summary>
namespace GameModule { }
```

#### 条件块

- 语法：`${COND1?CODE1$COND2?CODE2...$CONDn?CODEn$:ELSE_CODE}`

- 释义：这段语法的逻辑相当于以下伪代码：
```
if (COND1) code += genCode(CODE1)
else if (COND2) code += genCode(CODE2)
else if (COND3) code += genCode(CODE3)
...
else if (CONDn) code += genCode(CODEn)
else code += genCode(ELSE_CODE)

// genCode(CODE) 用于对后续的CODE模板代码来生成实际代码
```
其中，`$:`即`else`语句可忽略，且CODE中的模板代码仍支持所有模板语法。

- 举例：

```
# ${description?${description}$name?${name}$:未知接口}
```

以下几段代码分别绑定的数据为：
```
name: "我是接口名称"
description: "我是接口描述"

name: "我是名称"
description: ""

name: ""
description: ""
```

则生成的代码分别为：

```python
# 我是接口描述

# 我是名称

# 未知接口
```

#### 循环块

- 语法：`$<LIST:CODE>`

- 参数：
 1. spliter：分隔符，指定每个循环产出的代码段之间的分隔文本，默认为空字符串。

- 释义：这段语法的逻辑相当于以下伪代码：
```
foreach(var item in LIST){
	// 如果不是第一项，则在其前面加一个spliter字符串
	if (not the first item) 
		code += spliter
	code += genCode(CODE, item)
}

// genCode(CODE, item) 用于对后续的CODE模板代码来生成实际代码（绑定item的数据）
```
其中，参数通过后接`$(CODE)`传递，这里的CODE为纯代码，不受模板语法影响。

- 举例：

```
def register($<params:${name}: '${type}'}>$(, )):
	pass
```

绑定的数据列表为：

```
name: "username"
type: "str"

name: "password"
type: "str"

name: "email"
type: "str"

name: "code"
type: "str"
```

则生成的代码为：

```python
def register(username: 'str', password: 'str', email: 'str', code: 'str'):
	pass
```

#### 循环中断

- 语法：`$!`

- 释义：清除该次循环生成的代码并跳入下一个循环，逻辑如下：
```
foreach(var item in LIST){
	// 生成其他代码
	if (break) { // 如果检测到了$!语句
		clearCode() // 清除本次循环已经生成的代码
		continue // 进入下一次循环
	}
	// 生成其他代码
}
```

- 举例：

```
name = CharField($<params:${isDefault?$!$:${name}=${value}}>$(, ))
```

绑定的数据列表为：

```
name: "default"
value: ""
isDefault: true

name: "max_length"
value: "0"
isDefault: true

name: "null"
value: "True"
isDefault: false

name: "blank"
value: "False"
isDefault: true

name: "verbose_name"
value: "\"名称\""
isDefault: false
```

则生成的代码为：

```python
name = CharField(null=True, verbose_name="名称")
# 其他参数因为 isDefault 为 true 都被清除掉了
```

#### 配置块

- 语法：`$[KEY=VALUE]`

- 释义：用于对生成的配置进行修改，目前支持的KEY值有：
 - language：设置之后生成的代码所属的语言，目前支持python和c#（忽略大小写）
 - gen_path：设置之后生成的代码所在的文件

- 举例：

```
$[language=python]
$[gen_path=backend/game_module/routing.py]
```

- 特殊用法：可以与循环块结合，批量生成多个文件的代码：

```
$<modules:
$[gen_path=backend/${pyCode}/views.py]
from .models import *

# =======================
# ${name}服务类，封装管理${name}模块的业务处理函数
# =======================
class Service:
	$<reqResInterfaces:$%backend/interface/ReqResInterfaceFunc%>


# =======================
# ${name}校验类，封装${name}业务数据格式校验的函数
# =======================
class Check:
	pass


# =======================
# ${name}公用类，封装关于${name}模块的公用函数
# =======================
class Common:
	pass

>
```

#### 注释块

- 语法：`$$COMMENT`

- 释义：单行注释，生成代码时候将无视。

#### 嵌入块

- 语法：`$%PATH%`

- 释义：嵌入相对路径为PATH的模板文件，相当于直接加入另一个模板文件的模板代码，模板引擎会自动对缩进进行同步处理。

- 举例：

```
$$ Interfaces.exer
WEBSOCKET_METHOD_ROUTER = {
	$<interfaces:$%backend/interface/InterfaceRouterSetting%>$(,
	)
}

$$ backend/interface/InterfaceRouterSetting.exer
# ${description?${description}$name?${name}$:未知接口}
'${route}': [
	${funcCode},  # 处理函数
]
```

绑定的数据列表为：

```
name: "我是接口名称"
description: "我是接口描述"
route: "test/test/test1"
funcCode: "test1"

name: "我是名称"
description: ""
route: "test/test/test2"
funcCode: "test2"

name: ""
description: ""
route: "test/test/test3"
funcCode: "test3"
```

则生成的代码为：

```python
WEBSOCKET_METHOD_ROUTER = {
	# 我是接口描述
	'test/test/test1': [
		test1,  # 处理函数
	],
	# 我是名称
	'test/test/test2': [
		test2,  # 处理函数
	],
	# 未知接口
	'test/test/test3': [
		test3,  # 处理函数
	]
}
```

#### 反斜杠（\）

- 反斜杠有两种用途，第一种是作为转义字符使用。比如在一个条件块中，需要生成`}`的代码，而`}`刚好也是条件块的一个关键字符，这里可以改为`\}`来输出`}`字符，在使用 SublimeText3 编写模板代码的时候该类型的错误可以通过语法高亮快速找到。

- 第二种为代码另起一行，与python的反斜杠作用类似，实际上是忽略反斜杠之后的所有空白字符。

- 举例：

```
${hasTypeSettings?\
TYPE_FIELD_FILTER_MAP = \{
	$<typeSettings:'${name}': [${genFieldsCode}]
>$(,)\
\}
}
```

在这个例子中，条件块的代码中存在一个`{}`结构，如果不使用`\`进行转义，则条件块会在第一个`}`中结束，与我们的期望不符，所以需要改为`\}`，另外，为了统一视觉效果，前面的`{`最好也改为`\{`。

```
$[language=python]\
${bNameCode} = ${bTypeCode}(\
	$<fieldParams:${isDefault?$!$:${name}=${value}}>$(, ))
```

相当于

```
$[language=python]${bNameCode} = ${bTypeCode}($<fieldParams:${isDefault?$!$:${name}=${value}}>$(, ))
```

即将一行代码拆分成多行来写，增强代码可读性，而不影响输出代码的结果。

### 内置模板使用

用 VS 将程序编译生成了之后，将本仓库的 Templates 文件夹复制到你生成的可执行文件所在的目录上，并改名为 templates，即可使用内置模板。

### SublimeText3 语法高亮配置

打开 SublimeText3 ，在上面的菜单中选择 Preferences - Browse Packages...
系统将会打开 SublimeText3 的包文件夹，打开里面的 User 文件夹，将 ExermonTemplate.sublime-syntax 文件复制到里面即可。
配置完毕之后就可以在 SublimeText3 中快速编写模板了！
