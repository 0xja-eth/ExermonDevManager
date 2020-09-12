${description?# ${description}$name?# ${name}$:# 未知接口}
'${route}': [[$<reqParams:
	['${name}', '${typeCode}']>$(,)
],
	${bFuncText},  # 处理函数
	ChannelLayerTag.${bTagName}  # 是否需要响应
]