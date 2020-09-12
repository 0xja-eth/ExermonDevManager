$[language=python]
$[gen_path=game_module/routing.py]
from django.conf.urls import re_path

$<modules:from ${genPyCode}.views import Service as ${code}>$(
)

from .consumer import ChannelLayerTag, GameConsumer

websocket_urlpatterns = [
	re_path('game/', GameConsumer),
]

DISCONNECT_ROUTE = 'player/player/disconnect'

WEBSOCKET_METHOD_ROUTER = {
	$<reqResInterfaces:$%ReqResInterfaceRouterSetting.t%>$(,
	)
}
$<modules:
$[gen_path=${genPyCode}/views.py]
from .models import *

# =======================
# ${name}服务类，封装管理${name}模块的业务处理函数
# =======================
class Service:
	$<reqResInterfaces:$%ReqResInterfaceFunc.t%>


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